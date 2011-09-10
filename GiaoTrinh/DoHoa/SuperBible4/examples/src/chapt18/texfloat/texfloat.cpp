// texfloat.cpp
// OpenGL SuperBible, Chapter 18
// Demonstrates use of floating-point textures
// Program by Benjamin Lipchak

#include "../../shared/gltools.h"   // OpenGL toolkit
#include <ImfRgbaFile.h>            // OpenEXR headers
#include <ImfArray.h>

#ifdef _WIN32
#pragma comment (lib, "IlmImf.lib")
#pragma comment (lib, "Imath.lib")
#pragma comment (lib, "zlib.lib")
#endif

#include <assert.h>
#include <stdio.h>

GLint windowWidth = 1024;           // window size
GLint windowHeight = 768;

GLfloat *fTexels;                   // read back the framebuffer to here

GLfloat fCursorX = 0.0f;            // float cursor position [-1,1]
GLfloat fCursorY = 0.0f;
GLint iCursorX = 0;                 // integer cursor position [0,w/h]
GLint iCursorY = 0;

GLfloat maxR = 0.0f;
GLfloat maxG = 0.0f;
GLfloat maxB = 0.0f;

#define CLAMPED 0
#define TRIVIAL 1
#define IRIS 2
#define WHITEBALANCE 3
#define TOTAL_SHADERS 4

GLuint fShader[TOTAL_SHADERS], progObj[TOTAL_SHADERS];          // shader object names
GLboolean needsValidation[TOTAL_SHADERS];
char *shaderNames[TOTAL_SHADERS] = {"clamped", "trivial", "iris", "whitebalance"};
int currentShader = TRIVIAL;

GLint npotTextureWidth, npotTextureHeight;  // texture size
GLint potTextureWidth, potTextureHeight;
GLint maxTexSize;
GLboolean npotTexturesAvailable = GL_FALSE;
GLfloat xAspect, yAspect;           // aspect ratio of quad surface

GLint mainMenu;                     // menu handles
GLint shaderMenu;
GLint textureMenu;

#define MAX_INFO_LOG_SIZE 2048

// Load shader from disk into a null-terminated string
GLchar *LoadShaderText(const char *fileName)
{
    GLchar *shaderText = NULL;
    GLint shaderLength = 0;
    FILE *fp;

    fp = fopen(fileName, "r");
    if (fp != NULL)
    {
        while (fgetc(fp) != EOF)
        {
            shaderLength++;
        }
        rewind(fp);
        shaderText = (GLchar *)malloc(shaderLength+1);
        if (shaderText != NULL)
        {
            fread(shaderText, 1, shaderLength, fp);
        }
        shaderText[shaderLength] = '\0';
        fclose(fp);
    }

    return shaderText;
}

