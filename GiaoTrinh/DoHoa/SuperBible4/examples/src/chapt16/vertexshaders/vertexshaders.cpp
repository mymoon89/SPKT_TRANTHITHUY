// vertexshaders.cpp
// OpenGL SuperBible, Chapter 16
// Demonstrates vertex shaders
// Program by Benjamin Lipchak

#include "../../shared/gltools.h"   // OpenGL toolkit
#include "../../shared/glFrame.h"   // OpenGL toolkit

#include <stdio.h>

#define SIMPLE        0
#define DIFFUSE       1
#define SPECULAR      2
#define SEPSPEC       3
#define TEXSPEC       4
#define THREELIGHTS   5
#define FOGCOORD      6
#define FOG           7
#define PTSIZE        8
#define STRETCH       9
#define TOTAL_SHADERS 10

GLuint vShader[TOTAL_SHADERS], progObj[TOTAL_SHADERS];  // shader object names
GLboolean needsValidation[TOTAL_SHADERS];
char *shaderNames[TOTAL_SHADERS] = {"simple", "diffuse", "specular", "sepspec", "texspec", 
                                    "3lights", "fogcoord", "fog", "ptsize", "stretch"};

GLint whichShader = SIMPLE;             // current shader

GLint windowWidth = 1024;               // window size
GLint windowHeight = 768;

GLint mainMenu, shaderMenu;             // menu handles

GLint maxTexSize;                       // maximum allowed size for 1D/2D texture

GLfloat cameraPos[] = { 100.0f, 75.0f, 150.0f, 1.0f};
GLdouble cameraZoom = 0.4;

GLfloat lightPos0[] = { 140.0f, 250.0f, 140.0f, 1.0f};
GLfloat lightPos1[] = { -140.0f, 250.0f, 140.0f, 1.0f};
GLfloat lightPos2[] = { 0.0f, 250.0f, -200.0f, 1.0f};

GLfloat squashStretch[] = {1.0f, 1.5f, 0.75f, 1.0f};
GLfloat fogColor[] = {0.5f, 0.8f, 0.5f, 1.0f};
GLfloat lightRotation = 0.0f;
GLfloat density = 0.005f;

#define MAX_INFO_LOG_SIZE 2048

// Create 1D texture to map NdotH to NdotH^128
GLvoid CreatePowMap(GLfloat r, GLfloat g, GLfloat b)
{
    GLfloat texels[512 * 4];
    GLint texSize = (maxTexSize > 512) ? 512 : maxTexSize;
    GLint x;

    for (x = 0; x < texSize; x++)
    {
        // Incoming N.H has been scaled by 8 and biased by -7 to take better
        // advantage of the texture space.  Otherwise, the texture will be
        // entirely zeros until ~7/8 of the way into it.  This way, we expand
        // the useful 1/8 of the range and get better precision.
        texels[x*4+0] = r * (float)pow(((double)x / (double)(texSize-1)) * 0.125f + 0.875f, 128.0);
        texels[x*4+1] = g * (float)pow(((double)x / (double)(texSize-1)) * 0.125f + 0.875f, 128.0);
        texels[x*4+2] = b * (float)pow(((double)x / (double)(texSize-1)) * 0.125f + 0.875f, 128.0);
        texels[x*4+3] = 1.0f;
    }
    // Make sure the first texel is exactly zero.  Most
    // incoming texcoords will clamp to this texel.
    texels[0] = texels[1] = texels[2] = 0.0f;

    glTexImage1D(GL_TEXTURE_1D, 0, GL_RGBA16, texSize, 0, GL_RGBA, GL_FLOAT, texels);
}

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
    GLchar *vsString;
    const GLchar *vsStringPtr[1];
    GLint success;

    // Create shader objects and specify shader text
    sprintf(fullFileName, "./shaders/%s.vs", shaderNames[shaderNum]);
    vsString = LoadShaderText(fullFileName);
    if (!vsString)
    {
        fprintf(stderr, "Unable to load \"%s\"\n", fullFileName);
        Sleep(5000);
        exit(0);
    }
    vShader[shaderNum] = glCreateShader(GL_VERTEX_SHADER);
    vsStringPtr[0] = vsString;
    glShaderSource(vShader[shaderNum], 1, vsStringPtr, NULL);
    free(vsString);

    // Compile shaders and check for any errors
    glCompileShader(vShader[shaderNum]);
    glGetShaderiv(vShader[shaderNum], GL_COMPILE_STATUS, &success);
    if (!success)
    {
        GLchar infoLog[MAX_INFO_LOG_SIZE];
        glGetShaderInfoLog(vShader[shaderNum], MAX_INFO_LOG_SIZE, NULL, infoLog);
        fprintf(stderr, "Error in vertex shader #%d compilation!\n", shaderNum);
        fprintf(stderr, "Info log: %s\n", infoLog);
        Sleep(10000);
        exit(0);
    }

    // Create program object, attach shader, then link
    progObj[shaderNum] = glCreateProgram();
    glAttachShader(progObj[shaderNum], vShader[shaderNum]);

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

    // Program object has changed, so we should revalidate
    needsValidation[shaderNum] = GL_TRUE;
}

