// pixbufobj.cpp
// OpenGL SuperBible, Chapter 18
// Demonstrates use of Pixel Buffer Objects (PBOs)
// Program by Benjamin Lipchak

#include "../../shared/gltools.h"   // OpenGL toolkit
#include "../../shared/glFrame.h"   // OpenGL toolkit
#include "../../shared/stopwatch.h" // General purpose stop watch class

#include <assert.h>
#include <stdio.h>

GLint windowWidth = 512;            // window size
GLint windowHeight = 512;
GLint dataWidth = 512;              // dimensions of PBOs & textures
GLint dataHeight = 512;
GLint dataPitch = 512*3;            // size of row (padded to 4 byte boundary)
GLint dataOffsetX = 0;              // offset of data within window
GLint dataOffsetY = 0;

GLint mainMenu;                     // menu handles
GLint usageMenu;

GLboolean npotTexturesAvailable = GL_FALSE;
GLboolean usePBOs = GL_FALSE;
GLboolean useMotionBlur = GL_TRUE;

GLubyte* pixels[3];                 // 3 old frames the size of window
GLboolean frameGood[3];             // is this frame valid yet?
GLuint currentFrame = 0;            // which old frame are we on?

GLfloat angleIncrement = 1.0f;

GLenum usageHint = GL_STREAM_COPY;

// Called to draw scene
void RenderScene(void)
{
    static int iFrames = 0;           // Frame count
    static CStopWatch frameTimer;     // Render time
 
    // Reset the stopwatch on first time
    if(iFrames == 0)
    {
        frameTimer.Reset();
        iFrames++;
    }

    // Advance old frame
    currentFrame = (currentFrame + 1) % 3;
    int lastFrame = (currentFrame + 2) % 3;
    int frameBeforeThat = (currentFrame + 1) % 3;

    // Rotate the texture matrix for unit 0 (current frame)
    glActiveTexture(GL_TEXTURE0);
    glTranslatef(0.5f, 0.5f, 0.0f);
    glRotatef(angleIncrement, 0.0f, 0.0f, 1.0f);
    glTranslatef(-0.5f, -0.5f, 0.0f);

    if (!useMotionBlur)
    {
        GLfloat copiedMatrix[16];
        glGetFloatv(GL_TEXTURE_MATRIX, copiedMatrix);
        glActiveTexture(GL_TEXTURE1);
        glLoadMatrixf(copiedMatrix);
        glBindTexture(GL_TEXTURE_2D, 1);
    }

    // Draw objects in the scene
    int i;
    glBegin(GL_QUADS);
        for (i = 0; i < 3; i++)
            glMultiTexCoord2f(GL_TEXTURE0 + i, 0.0f, 0.0f);
        glVertex2f(-1.0f, -1.0f);
        for (i = 0; i < 3; i++)
            glMultiTexCoord2f(GL_TEXTURE0 + i, 0.0f, 1.0f);
        glVertex2f(-1.0f, 1.0f);
        for (i = 0; i < 3; i++)
            glMultiTexCoord2f(GL_TEXTURE0 + i, 1.0f, 1.0f);
        glVertex2f(1.0f, 1.0f);
        for (i = 0; i < 3; i++)
            glMultiTexCoord2f(GL_TEXTURE0 + i, 1.0f, 0.0f);
        glVertex2f(1.0f, -1.0f);
    glEnd();

    // Now read back result
    if (usePBOs)
    {
        glBindBuffer(GL_PIXEL_PACK_BUFFER, currentFrame + 1);
        glReadPixels(dataOffsetX, dataOffsetY, dataWidth, dataHeight, GL_RGB, GL_UNSIGNED_BYTE, (GLvoid*)0);
        glBindBuffer(GL_PIXEL_PACK_BUFFER, 0);
    }
    else
    {
        glReadPixels(dataOffsetX, dataOffsetY, dataWidth, dataHeight, GL_RGB, GL_UNSIGNED_BYTE, pixels[currentFrame]);
    }

    frameGood[currentFrame] = GL_TRUE;

    // Prepare the last frame by dividing colors by 4
    if (usePBOs)
    {
        glBindBuffer(GL_PIXEL_UNPACK_BUFFER, lastFrame + 1);
        pixels[lastFrame] = (GLubyte*)glMapBuffer(GL_PIXEL_UNPACK_BUFFER, GL_READ_WRITE);
    }
    for (int y = 0; y < dataHeight; y++)
    {
        for (int x = 0; x < dataWidth; x++)
        {
            GLubyte *ptr = (GLubyte *)pixels[lastFrame] + (y*dataPitch) + (x*3);
            *(ptr + 0) >>= 2;
            *(ptr + 1) >>= 2;
            *(ptr + 2) >>= 2;
        }
    }
    if (usePBOs)
    {
        glUnmapBuffer(GL_PIXEL_UNPACK_BUFFER);
        pixels[lastFrame] = NULL;
    }

    glActiveTexture(GL_TEXTURE1);
    glBindTexture(GL_TEXTURE_2D, 2+lastFrame);
    if (usePBOs)
    {
        if (frameGood[lastFrame])
        {
            glTexImage2D(GL_TEXTURE_2D, 0, GL_RGB8, dataWidth, dataHeight, 0, GL_RGB, GL_UNSIGNED_BYTE, (GLvoid*)0);
        }
        glBindBuffer(GL_PIXEL_UNPACK_BUFFER, 0);
    }
    else if (frameGood[lastFrame])
    {
        glTexImage2D(GL_TEXTURE_2D, 0, GL_RGB8, dataWidth, dataHeight, 0, GL_RGB, GL_UNSIGNED_BYTE, pixels[lastFrame]);
    }

    glActiveTexture(GL_TEXTURE2);
    glBindTexture(GL_TEXTURE_2D, 2+frameBeforeThat);

    if (glGetError() != GL_NO_ERROR)
        fprintf(stderr, "GL Error!\n");

    // Flush drawing commands
    glutSwapBuffers();

    // Increment the frame count
    iFrames++;

    // Do periodic frame rate calculation
    if (iFrames == 101)
    {
        float fps;
        char cBuffer[64];

        fps = 100.0f / frameTimer.GetElapsedSeconds();
        if (usePBOs)
            sprintf(cBuffer,"Draw scene with PBOs %.1f fps", fps);
        else
            sprintf(cBuffer,"Draw scene without PBOs %.1f fps", fps);

        glutSetWindowTitle(cBuffer);
        frameTimer.Reset();
        iFrames = 1;
    }
}