// Compile shaders
void PrepareShader(GLint shaderNum)
{
    char fullFileName[255];
    GLchar *fsString;
    const GLchar *fsStringPtr[1];
    GLint success;

    // Create shader objects and specify shader text
    sprintf(fullFileName, "./shaders/%s.fs", shaderNames[shaderNum]);
    fsString = LoadShaderText(fullFileName);
    if (!fsString)
    {
        fprintf(stderr, "Unable to load \"%s\"\n", fullFileName);
        Sleep(5000);
        exit(0);
    }
    fShader[shaderNum] = glCreateShader(GL_FRAGMENT_SHADER);
    fsStringPtr[0] = fsString;
    glShaderSource(fShader[shaderNum], 1, fsStringPtr, NULL);
    free(fsString);

    // Compile shaders and check for any errors
    glCompileShader(fShader[shaderNum]);
    glGetShaderiv(fShader[shaderNum], GL_COMPILE_STATUS, &success);
    if (!success)
    {
        GLchar infoLog[MAX_INFO_LOG_SIZE];
        glGetShaderInfoLog(fShader[shaderNum], MAX_INFO_LOG_SIZE, NULL, infoLog);
        fprintf(stderr, "Error in fragment shader #%d compilation!\n", shaderNum);
        fprintf(stderr, "Info log: %s\n", infoLog);
        Sleep(10000);
        exit(0);
    } else
    {
        GLchar infoLog[MAX_INFO_LOG_SIZE];
        glGetShaderInfoLog(fShader[shaderNum], MAX_INFO_LOG_SIZE, NULL, infoLog);
        //fprintf(stderr, "Fragment shader #%d compile info log: %s\n", shaderNum, infoLog);
    }

    // Create program object, attach shader, then link
    progObj[shaderNum] = glCreateProgram();
    glAttachShader(progObj[shaderNum], fShader[shaderNum]);

    glLinkProgram(progObj[shaderNum]);
    glGetProgramiv(progObj[shaderNum], GL_LINK_STATUS, &success);
    if (!success)
    {
        GLchar infoLog[MAX_INFO_LOG_SIZE];
        glGetProgramInfoLog(progObj[shaderNum], MAX_INFO_LOG_SIZE, NULL, infoLog);
        fprintf(stderr, "Error in program #%d linkage!\n", shaderNum);
        fprintf(stderr, "Info log: %s\n", infoLog);
        Sleep(10000);
        exit(0);
    }
    else
    {
        GLchar infoLog[MAX_INFO_LOG_SIZE];
        glGetProgramInfoLog(progObj[shaderNum], MAX_INFO_LOG_SIZE, NULL, infoLog);
        //fprintf(stderr, "Program #%d link info log: %s\n", shaderNum, infoLog);
    }

    // Program object has changed, so we should revalidate
    needsValidation[shaderNum] = GL_TRUE;
}

// Called to draw scene
void RenderScene(void)
{
    // Clear the window with current clearing color
    glClear(GL_COLOR_BUFFER_BIT);

    glUseProgram(progObj[currentShader]);

    if ((currentShader == IRIS) || (currentShader == WHITEBALANCE))
    {
        // rough simulation of an iris:
        // find brightest spot in neighborhood (51x51)
        // and map that to 1.0 in shader

        GLfloat newMaxR = 0.0f;
        GLfloat newMaxG = 0.0f;
        GLfloat newMaxB = 0.0f;

        GLfloat *ptr;

        // map cursor location [-1,1] to texel address [0,u/v]
        GLint centerU = (GLint)((((fCursorX / xAspect) + 1.0f) * 0.5f) * (GLfloat)npotTextureWidth);
        GLint centerV = (GLint)((((fCursorY / yAspect) + 1.0f) * 0.5f) * (GLfloat)npotTextureHeight);

        for (int v = centerV - 25; v <= centerV + 25; v++)
        {
            for (int u = centerU - 25; u <= centerU + 25; u++)
            {
                // check for neighborhoods that fall off the texture
                if ((u < 0) || (u >= npotTextureWidth) ||
                    (v < 0) || (v >= npotTextureHeight))
                    continue;

                ptr = fTexels + ((v * potTextureWidth + u) * 3);

                newMaxR = (ptr[0] > newMaxR) ? ptr[0] : newMaxR;
                newMaxG = (ptr[1] > newMaxG) ? ptr[1] : newMaxG;
                newMaxB = (ptr[2] > newMaxB) ? ptr[2] : newMaxB;
            }
        }

        // slowly adjust between new maximum and old,
        // which simulates slow adjustment of iris
        maxR += (newMaxR - maxR) * 0.01f;
        maxG += (newMaxG - maxG) * 0.01f;
        maxB += (newMaxB - maxB) * 0.01f;

        GLint uniformLoc = glGetUniformLocation(progObj[currentShader], "max");
        if (uniformLoc != -1)
        {
            glUniform3f(uniformLoc, maxR, maxG, maxB);
        }
    }

    // Draw objects in the scene
    glBegin(GL_QUADS);
        glTexCoord2f(0.0f, 0.0f);
        glVertex2f(-1.0f * xAspect, -1.0f * yAspect);
        glTexCoord2f(0.0f, (GLfloat)npotTextureHeight / (GLfloat)potTextureHeight);
        glVertex2f(-1.0f * xAspect, 1.0f * yAspect);
        glTexCoord2f((GLfloat)npotTextureWidth / (GLfloat)potTextureWidth, (GLfloat)npotTextureHeight / (GLfloat)potTextureHeight);
        glVertex2f(1.0f * xAspect, 1.0f * yAspect);
        glTexCoord2f((GLfloat)npotTextureWidth / (GLfloat)potTextureWidth, 0.0f);
        glVertex2f(1.0f * xAspect, -1.0f * yAspect);
    glEnd();

    glUseProgram(0);

    if ((currentShader == IRIS) || (currentShader == WHITEBALANCE))
    {
        GLfloat halfWidth = 51.0f * xAspect / npotTextureWidth;
        GLfloat halfHeight = 51.0f * yAspect / npotTextureHeight;

        // Show cursor
        glColor4f(1.0f, 0.0f, 0.0f, 1.0f);
        glBegin(GL_LINE_LOOP);
            glVertex2f(fCursorX - halfWidth, fCursorY - halfHeight);
            glVertex2f(fCursorX - halfWidth, fCursorY + halfHeight);
            glVertex2f(fCursorX + halfWidth, fCursorY + halfHeight);
            glVertex2f(fCursorX + halfWidth, fCursorY - halfHeight);
        glEnd();
    }

    if (glGetError() != GL_NO_ERROR)
        fprintf(stderr, "GL Error!\n");

    // Flush drawing commands
    glutSwapBuffers();
}

