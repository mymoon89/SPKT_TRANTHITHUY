// imageproc.cpp
// OpenGL SuperBible, Chapter 17
// Demonstrates convolution via fragment shaders
// Program by Benjamin Lipchak

#include "../../shared/gltools.h"   // OpenGL toolkit
#include "../../shared/glFrame.h"   // OpenGL toolkit

#include <stdio.h>

#define PASS_THROUGH  0
#define BLUR          1
#define SHARPEN       2
#define DILATION      3
#define EROSION       4
#define LAPLACIAN     5
#define SOBEL         6
#define PREWITT       7
#define TOTAL_SHADERS 8

GLuint fShader[TOTAL_SHADERS], progObj[TOTAL_SHADERS];  // shader object names
GLboolean needsValidation[TOTAL_SHADERS];
char *shaderNames[TOTAL_SHADERS] = {"passthrough", "blur", "sharpen", "dilation", "erosion", 
                                    "laplacian", "sobel", "prewitt"};

GLint whichShader = PASS_THROUGH;       // current shader

GLboolean npotTexturesAvailable = GL_FALSE;

GLint windowWidth = 1024;               // window size
GLint windowHeight = 512;
GLint textureWidth = 1024;              // texture size
GLint textureHeight = 512;

GLint mainMenu, shaderMenu, passMenu;   // menu handles

GLint maxTexSize;                       // maximum allowed size for 1D/2D texture

GLfloat cameraPos[] = { 100.0f, 75.0f, 150.0f, 1.0f};
GLdouble cameraZoom = 0.3;

GLfloat lightPos[] = { 140.0f, 250.0f, 140.0f, 1.0f};
GLfloat ambientLight[] = { 0.2f, 0.2f, 0.2f, 1.0f};
GLfloat diffuseLight[] = { 0.7f, 0.7f, 0.7f, 1.0f};

GLfloat lightRotation = 0.0f;
GLfloat texCoordOffsets[18];
GLint numPasses = 2;

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

// Called to draw scene objects
void DrawModels(void)
{
    M3DVector3f lightPosEye;
    M3DMatrix44f mv;

    // Transform light position to eye space
    glPushMatrix();
    glRotatef(lightRotation, 0.0, 1.0, 0.0);
    glGetFloatv(GL_MODELVIEW_MATRIX, mv);
    m3dTransformVector3(lightPosEye, lightPos, mv);
    glLightfv(GL_LIGHT0, GL_POSITION, lightPos);
    glPopMatrix();

    // Draw plane that the objects rest on
    glColor3f(0.0f, 0.0f, 0.90f); // Blue
    glNormal3f(0.0f, 1.0f, 0.0f);
    glBegin(GL_QUADS);
        glVertex3f(-100.0f, -25.0f, -100.0f);
        glVertex3f(-100.0f, -25.0f, 100.0f);		
        glVertex3f(100.0f,  -25.0f, 100.0f);
        glVertex3f(100.0f,  -25.0f, -100.0f);
    glEnd();

    // Draw red cube
    glColor3f(1.0f, 0.0f, 0.0f);
    glutSolidCube(48.0f);

    // Draw green sphere
    glColor3f(0.0f, 1.0f, 0.0f);
    glPushMatrix();
    glTranslatef(-60.0f, 0.0f, 0.0f);
    glutSolidSphere(25.0f, 50, 50);
    glPopMatrix();

    // Draw magenta torus
    glColor3f(1.0f, 0.0f, 1.0f);
    glPushMatrix();
    glTranslatef(0.0f, 0.0f, 60.0f);
    glutSolidTorus(8.0f, 16.0f, 50, 50);
    glPopMatrix();

    // Draw yellow cone
    glColor3f(1.0f, 1.0f, 0.0f);
    glPushMatrix();
    glRotatef(-90.0f, 1.0f, 0.0f, 0.0f);
    glTranslatef(60.0f, 0.0f, -24.0f);
    glutSolidCone(25.0f, 50.0f, 50, 50);
    glPopMatrix();

    // Draw cyan teapot
    glColor3f(0.0f, 1.0f, 1.0f);
    glPushMatrix();
    glTranslatef(0.0f, 0.0f, -60.0f);
    glutSolidTeapot(25.0f);
    glPopMatrix();
}