// Called to draw scene objects
void DrawModels(void)
{
    M3DVector3f lightPosEye0, lightPosEye1, lightPosEye2;
    M3DMatrix44f mv;

    // Transform light position to eye space
    glPushMatrix();
    glRotatef(lightRotation, 0.0, 1.0, 0.0);
    glGetFloatv(GL_MODELVIEW_MATRIX, mv);
    m3dTransformVector3(lightPosEye0, lightPos0, mv);
    if (whichShader == THREELIGHTS)
    {
        m3dTransformVector3(lightPosEye1, lightPos1, mv);
        m3dTransformVector3(lightPosEye2, lightPos2, mv);
    }
    glPopMatrix();

    GLint uniformLoc = glGetUniformLocation(progObj[whichShader], "lightPos[0]");
    if (uniformLoc != -1)
    {
        glUniform3fv(uniformLoc, 1, lightPosEye0);
    }
    uniformLoc = glGetUniformLocation(progObj[whichShader], "lightPos[1]");
    if (uniformLoc != -1)
    {
        glUniform3fv(uniformLoc, 1, lightPosEye1);
    }
    uniformLoc = glGetUniformLocation(progObj[whichShader], "lightPos[2]");
    if (uniformLoc != -1)
    {
        glUniform3fv(uniformLoc, 1, lightPosEye2);
    }
    uniformLoc = glGetUniformLocation(progObj[whichShader], "squashStretch");
    if (uniformLoc != -1)
    {
        glUniform3fv(uniformLoc, 1, squashStretch);
    }
    uniformLoc = glGetUniformLocation(progObj[whichShader], "density");
    if (uniformLoc != -1)
    {
        glUniform1f(uniformLoc, density);
    }

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

    if (whichShader == STRETCH)
    {
        // Cone and teapot are rotated such that their
        // Y and Z squash scales must be switched
        GLfloat rotatedSquashStretch[4];

        rotatedSquashStretch[0] = squashStretch[0];
        rotatedSquashStretch[1] = squashStretch[2];
        rotatedSquashStretch[2] = squashStretch[1];
        rotatedSquashStretch[3] = squashStretch[3];

        GLint uniformLoc = glGetUniformLocation(progObj[whichShader], "squashStretch");
        if (uniformLoc != -1)
        {
            glUniform3fv(uniformLoc, 1, rotatedSquashStretch);
        }
    }

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
    
    if ((whichShader == FOGCOORD) || (whichShader == FOG))
    {
        // Use a green-gray color for fog
        glClearColor(fogColor[0], fogColor[1], fogColor[2], fogColor[3]);
        glFogf(GL_FOG_DENSITY, density);
    }
    else
    {
        glClearColor(0.0f, 0.0f, 0.0f, 1.0f );
    }
    
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

    fprintf(stdout, "Vertex Shaders Demo\n\n");

    // Make sure required functionality is available!
    if (!GLEE_VERSION_2_0 && (!GLEE_ARB_vertex_shader || 
                              !GLEE_ARB_shader_objects || 
                              !GLEE_ARB_shading_language_100))
    {
        fprintf(stderr, "GLSL extensions not available!\n");
        Sleep(2000);
        exit(0);
    }

    // Make sure we have multitexture, cube maps, and texenv add!
    if (!GLEE_VERSION_1_3 && (!GLEE_ARB_multitexture || 
                              !GLEE_ARB_texture_cube_map ||
                              !GLEE_ARB_texture_env_add))
    {
        fprintf(stderr, "Neither OpenGL 1.3 nor necessary"
                        " extensions are available!\n");
        Sleep(2000);
        exit(0);
    }

    glGetIntegerv(GL_MAX_TEXTURE_SIZE, &maxTexSize);

    fprintf(stdout, "Controls:\n");
    fprintf(stdout, "\tRight-click for menu\n\n");
    fprintf(stdout, "\tR/L arrows\t+/- fog density for \"fog\" shader\n");
    fprintf(stdout, "\tR/L arrows\t+/- rotate lights for others shaders\n\n");
    fprintf(stdout, "\tx/X\t\tMove +/- in x direction, stretch for \"stretch\" shader\n");
    fprintf(stdout, "\ty/Y\t\tMove +/- in y direction, stretch for \"stretch\" shader\n");
    fprintf(stdout, "\tz/Z\t\tMove +/- in z direction, stretch for \"stretch\" shader\n\n");
    fprintf(stdout, "\tq\t\tExit demo\n\n");
    
    // Black background
    glClearColor(0.0f, 0.0f, 0.0f, 1.0f );

    // Misc. state
    glEnable(GL_DEPTH_TEST);
    glDepthFunc(GL_LEQUAL);
    glShadeModel(GL_SMOOTH);
    glFogfv(GL_FOG_COLOR, fogColor);
    glFogi(GL_FOG_MODE, GL_EXP2);
    glFogi(GL_FOG_COORD_SRC, GL_FOG_COORD);
    glBlendFunc(GL_SRC_ALPHA, GL_ONE_MINUS_SRC_ALPHA);

    // Texture state
    glActiveTexture(GL_TEXTURE3);
    glTexEnvi(GL_TEXTURE_ENV, GL_TEXTURE_ENV_MODE, GL_ADD);
    glBindTexture(GL_TEXTURE_1D, 3);
    glTexParameteri(GL_TEXTURE_1D, GL_TEXTURE_MIN_FILTER, GL_LINEAR);
    glTexParameteri(GL_TEXTURE_1D, GL_TEXTURE_MIN_FILTER, GL_LINEAR);
    glTexParameteri(GL_TEXTURE_1D, GL_TEXTURE_WRAP_S, GL_CLAMP_TO_EDGE);
    CreatePowMap(0.25, 0.25, 1.0);
    glActiveTexture(GL_TEXTURE2);
    glTexEnvi(GL_TEXTURE_ENV, GL_TEXTURE_ENV_MODE, GL_ADD);
    glBindTexture(GL_TEXTURE_1D, 2);
    glTexParameteri(GL_TEXTURE_1D, GL_TEXTURE_MIN_FILTER, GL_LINEAR);
    glTexParameteri(GL_TEXTURE_1D, GL_TEXTURE_MIN_FILTER, GL_LINEAR);
    glTexParameteri(GL_TEXTURE_1D, GL_TEXTURE_WRAP_S, GL_CLAMP_TO_EDGE);
    CreatePowMap(0.25, 1.0, 0.25);
    glActiveTexture(GL_TEXTURE1);
    glTexEnvi(GL_TEXTURE_ENV, GL_TEXTURE_ENV_MODE, GL_ADD);
    glBindTexture(GL_TEXTURE_1D, 1);
    glTexParameteri(GL_TEXTURE_1D, GL_TEXTURE_MIN_FILTER, GL_LINEAR);
    glTexParameteri(GL_TEXTURE_1D, GL_TEXTURE_MIN_FILTER, GL_LINEAR);
    glTexParameteri(GL_TEXTURE_1D, GL_TEXTURE_WRAP_S, GL_CLAMP_TO_EDGE);
    CreatePowMap(1.0, 0.25, 0.25);
    glActiveTexture(GL_TEXTURE0);
    glTexEnvi(GL_TEXTURE_ENV, GL_TEXTURE_ENV_MODE, GL_ADD);
    glBindTexture(GL_TEXTURE_1D, 0);
    glTexParameteri(GL_TEXTURE_1D, GL_TEXTURE_MIN_FILTER, GL_LINEAR);
    glTexParameteri(GL_TEXTURE_1D, GL_TEXTURE_MIN_FILTER, GL_LINEAR);
    glTexParameteri(GL_TEXTURE_1D, GL_TEXTURE_WRAP_S, GL_CLAMP_TO_EDGE);
    CreatePowMap(1.0, 1.0, 1.0);

    // Load and compile shaders
    for (i = 0; i < TOTAL_SHADERS; i++)
    {
        PrepareShader(i);
    }

    // Install first shader
    glUseProgram(progObj[whichShader]);
}