void AlterAspect()
{
    if (windowHeight == 0)
    {
        yAspect = 1.0f;
        xAspect = 0.00001f;
        return;
    }

    GLfloat textureAspect = (GLfloat)npotTextureWidth / (GLfloat)npotTextureHeight;
    GLfloat windowAspect = (GLfloat)windowWidth / (GLfloat)windowHeight;

    if (textureAspect > windowAspect)
    {
        xAspect = 1.0f;
        yAspect = windowAspect / textureAspect;
    }
    else
    {
        yAspect = 1.0f;
        xAspect = textureAspect / windowAspect;
    }
}

using namespace Imf;
using namespace Imath;

void SetupTextures(int whichEXR)
{
    Array2D<Rgba> pixels;
    char name[256];

    switch (whichEXR)
    {
    case 0:
        strcpy(name, "openexr-images/Blobbies.exr");
        break;
    case 1:
        strcpy(name, "openexr-images/Desk.exr");
        break;
    case 2:
        strcpy(name, "openexr-images/GoldenGate.exr");
        break;
    case 3:
        strcpy(name, "openexr-images/MtTamWest.exr");
        break;
    case 4:
        strcpy(name, "openexr-images/Ocean.exr");
        break;
    case 5:
        strcpy(name, "openexr-images/Spirals.exr");
        break;
    case 6:
        strcpy(name, "openexr-images/StillLife.exr");
        break;
    case 7:
        strcpy(name, "openexr-images/Tree.exr");
        break;
    default:
        assert(0);
        break;
    }
    RgbaInputFile file(name);
    Box2i dw = file.dataWindow();

    npotTextureWidth = dw.max.x - dw.min.x + 1;
    npotTextureHeight = dw.max.y - dw.min.y + 1;
    pixels.resizeErase(npotTextureHeight, npotTextureWidth);

    file.setFrameBuffer(&pixels[0][0] - dw.min.x - dw.min.y * npotTextureWidth, 1, npotTextureWidth);
    file.readPixels(dw.min.y, dw.max.y);

    // Stick the texels into a GL formatted buffer
    potTextureWidth = npotTextureWidth;
    potTextureHeight = npotTextureHeight;

    if (!npotTexturesAvailable)
    {
        while (potTextureWidth & (potTextureWidth-1))
            potTextureWidth++;
        while (potTextureHeight & (potTextureHeight-1))
            potTextureHeight++;
    }

    if ((potTextureWidth > maxTexSize) || (potTextureHeight > maxTexSize))
    {
        fprintf(stderr, "Texture is too big!\n");
        Sleep(2000);
        exit(0);
    }

    if (fTexels)
        free(fTexels);
    fTexels = (GLfloat*)malloc(potTextureWidth * potTextureHeight * 3 * sizeof(GLfloat));
    GLfloat *ptr = fTexels;
    for (int v = 0; v < potTextureHeight; v++)
    {
        for (int u = 0; u < potTextureWidth; u++)
        {
            if ((v >= npotTextureHeight) || (u >= npotTextureWidth))
            {
                ptr[0] = 0.0f;
                ptr[1] = 0.0f;
                ptr[2] = 0.0f;
            }
            else
            {
                Rgba texel = pixels[npotTextureHeight - v - 1][u];  // inverted vertically
                ptr[0] = texel.r;
                ptr[1] = texel.g;
                ptr[2] = texel.b;
            }
            ptr += 3;
        }
    }

    // pick up new aspect ratio
    AlterAspect();

    glTexParameteri(GL_TEXTURE_2D, GL_GENERATE_MIPMAP, 1);
    glTexImage2D(GL_TEXTURE_2D, 0, GL_RGB16F_ARB, potTextureWidth, potTextureHeight, 0, GL_RGB, GL_FLOAT, fTexels);
    glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MAG_FILTER, GL_LINEAR);
    glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MIN_FILTER, GL_LINEAR_MIPMAP_LINEAR);
    glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_S, GL_CLAMP_TO_EDGE);
    glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_T, GL_CLAMP_TO_EDGE);
}