// Called to draw scene
void RenderScene(void)
{
    GLint pass;

    // Track camera angle
    glMatrixMode(GL_PROJECTION);
    glLoadIdentity();
    if (windowWidth > windowHeight)
    {
        GLdouble ar = (GLdouble)windowWidth / (GLdouble)windowHeight;
        glFrustum(-ar * cameraZoom, ar * cameraZoom, -cameraZoom, cameraZoom, 1.0, 1000.0);
    }
    else
    {
        GLdouble ar = (GLdouble)windowHeight / (GLdouble)windowWidth;
        glFrustum(-cameraZoom, cameraZoom, -ar * cameraZoom, ar * cameraZoom, 1.0, 1000.0);
    }
    glMatrixMode(GL_MODELVIEW);
    glLoadIdentity();
    gluLookAt(cameraPos[0], cameraPos[1], cameraPos[2], 
              0.0f, 0.0f, 0.0f, 0.0f, 1.0f, 0.0f);

    glViewport(0, 0, windowWidth, windowHeight);
    
    glClearColor(0.0f, 0.0f, 0.0f, 1.0f );
    
    // Clear the window with current clearing color
    glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);

    // Validate our shader before first use
    if (needsValidation[whichShader])
    {
        GLint success;

        glValidateProgram(progObj[whichShader]);
        glGetProgramiv(progObj[whichShader], GL_VALIDATE_STATUS, &success);
        if (!success)
        {
            GLchar infoLog[MAX_INFO_LOG_SIZE];
            glGetProgramInfoLog(progObj[whichShader], MAX_INFO_LOG_SIZE, NULL, infoLog);
            fprintf(stderr, "Error in program #%d validation!\n", whichShader);
            fprintf(stderr, "Info log: %s\n", infoLog);
            Sleep(10000);
            exit(0);
        }

        needsValidation[whichShader] = GL_FALSE;
    }
    
    // Draw objects in the scene
    DrawModels();
    
    // Redraw from texture w/ fragment shader
    GLint uniformLoc;
    glUseProgram(progObj[whichShader]);
    uniformLoc = glGetUniformLocation(progObj[whichShader], "sampler0");
    if (uniformLoc != -1)
    {
        glUniform1i(uniformLoc, 0);
    }
    uniformLoc = glGetUniformLocation(progObj[whichShader], "tc_offset");
    if (uniformLoc != -1)
    {
        glUniform2fv(uniformLoc, 9, texCoordOffsets);
    }

    glDisable(GL_DEPTH_TEST);
    glMatrixMode(GL_PROJECTION);
    glLoadIdentity();
    glMatrixMode(GL_MODELVIEW);
    glLoadIdentity();

    for (pass = 0; pass < numPasses; pass++)
    {
        // Copy original scene to texture
        glCopyTexImage2D(GL_TEXTURE_2D, 0, GL_RGBA8, (windowWidth-textureWidth)/2, 
                         (windowHeight-textureHeight)/2, textureWidth, textureHeight, 0);


        glClear(GL_COLOR_BUFFER_BIT);
        glBegin(GL_QUADS);
            glMultiTexCoord2f(GL_TEXTURE0, 0.0f, 0.0f);
            glVertex2f(-((GLfloat)textureWidth / (GLfloat)windowWidth), -((GLfloat)textureHeight / (GLfloat)windowHeight));
            glMultiTexCoord2f(GL_TEXTURE0, 0.0f, 1.0f);
            glVertex2f(-((GLfloat)textureWidth / (GLfloat)windowWidth), ((GLfloat)textureHeight / (GLfloat)windowHeight));
            glMultiTexCoord2f(GL_TEXTURE0, 1.0f, 1.0f);
            glVertex2f(((GLfloat)textureWidth / (GLfloat)windowWidth), ((GLfloat)textureHeight / (GLfloat)windowHeight));
            glMultiTexCoord2f(GL_TEXTURE0, 1.0f, 0.0f);
            glVertex2f(((GLfloat)textureWidth / (GLfloat)windowWidth), -((GLfloat)textureHeight / (GLfloat)windowHeight));
        glEnd();
    }

    glEnable(GL_DEPTH_TEST);

    glUseProgram(0);

    if (glGetError() != GL_NO_ERROR)
        fprintf(stderr, "GL Error!\n");

    // Flush drawing commands
    glutSwapBuffers();
}