void ProcessMenu(int value)
{
    whichShader = value - 1;
    {
        char menuEntry[128];
        sprintf(menuEntry, "Choose vertex shader (currently \"%s\")", shaderNames[whichShader]);
        glutSetMenu(mainMenu);
        glutChangeToSubMenu(1, menuEntry, shaderMenu);
    }
    glUseProgram(progObj[whichShader]);
    if (whichShader == SEPSPEC)
    {
        // Separate specular shader needs
        // primary and secondary colors summed
        glEnable(GL_COLOR_SUM);
    }
    else
    {
        glDisable(GL_COLOR_SUM);
    }
    if (whichShader == FOGCOORD)
    {
        // Fogcoord shader needs fixed
        // functionality fog enabled
        glEnable(GL_FOG);
    }
    else
    {
        glDisable(GL_FOG);
    }
    if (whichShader == PTSIZE)
    {
        // Fogcoord shader needs fixed
        // functionality fog enabled
        glPolygonMode(GL_FRONT_AND_BACK, GL_POINT);
        glEnable(GL_VERTEX_PROGRAM_POINT_SIZE);
        glEnable(GL_POINT_SMOOTH);
        glEnable(GL_BLEND);
    }
    else
    {
        glPolygonMode(GL_FRONT_AND_BACK, GL_FILL);
        glDisable(GL_VERTEX_PROGRAM_POINT_SIZE);
        glDisable(GL_POINT_SMOOTH);
        glDisable(GL_BLEND);
    }
    // Disable all texturing, then reenable as needed
    glActiveTexture(GL_TEXTURE3);
    glDisable(GL_TEXTURE_1D);
    glActiveTexture(GL_TEXTURE2);
    glDisable(GL_TEXTURE_1D);
    glActiveTexture(GL_TEXTURE1);
    glDisable(GL_TEXTURE_1D);
    glActiveTexture(GL_TEXTURE0);
    glDisable(GL_TEXTURE_1D);
    if ((whichShader == TEXSPEC) || (whichShader == STRETCH))
    {
        // texture specular shaders needs 1D pow map
        glActiveTexture(GL_TEXTURE0);
        glEnable(GL_TEXTURE_1D);
    }
    else if (whichShader == THREELIGHTS)
    {
        // 3 lights shader needs 1D pow map on all 3 units
        glActiveTexture(GL_TEXTURE3);
        glEnable(GL_TEXTURE_1D);
        glActiveTexture(GL_TEXTURE2);
        glEnable(GL_TEXTURE_1D);
        glActiveTexture(GL_TEXTURE1);
        glEnable(GL_TEXTURE_1D);
        glActiveTexture(GL_TEXTURE0);
    }

    // Refresh the Window
    glutPostRedisplay();
}