void SetupShaders(void)
{
    // we'll leave fixed functionality vertex shading in place,
    // but we'll swap between two fragment shaders

    // Load and compile shaders
    for (int i = 0; i < TOTAL_SHADERS; i++)
    {
        PrepareShader(i);
        glUseProgram(progObj[i]);

        // set sampler
        GLint uniformLoc = glGetUniformLocation(progObj[i], "sampler0");
        if (uniformLoc != -1)
        {
            glUniform1i(uniformLoc, 0);
        }
    }

    glUseProgram(0);
}

// This function does any needed initialization on the rendering
// context. 
void SetupRC()
{
//    fprintf(stdout, "Floating-Point Texture Demo\n\n");

    // Make sure required functionality is available!
    if (!GLEE_ARB_texture_float)
    {
        fprintf(stderr, "GL_ARB_texture_float extension is not available!\n");
        Sleep(2000);
        exit(0);
    }

    if (GLEE_ARB_texture_non_power_of_two)
    {
        npotTexturesAvailable = GL_TRUE;
    }
    else
    {
//        fprintf(stderr, "GL_ARB_texture_non_power_of_two extension is not available!\n");
//        fprintf(stderr, "Only portion of window will be used for rendering.\n\n");
    }

    // Check for minimum resources
    glGetIntegerv(GL_MAX_TEXTURE_SIZE, &maxTexSize);

//    fprintf(stdout, "Controls:\n");
//    fprintf(stdout, "\tRight-click for menu\n\n");
//    fprintf(stdout, "\tc\t\tClamped (no tone mapping)\n\n");
//    fprintf(stdout, "\tt\t\tTrivial tone mapping\n\n");
//    fprintf(stdout, "\tf\t\tFancy tone mapping\n\n");
//    fprintf(stdout, "\tq\t\tExit demo\n\n");
    
    // Clear color
    glClearColor(0.0f, 0.0f, 0.0f, 1.0f );

    // Set up textures & shaders
    SetupTextures(0);
    SetupShaders();
}

void ProcessMenu(int value)
{
    switch(value)
    {
    case 1:
        currentShader = CLAMPED;
        break;

    case 2:
        currentShader = TRIVIAL;
        break;

    case 3:
        currentShader = IRIS;
        break;

    case 4:
        currentShader = WHITEBALANCE;
        break;

    default:
        SetupTextures(value - 5);
        break;
    }

    // Refresh the Window
    glutPostRedisplay();
}

void KeyPressFunc(unsigned char key, int x, int y)
{
    switch (key)
    {
    case 'q':
    case 'Q':
    case 27 : /* ESC */
        exit(0);
    }

    // Refresh the Window
    glutPostRedisplay();
}