// This function does any needed initialization on the rendering
// context. 
void SetupRC()
{
    GLint i;

    fprintf(stdout, "Image Processing Demo\n\n");

    // Make sure required functionality is available!
    if (!GLEE_VERSION_2_0 && (!GLEE_ARB_fragment_shader || 
                              !GLEE_ARB_shader_objects || 
                              !GLEE_ARB_shading_language_100))
    {
        fprintf(stderr, "GLSL extensions not available!\n");
        Sleep(2000);
        exit(0);
    }

    if (GLEE_VERSION_2_0 || GLEE_ARB_texture_non_power_of_two)
    {
        npotTexturesAvailable = GL_TRUE;
    }
    else
    {
        fprintf(stderr, "Neither OpenGL 2.0 nor GL_ARB_texture_non_power_of_two extension\n");
        fprintf(stderr, "is available!  Shadow map will be lower resolution (lower quality).\n\n");
        Sleep(2000);
    }

    // Make sure we have multitexture and cube maps!
    if (!GLEE_VERSION_1_3 && (!GLEE_ARB_multitexture || 
                              !GLEE_ARB_texture_cube_map))
    {
        fprintf(stderr, "Neither OpenGL 1.3 nor necessary"
                        " extensions are available!\n");
        Sleep(2000);
        exit(0);
    }

    glGetIntegerv(GL_MAX_TEXTURE_SIZE, &maxTexSize);

    fprintf(stdout, "Controls:\n");
    fprintf(stdout, "\tRight-click for menu\n\n");
    fprintf(stdout, "\tR/L arrows\t+/- rotate lights for others shaders\n\n");
    fprintf(stdout, "\tx/X\t\tMove +/- in x direction\n");
    fprintf(stdout, "\ty/Y\t\tMove +/- in y direction\n");
    fprintf(stdout, "\tz/Z\t\tMove +/- in z direction\n\n");
    fprintf(stdout, "\tq\t\tExit demo\n\n");
    
    // Black background
    glClearColor(0.0f, 0.0f, 0.0f, 1.0f );

    // Misc. state
    glEnable(GL_DEPTH_TEST);
    glDepthFunc(GL_LEQUAL);
    glShadeModel(GL_SMOOTH);
    glEnable(GL_LIGHTING);
    glEnable(GL_COLOR_MATERIAL);
    glEnable(GL_NORMALIZE);
    glEnable(GL_LIGHT0);
    glLightfv(GL_LIGHT0, GL_AMBIENT, ambientLight);
    glLightfv(GL_LIGHT0, GL_DIFFUSE, diffuseLight);

    // Texture state
    glActiveTexture(GL_TEXTURE0);
    glBindTexture(GL_TEXTURE_2D, 0);
    glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MIN_FILTER, GL_LINEAR);
    glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MIN_FILTER, GL_LINEAR);
    glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_S, GL_CLAMP_TO_EDGE);
    glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_T, GL_CLAMP_TO_EDGE);

    // Load and compile shaders
    for (i = 0; i < TOTAL_SHADERS; i++)
    {
        PrepareShader(i);
    }
}