void KeyPressFunc(unsigned char key, int x, int y)
{
    switch (key)
    {
    case 'x':
        if (whichShader == STRETCH)
            squashStretch[0] += 0.01f;
        else
            cameraPos[0] += 5.0f;
        break;
    case 'X':
        if (whichShader == STRETCH)
            squashStretch[0] -= 0.01f;
        else
            cameraPos[0] -= 5.0f;
        break;
    case 'y':
        if (whichShader == STRETCH)
            squashStretch[1] += 0.01f;
        else
            cameraPos[1] += 5.0f;
        break;
    case 'Y':
        if (whichShader == STRETCH)
            squashStretch[1] -= 0.01f;
        else
            cameraPos[1] -= 5.0f;
        break;
    case 'z':
        if (whichShader == STRETCH)
            squashStretch[2] += 0.01f;
        else
            cameraPos[2] += 5.0f;
        break;
    case 'Z':
        if (whichShader == STRETCH)
            squashStretch[2] -= 0.01f;
        else
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
        if ((whichShader == FOGCOORD) || 
            (whichShader == FOG))
            density -= 0.0005f;
        else
            lightRotation -= 5.0f;
        break;
    case GLUT_KEY_RIGHT:
        if ((whichShader == FOGCOORD) || 
            (whichShader == FOG))
            density += 0.0005f;
        else
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

    if (density < 0.0f)
        density = 0.0f;

    // Refresh the Window
    glutPostRedisplay();
}

void ChangeSize(int w, int h)
{
    windowWidth = w;
    windowHeight = h;
}

int main(int argc, char* argv[])
{
    GLint i;

    glutInit(&argc, argv);
    glutInitDisplayMode(GLUT_DOUBLE | GLUT_RGB | GLUT_DEPTH);
    glutInitWindowSize(windowWidth, windowHeight);
    glutCreateWindow("Vertex Shaders Demo");
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
        glutAddMenuEntry(menuEntry, 1+i);
    }

    mainMenu = glutCreateMenu(ProcessMenu);
    {
        char menuEntry[128];
        sprintf(menuEntry, "Choose vertex shader (currently \"%s\")", shaderNames[0]);
        glutAddSubMenu(menuEntry, shaderMenu);
    }
    glutAttachMenu(GLUT_RIGHT_BUTTON);

    glutMainLoop();

    if (glDeleteShader && glDeleteProgram)
    {
        for (i = 0; i < TOTAL_SHADERS; i++)
        {
            glDeleteProgram(progObj[i]);
            glDeleteShader(vShader[i]);
        }
    }

    return 0;
}