void CursorUpdate(float x, float y)
{
    // now map to [-1,1]
    fCursorX = 2.0f * (x - 0.5f);
    fCursorY = 2.0f * (y - 0.5f);

    // and clamp to texture aspect
    fCursorX = (fCursorX > xAspect) ? xAspect : fCursorX;
    fCursorX = (fCursorX < -xAspect) ? -xAspect : fCursorX;
    fCursorY = (fCursorY > yAspect) ? yAspect : fCursorY;
    fCursorY = (fCursorY < -yAspect) ? -yAspect : fCursorY;

    // finally, Y is inverted
    fCursorY *= -1.0f;

    // Refresh the Window
    glutPostRedisplay();
}

void MouseMotion(int x, int y)
{
    iCursorX = x;
    iCursorY = y;

    CursorUpdate((GLfloat)x / (GLfloat)(windowWidth-1), 
                 (GLfloat)y / (GLfloat)(windowHeight-1));
}

void SpecialKeys(int key, int x, int y)
{
    // note that we're using top left origin for the integer cursor,
    // as this is compatible with the input from MouseMotion

    switch (key)
    {
    case GLUT_KEY_UP:
        iCursorY--;
        iCursorY = (iCursorY < 0) ? 0 : iCursorY;
        break;
    case GLUT_KEY_RIGHT:
        iCursorX++;
        iCursorX = (iCursorX >= windowWidth) ? (windowWidth-1) : iCursorX;
        break;
    case GLUT_KEY_DOWN:
        iCursorY++;
        iCursorY = (iCursorY >= windowHeight) ? (windowHeight-1) : iCursorY;
        break;
    case GLUT_KEY_LEFT:
        iCursorX--;
        iCursorX = (iCursorX < 0) ? 0 : iCursorX;
        break;
    default:
        break;
    }

    MouseMotion(iCursorX, iCursorY);
}

void ChangeSize(int w, int h)
{
    windowWidth = w;
    windowHeight = h;

    glViewport(0, 0, w, h);

    // where is the cursor in aspect-space (-xAspect,-yAspect) - (+xAspect,+yAspect)?
    GLfloat x = fCursorX / xAspect;
    GLfloat y = fCursorY / yAspect;

    AlterAspect();

    // reposition the cursor with new aspect
    CursorUpdate((x * xAspect * 0.5f) + 0.5f, 
                 (-y * yAspect * 0.5f) + 0.5f);
}

int main(int argc, char* argv[])
{
    glutInit(&argc, argv);
    glutInitDisplayMode(GLUT_DOUBLE | GLUT_RGB | GLUT_DEPTH);
    glutInitWindowSize(windowWidth, windowHeight);
    glutCreateWindow("Floating-Point Texture Demo");
    glutReshapeFunc(ChangeSize);
    glutKeyboardFunc(KeyPressFunc);
    glutSpecialFunc(SpecialKeys);
    glutDisplayFunc(RenderScene);
    glutIdleFunc(RenderScene);
    glutMotionFunc(MouseMotion);

    SetupRC();

    // Create the menus
    shaderMenu = glutCreateMenu(ProcessMenu);
    glutAddMenuEntry("CLAMPED", 1);
    glutAddMenuEntry("TRIVIAL", 2);
    glutAddMenuEntry("IRIS", 3);
    glutAddMenuEntry("WHITEBALANCE", 4);

    textureMenu = glutCreateMenu(ProcessMenu);
    glutAddMenuEntry("Blobbies.exr", 5);
    glutAddMenuEntry("Desk.exr", 6);
    glutAddMenuEntry("GoldenGate.exr", 7);
    glutAddMenuEntry("MtTamWest.exr", 8);
    glutAddMenuEntry("Ocean.exr", 9);
    glutAddMenuEntry("Spirals.exr", 10);
    glutAddMenuEntry("StillLife.exr", 11);
    glutAddMenuEntry("Tree.exr", 12);

    mainMenu = glutCreateMenu(ProcessMenu);
    glutAddSubMenu("Choose tone mapping", shaderMenu);
    glutAddSubMenu("Choose image", textureMenu);
    glutAttachMenu(GLUT_RIGHT_BUTTON);

    glutMainLoop();

    free(fTexels);

    return 0;
}