void SetupTextures(void)
{
    // Create 4 texture objects and load up original texture in all.
    // Divide colors by 2 and 4 to accommodate our additive blending
    GLint w, h, c;
    GLenum format;
    GLbyte *texels = gltLoadTGA("reservoir.tga", &w, &h, &c, &format);
    assert(c == GL_RGB8);
    assert((w % 4) == 0);
    for (int y = 0; y < h; y++)
    {
        for (int x = 0; x < w; x++)
        {
            GLubyte *ptr = (GLubyte *)texels + ((y*w)+x)*3;
            *(ptr + 0) >>= 1;
            *(ptr + 1) >>= 1;
            *(ptr + 2) >>= 1;
        }
    }
    // This texture object will hold the current frame, rendered at 50% brightness
    glBindTexture(GL_TEXTURE_2D, 1);
    glTexImage2D(GL_TEXTURE_2D, 0, c, w, h, 0, format, GL_UNSIGNED_BYTE, texels);
    glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MAG_FILTER, GL_LINEAR);
    glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MIN_FILTER, GL_LINEAR);
    glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_S, GL_CLAMP_TO_BORDER);
    glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_T, GL_CLAMP_TO_BORDER);
    for (int y = 0; y < h; y++)
    {
        for (int x = 0; x < w; x++)
        {
            GLubyte *ptr = (GLubyte *)texels + ((y*w)+x)*3;
            *(ptr + 0) >>= 1;
            *(ptr + 1) >>= 1;
            *(ptr + 2) >>= 1;
        }
    }
    // These texture objects will hold old frames, rendered at 25% brightness
    for (int i = 2; i <= 4; i++)
    {
        glBindTexture(GL_TEXTURE_2D, i);
        glTexImage2D(GL_TEXTURE_2D, 0, c, w, h, 0, format, GL_UNSIGNED_BYTE, texels);
        glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MAG_FILTER, GL_LINEAR);
        glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MIN_FILTER, GL_LINEAR);
        glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_S, GL_CLAMP_TO_BORDER);
        glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_T, GL_CLAMP_TO_BORDER);
    }
    free(texels);

    // Set up texture units for additive 2D multitexturing
    for (int i = 0; i < 3; i++)
    {
        glActiveTexture(GL_TEXTURE0 + i);
        glBindTexture(GL_TEXTURE_2D, i+1);
        glTexEnvi(GL_TEXTURE_ENV, GL_TEXTURE_ENV_MODE, GL_ADD);
        glEnable(GL_TEXTURE_2D);
    }
    if (!useMotionBlur)
    {
        glActiveTexture(GL_TEXTURE2);
        glDisable(GL_TEXTURE_2D);
    }
    glActiveTexture(GL_TEXTURE0);
    glLoadIdentity();
}