void ProcessMenu(int value)
{
    switch(value)
    {
    case 1:
    case 2:
    case 3:
    case 4:
    case 5:
        numPasses = value;
        {
            char menuEntry[128];
            sprintf(menuEntry, "Choose number of passes (currently %d)", numPasses);
            glutSetMenu(mainMenu);
            glutChangeToSubMenu(2, menuEntry, passMenu);
        }
        break;

    default:
        whichShader = value - 6;
        {
            char menuEntry[128];
            sprintf(menuEntry, "Choose fragment shader (currently \"%s\")", shaderNames[whichShader]);
            glutSetMenu(mainMenu);
            glutChangeToSubMenu(1, menuEntry, shaderMenu);
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
    case 'x':
        cameraPos[0] += 5.0f;
        break;
    case 'X':
        cameraPos[0] -= 5.0f;
        break;
    case 'y':
        cameraPos[1] += 5.0f;
        break;
    case 'Y':
        cameraPos[1] -= 5.0f;
        break;
    case 'z':
        cameraPos[2] += 5.0f;
        break;
    case 'Z':
        cameraPos[2] -= 5.0f;
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
    case GLUT_KEY_LEFT:
        lightRotation -= 5.0f;
        break;
    case GLUT_KEY_RIGHT:
        lightRotation += 5.0f;
        break;
    case GLUT_KEY_UP:
        cameraPos[1] += 5.0f;
        break;
    case GLUT_KEY_DOWN:
        cameraPos[1] -= 5.0f;
        break;
    default:
        break;
    }

    // Refresh the Window
    glutPostRedisplay();
}

void ChangeSize(int w, int h)
{
    GLint i, j;
    GLfloat xInc, yInc;

    windowWidth = textureWidth = w;
    windowHeight = textureHeight = h;

    // find largest power-of-two texture smaller than window
    if (!npotTexturesAvailable)
    {
        // Find the largest power of two that will fit in window.

        // Try each width until we get one that's too big
        i = 0;
        while ((1 << i) <= textureWidth)
            i++;
        textureWidth = (1 << (i-1));

        // Now for height
        i = 0;
        while ((1 << i) <= textureHeight)
            i++;
        textureHeight = (1 << (i-1));
    }

    if (textureWidth > maxTexSize)
    {
        textureWidth = maxTexSize;
    }
    if (textureHeight > maxTexSize)
    {
        textureHeight = maxTexSize;
    }

    xInc = 1.0f / (GLfloat)textureWidth;
    yInc = 1.0f / (GLfloat)textureHeight;

    for (i = 0; i < 3; i++)
    {
        for (j = 0; j < 3; j++)
        {
            texCoordOffsets[(((i*3)+j)*2)+0] = (-1.0f * xInc) + ((GLfloat)i * xInc);
            texCoordOffsets[(((i*3)+j)*2)+1] = (-1.0f * yInc) + ((GLfloat)j * yInc);
        }
    }
}

int main(int argc, char* argv[])
{
    GLint i;

    glutInit(&argc, argv);
    glutInitDisplayMode(GLUT_DOUBLE | GLUT_RGB | GLUT_DEPTH);
    glutInitWindowSize(windowWidth, windowHeight);
    glutCreateWindow("Image Processing Demo");
    glutReshapeFunc(ChangeSize);
    glutKeyboardFunc(KeyPressFunc);
    glutSpecialFunc(SpecialKeys);
    glutDisplayFunc(RenderScene);

    SetupRC();

    // Create the menus
    shaderMenu = glutCreateMenu(ProcessMenu);
    for (i = 0; i < TOTAL_SHADERS; i++)
    {
        char menuEntry[128];
        sprintf(menuEntry, "\"%s\"", shaderNames[i]);
        glutAddMenuEntry(menuEntry, 6+i);
    }

    passMenu = glutCreateMenu(ProcessMenu);
    glutAddMenuEntry("1", 1);
    glutAddMenuEntry("2", 2);
    glutAddMenuEntry("3", 3);
    glutAddMenuEntry("4", 4);
    glutAddMenuEntry("5", 5);

    mainMenu = glutCreateMenu(ProcessMenu);
    {
        char menuEntry[128];
        sprintf(menuEntry, "Choose fragment shader (currently \"%s\")", shaderNames[0]);
        glutAddSubMenu(menuEntry, shaderMenu);
        sprintf(menuEntry, "Choose number of passes (currently 2)");
        glutAddSubMenu(menuEntry, passMenu);
    }
    glutAttachMenu(GLUT_RIGHT_BUTTON);

    glutMainLoop();

    if (glDeleteProgram && glDeleteShader)
    {
        for (i = 0; i < TOTAL_SHADERS; i++)
        {
            glDeleteProgram(progObj[i]);
            glDeleteShader(fShader[i]);
        }
    }

    return 0;
}