// This function does any needed initialization on the rendering
// context. 
void SetupRC()
{
    pixels[0] = pixels[1] = pixels[2] = NULL;
    frameGood[0] = frameGood[1] = frameGood[2] = GL_FALSE;

    fprintf(stdout, "Pixel Buffer Object Demo\n\n");

    // Make sure required functionality is available!
    if (!GLEE_VERSION_2_1 && !GLEE_ARB_pixel_buffer_object)
    {
        fprintf(stderr, "PBO extension is not available!\n");
        Sleep(2000);
        exit(0);
    }

    if (GLEE_ARB_texture_non_power_of_two)
    {
        npotTexturesAvailable = GL_TRUE;
    }
    else
    {
        fprintf(stderr, "GL_ARB_texture_non_power_of_two extension is not available!\n");
        fprintf(stderr, "Only portion of window will be used for rendering.\n\n");
    }

    // Check for minimum resources
    GLint intVal = 0;
    glGetIntegerv(GL_MAX_TEXTURE_UNITS, &intVal);
    if (intVal < 3)
    {
        fprintf(stderr, "Fewer than 3 texture units available!\n");
        Sleep(2000);
        exit(0);
    }
    glGetIntegerv(GL_MAX_TEXTURE_SIZE, &intVal);
    if (intVal < 1024)
    {
        fprintf(stderr, "1024x1024 texture not supported!\n");
        Sleep(2000);
        exit(0);
    }

    fprintf(stdout, "Controls:\n");
    fprintf(stdout, "\tRight-click for menu\n\n");
    fprintf(stdout, "\tb\tToggle motion blur\n\n");
    fprintf(stdout, "\tp\tToggle PBO usage\n\n");
    fprintf(stdout, "\tarrows\t+/- rotation speed\n\n");
    fprintf(stdout, "\tq\t\tExit demo\n\n");
    
    // Colors
    glClearColor(0.0f, 0.0f, 0.0f, 1.0f );
    glColor4f(0.0f, 0.0f, 0.0f, 1.0f );

    // Texture matrix is the only one we'll change
    glMatrixMode(GL_TEXTURE);

    // Set up textures
    SetupTextures();
}

void toggleMotionBlur(void)
{
    useMotionBlur = !useMotionBlur;

    if (useMotionBlur)
    {
        glutChangeToMenuEntry(2, "Toggle motion blur (currently ON)", 2);
        glActiveTexture(GL_TEXTURE1);
        glLoadIdentity();
        glActiveTexture(GL_TEXTURE2);
        glEnable(GL_TEXTURE_2D);
    }
    else
    {
        glutChangeToMenuEntry(2, "Toggle motion blur (currently OFF)", 2);
        glActiveTexture(GL_TEXTURE2);
        glDisable(GL_TEXTURE_2D);
    }
}

void togglePBOs(void)
{
    usePBOs = !usePBOs;

    if (usePBOs)
    {
        glutChangeToMenuEntry(1, "Toggle PBO usage (currently ON)", 1);

        // first upload client memory to PBOs, then free them
        for (int i = 0; i < 3; i++)
        {
            glBindBuffer(GL_PIXEL_PACK_BUFFER, i+1);
            glBufferData(GL_PIXEL_PACK_BUFFER, dataHeight * dataPitch, pixels[i], usageHint);

            assert(pixels[i]);
            free(pixels[i]);
            pixels[i] = NULL;
        }
        glBindBuffer(GL_PIXEL_PACK_BUFFER, 0);
    }
    else
    {
        glutChangeToMenuEntry(1, "Toggle PBO usage (currently OFF)", 1);

        // allocate read buffer, size of window
        for (int i = 0; i < 3; i++)
        {
            assert(!pixels[i]);
            pixels[i] = (GLubyte*)malloc(dataHeight * dataPitch);
            assert(pixels[i]);

            // upload PBO data, then delete
            glBindBuffer(GL_PIXEL_PACK_BUFFER, i+1);
            glGetBufferSubData(GL_PIXEL_PACK_BUFFER, 0, dataHeight * dataPitch, pixels[i]);
        }
        GLuint names[3] = {1, 2, 3};
        glBindBuffer(GL_PIXEL_PACK_BUFFER, 0);
        glDeleteBuffers(3, names);
    }
}

void ProcessMenu(int value)
{
    switch(value)
    {
    case 1:
        togglePBOs();
        break;

    case 2:
        toggleMotionBlur();
        break;

    default:
        // we have a change of usage
        usageHint = GL_STREAM_DRAW + (value - 3);
        if (usePBOs)
        {
            // destroy then recreate PBOs
            togglePBOs();
            togglePBOs();
        }
        break;
    }

    // Refresh the Window
    glutPostRedisplay();
}

void KeyPressFunc(unsigned char key, int x, int y)
{
    switch (key)
    {
    case 'b':
    case 'B':
        toggleMotionBlur();
        break;
    case 'p':
    case 'P':
        togglePBOs();
        break;
    case 'q':
    case 'Q':
    case 27 : /* ESC */
        exit(0);
    }

    // Refresh the Window
    glutPostRedisplay();
}

void SpecialKeys(int key, int x, int y)
{
    switch (key)
    {
    case GLUT_KEY_UP:
    case GLUT_KEY_RIGHT:
        angleIncrement += 1.0f;
        break;
    case GLUT_KEY_DOWN:
    case GLUT_KEY_LEFT:
        angleIncrement -= 1.0f;
        break;
    default:
        break;
    }

    // Refresh the Window
    glutPostRedisplay();
}

void ChangeSize(int w, int h)
{
    windowWidth = dataWidth = w;
    windowHeight = dataHeight = h;

    if (!npotTexturesAvailable)
    {
        // make the data region the next smaller power of two
        while (dataWidth & (dataWidth-1))
            dataWidth--;
        while (dataHeight & (dataHeight-1))
            dataHeight--;

        dataOffsetX = (windowWidth - dataWidth) / 2;
        dataOffsetY = (windowHeight - dataHeight) / 2;
    }

    // Track camera angle
    glViewport(dataOffsetX, dataOffsetY, dataWidth, dataHeight);
    
    // by default, rows are padded to 4 bytes
    dataPitch = (((dataWidth*3)+3) & ~0x3);

    SetupTextures();

    // invalidate the old frames
    frameGood[0] = frameGood[1] = frameGood[2] = GL_FALSE;

    // allocate read buffers, size of data region within window
    for (int i = 0; i < 3; i++)
    {
        if (usePBOs)
        {
            assert(!pixels[i]);
            glBindBuffer(GL_PIXEL_PACK_BUFFER, i+1);
            glBufferData(GL_PIXEL_PACK_BUFFER, dataHeight * dataPitch, NULL, usageHint);
            glBindBuffer(GL_PIXEL_PACK_BUFFER, 0);
        }
        else
        {
            // pixels[i] may not be set up yet on 1st time through
            if (pixels[i])
                free(pixels[i]);
            pixels[i] = (GLubyte*)malloc(dataHeight * dataPitch);
            assert(pixels[i]);
        }
    }
}

int main(int argc, char* argv[])
{
    glutInit(&argc, argv);
    glutInitDisplayMode(GLUT_DOUBLE | GLUT_RGB | GLUT_DEPTH);
    glutInitWindowSize(windowWidth, windowHeight);
    glutCreateWindow("Pixel Buffer Object Demo");
    glutReshapeFunc(ChangeSize);
    glutKeyboardFunc(KeyPressFunc);
    glutSpecialFunc(SpecialKeys);
    glutDisplayFunc(RenderScene);
    glutIdleFunc(RenderScene);

    SetupRC();

    // Create the menus
    usageMenu = glutCreateMenu(ProcessMenu);
    glutAddMenuEntry("GL_STREAM_DRAW", 3);
    glutAddMenuEntry("GL_STREAM_READ", 4);
    glutAddMenuEntry("GL_STREAM_COPY", 5);
    glutAddMenuEntry("GL_STATIC_DRAW", 6);
    glutAddMenuEntry("GL_STATIC_READ", 7);
    glutAddMenuEntry("GL_STATIC_COPY", 8);
    glutAddMenuEntry("GL_DYNAMIC_DRAW", 9);
    glutAddMenuEntry("GL_DYNAMIC_READ", 10);
    glutAddMenuEntry("GL_DYNAMIC_COPY", 11);

    mainMenu = glutCreateMenu(ProcessMenu);
    glutAddMenuEntry("Toggle PBO usage (currently OFF)", 1);
    glutAddMenuEntry("Toggle motion blur (currently ON)", 2);
    glutAddSubMenu("Choose PBO usage (currently GL_STREAM_COPY)", usageMenu);
    glutAttachMenu(GLUT_RIGHT_BUTTON);

    glutMainLoop();

    for (int i = 0; i < 3; i++)
    {
        if (!usePBOs)
            free(pixels[i]);
    }

    return 0;
}
