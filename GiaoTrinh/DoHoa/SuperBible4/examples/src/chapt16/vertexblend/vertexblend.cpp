// vertexblend.cpp
// OpenGL SuperBible, Chapter 16
// Demonstrates vertex blending
// Program by Benjamin Lipchak

#include "../../shared/gltools.h"   // OpenGL toolkit
#include "../../shared/glFrame.h"   // OpenGL toolkit

#include <stdio.h>

GLboolean useBlending = GL_TRUE;
GLboolean showBones = GL_FALSE;

#define TOTAL_SHADERS 1
GLuint vShader[TOTAL_SHADERS], progObj[TOTAL_SHADERS];  // shader object names
GLboolean needsValidation[TOTAL_SHADERS];
char *shaderNames[TOTAL_SHADERS] = {"skinning"};

GLint lightPosLoc, mv2Loc, mv2ITLoc;    // locations for uniforms
GLint weightLoc;                        // locations for attribs

GLint windowWidth = 1024;               // window size
GLint windowHeight = 768;

GLint mainMenu;                         // menu handles

GLint maxTexSize;                       // maximum allowed size for 1D/2D texture

GLfloat cameraPos[] = { 50.0f, 75.0f, 50.0f, 1.0f};
GLdouble cameraZoom = 0.4;

GLfloat lightPos[] =  { -50.0f, 100.0f, 50.0f, 1.0f};

GLfloat elbowBend = 45.0f;
GLfloat sphereOfInfluence = 1.0f;       // how much of each limb gets blended

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

    // Create shader objects and specify shader text

    const GLchar *vsStringPtr[1];
    GLint success;

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

    lightPosLoc = glGetUniformLocation(progObj[0], "lightPos");
    mv2Loc = glGetUniformLocation(progObj[0], "mv2");
    mv2ITLoc = glGetUniformLocation(progObj[0], "mv2IT");
    weightLoc = glGetAttribLocation(progObj[0], "weight");

    // Program object has changed, so we should revalidate
    needsValidation[shaderNum] = GL_TRUE;
}

// Draw a cylinder with supplied dimensions
void DrawCylinder(GLfloat length, GLfloat diameter1, GLfloat diameter2, 
                  GLfloat startWeight, GLfloat endWeight)
{
    int numFacets = 50;
    int numSections = 50;
    GLfloat angleIncr = (2.0f * 3.14159f) / (float)numFacets;
    GLfloat sectionLength = length / numSections;
    GLfloat wEnd, influenceStart;
    int i, j;

    // Determine where our influence starts for this limb
    if (startWeight == 0.5f)
    {
        influenceStart = sphereOfInfluence;
    }
    else
    {
        influenceStart = 1.0f - sphereOfInfluence;
    }

    // Skin
    for (i = 0; i < numFacets; i++)
    {
        // Calculate geometry for this facet
        GLfloat angle1 = i * angleIncr;
        GLfloat angle2 = ((i+1)%numFacets) * angleIncr;
        GLfloat y1AtFirstEnd = sin(angle1) * diameter1;
        GLfloat y1AtOtherEnd = sin(angle1) * diameter2;
        GLfloat z1AtFirstEnd = cos(angle1) * diameter1;
        GLfloat z1AtOtherEnd = cos(angle1) * diameter2;
        GLfloat y2AtFirstEnd = sin(angle2) * diameter1;
        GLfloat y2AtOtherEnd = sin(angle2) * diameter2;
        GLfloat z2AtFirstEnd = cos(angle2) * diameter1;
        GLfloat z2AtOtherEnd = cos(angle2) * diameter2;
        GLfloat n1y = y1AtFirstEnd;
        GLfloat n1z = z1AtFirstEnd;
        GLfloat n2y = y2AtFirstEnd;
        GLfloat n2z = z2AtFirstEnd;

        // One strip per facet
        glBegin(GL_QUAD_STRIP);

        glVertexAttrib1f(weightLoc, useBlending ? startWeight : 1.0f);
        glNormal3f(0.0f, n1y, n1z);
        glVertex3f(0.0f, y1AtFirstEnd, z1AtFirstEnd);
        glNormal3f(0.0f, n2y, n2z);
        glVertex3f(0.0f, y2AtFirstEnd, z2AtFirstEnd);

        for (j = 0; j < numSections; j++)
        {
            // Calculate geometry for end of this quad
            GLfloat paramEnd = (float)(j+1) / (float)numSections;
            GLfloat lengthEnd = paramEnd * length;
            GLfloat y1End = y1AtFirstEnd + (paramEnd * (y1AtOtherEnd - y1AtFirstEnd));
            GLfloat z1End = z1AtFirstEnd + (paramEnd * (z1AtOtherEnd - z1AtFirstEnd));
            GLfloat y2End = y2AtFirstEnd + (paramEnd * (y2AtOtherEnd - y2AtFirstEnd));
            GLfloat z2End = z2AtFirstEnd + (paramEnd * (z2AtOtherEnd - z2AtFirstEnd));

            // Calculate vertex weights
            if (!useBlending)
            {
                wEnd = 1.0f;
            }
            else if (paramEnd <= influenceStart)
            {
                // Map params [0,influenceStart] to weights [0,1]
                GLfloat p = (paramEnd * (1.0f/influenceStart));

                // We're in the first half of the cylinder: startWeight -> 1
                wEnd = startWeight + p * (1.0f - startWeight);
            }
            else
            {
                // Map params [influenceStart,1] to weights [0,1]
                GLfloat p = (paramEnd-influenceStart) * (1.0f/(1.0f-influenceStart));

                // We're in the second half of the cylinder: 1 -> endWeight
                wEnd = 1.0f + p * (endWeight - 1.0f);
            }

            glVertexAttrib1f(weightLoc, wEnd);
            glNormal3f(0.0f, n1y, n1z);
            glVertex3f(lengthEnd, y1End, z1End);
            glNormal3f(0.0f, n2y, n2z);
            glVertex3f(lengthEnd, y2End, z2End);
        }

        // End facet strip
        glEnd();
    }

    if (showBones)
    {
        // Skeleton
        glDisable(GL_DEPTH_TEST);
        glEnable(GL_BLEND);
        glColor4f(1.0f, 1.0f, 1.0f, 0.75f);
        glNormal3f(0.0f, 1.0f, 0.0f);
        glVertexAttrib1f(weightLoc, 1.0f);
        glBegin(GL_LINES);
            glVertex3f(0.0f, 0.0f, 0.0f);
            glVertex3f(length, 0.0f, 0.0f);
        glEnd();
        glColor3f(1.0f, 1.0f, 0.0f);
        glBegin(GL_POINTS);
            glVertex3f(0.0f, 0.0f, 0.0f);
            glVertex3f(length, 0.0f, 0.0f);
        glEnd();
        glEnable(GL_DEPTH_TEST);
        glDisable(GL_BLEND);
    }
}

// Called to draw scene objects
void DrawModels(void)
{
    M3DVector3f lightPosEye;
    M3DMatrix44f mv, mv2;
    M3DMatrix44f mv2IT_4x4;
    GLfloat mv2IT_3x3[9];
    GLint i;

    // Transform light position to eye space
    glGetFloatv(GL_MODELVIEW_MATRIX, mv);
    m3dTransformVector3(lightPosEye, lightPos, mv);

    glUniform3fv(lightPosLoc, 1, lightPosEye);

    // Setup modelview matrices for upper arm
    glPushMatrix();
    glRotatef(elbowBend, 0.0f, 0.0f, 1.0f);
    glTranslatef(-50.0f, 0.0f, 0.0f);
    glGetFloatv(GL_MODELVIEW_MATRIX, mv2);
    glPopMatrix();
    glTranslatef(-50.0f, 0.0f, 0.0f);

    glUniformMatrix4fv(mv2Loc, 1, GL_FALSE, mv2);

    m3dInvertMatrix44(mv2IT_4x4, mv2);

    // Take upper left 3x3 for 2nd normal matrix
    for (i = 0; i < 9; i++)
    {
        mv2IT_3x3[i] = mv2IT_4x4[((i/3)*4)+(i%3)];
    }
    glUniformMatrix3fv(mv2ITLoc, 1, GL_TRUE, mv2IT_3x3);

    // Draw upper arm cylinder
    glColor3f(0.0f, 0.0f, 0.90f);      // Blue
    // 50 long, 10 shoulder, 9 elbow, with weights applied to second half
    DrawCylinder(50.0f, 15.0f, 9.0f, 1.0f, 0.5f);

    // Setup modelview matrices for forearm
    glTranslatef(50.0f, 0.0f, 0.0f);
    glPushMatrix();
    glGetFloatv(GL_MODELVIEW_MATRIX, mv2);
    glPopMatrix();
    glRotatef(elbowBend, 0.0f, 0.0f, 1.0f);

    glUniformMatrix4fv(mv2Loc, 1, GL_FALSE, mv2);

    m3dInvertMatrix44(mv2IT_4x4, mv2);

    // Take upper left 3x3 for 2nd normal matrix
    for (i = 0; i < 9; i++)
    {
        mv2IT_3x3[i] = mv2IT_4x4[((i/3)*4)+(i%3)];
    }
    glUniformMatrix3fv(mv2ITLoc, 1, GL_TRUE, mv2IT_3x3);

    // Draw forearm cylinder
    glColor3f(0.9f, 0.0f, 0.0f);       // Red
    // 40 long, 9 elbow, 5 wrist, with weights applied to first half
    DrawCylinder(40.0f, 9.0f, 5.0f, 0.5f, 1.0f);
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
    
    // Clear the window with current clearing color
    glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);

    // Validate our shader before first use
    if (needsValidation[0])
    {
        GLint success;

        glValidateProgram(progObj[0]);
        glGetProgramiv(progObj[0], GL_VALIDATE_STATUS, &success);
        if (!success)
        {
            GLchar infoLog[MAX_INFO_LOG_SIZE];
            glGetProgramInfoLog(progObj[0], MAX_INFO_LOG_SIZE, NULL, infoLog);
            fprintf(stderr, "Error in program validation!\n");
            fprintf(stderr, "Info log: %s\n", infoLog);
            Sleep(10000);
            exit(0);
        }

        needsValidation[0] = GL_FALSE;
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

    fprintf(stdout, "Vertex Blending Demo\n\n");

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
    fprintf(stdout, "\tL/R arrows\tChange sphere of influence\n");
    fprintf(stdout, "\tU/D arrows\tChange angle of forearm\n\n");
    fprintf(stdout, "\tx/X\t\tMove  +/- in x direction\n");
    fprintf(stdout, "\ty/Y\t\tMove  +/- in y direction\n");
    fprintf(stdout, "\tz/Z\t\tMove  +/- in z direction\n\n");
    fprintf(stdout, "\tq\t\tExit demo\n\n");
    
    // Black background
    glClearColor(0.0f, 0.0f, 0.0f, 1.0f );

    // Hidden surface removal
    glEnable(GL_DEPTH_TEST);
    glDepthFunc(GL_LEQUAL);

    // Misc.
    glShadeModel(GL_SMOOTH);
    glBlendFunc(GL_SRC_ALPHA, GL_ONE_MINUS_SRC_ALPHA);
    glPointSize(10.0f);
    glLineWidth(5.0f);

    // Texture state
    glTexEnvi(GL_TEXTURE_ENV, GL_TEXTURE_ENV_MODE, GL_ADD);
    glBindTexture(GL_TEXTURE_1D, 0);
    glTexParameteri(GL_TEXTURE_1D, GL_TEXTURE_MIN_FILTER, GL_LINEAR);
    glTexParameteri(GL_TEXTURE_1D, GL_TEXTURE_MIN_FILTER, GL_LINEAR);
    glTexParameteri(GL_TEXTURE_1D, GL_TEXTURE_WRAP_S, GL_CLAMP);
    CreatePowMap(1.0, 1.0, 1.0);
    glEnable(GL_TEXTURE_1D);

    // Load and compile shaders
    for (i = 0; i < TOTAL_SHADERS; i++)
    {
        PrepareShader(i);
    }

    // Install first shader
    glUseProgram(progObj[0]);
}

void ProcessMenu(int value)
{
    switch(value)
    {
    case 1:
        useBlending = !useBlending;
        if (useBlending)
        {
            glutChangeToMenuEntry(1, "Toggle vertex blending (currently ON)", 1);
        }
        else
        {
            glutChangeToMenuEntry(1, "Toggle vertex blending (currently OFF)", 1);
        }
        break;

    case 2:
        showBones = !showBones;
        if (showBones)
        {
            glutChangeToMenuEntry(2, "Show bones (currently ON)", 2);
        }
        else
        {
            glutChangeToMenuEntry(2, "Show bones (currently OFF)", 2);
        }
        break;

    default:
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
        sphereOfInfluence -= 0.05f;
        if (sphereOfInfluence < 0.05f)
            sphereOfInfluence = 0.0f;
        break;
    case GLUT_KEY_RIGHT:
        sphereOfInfluence += 0.05f;
        if (sphereOfInfluence > 0.95f)
            sphereOfInfluence = 1.0f;
        break;
    case GLUT_KEY_UP:
        elbowBend += 5.0f;
        if (elbowBend > 150.0f)
            elbowBend = 150.0f;
        break;
    case GLUT_KEY_DOWN:
        elbowBend -= 5.0f;
        if (elbowBend < -150.0f)
            elbowBend = -150.0f;
        break;
    default:
        break;
    }

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
    glutCreateWindow("Vertex Blending Demo");
    glutReshapeFunc(ChangeSize);
    glutKeyboardFunc(KeyPressFunc);
    glutSpecialFunc(SpecialKeys);
    glutDisplayFunc(RenderScene);

    SetupRC();

    // Create the menus
    mainMenu = glutCreateMenu(ProcessMenu);
    glutAddMenuEntry("Toggle vertex blending (currently ON)", 1);
    glutAddMenuEntry("Show bones (currently OFF)", 2);
    glutAttachMenu(GLUT_RIGHT_BUTTON);

    glutMainLoop();

    if (glDeleteProgram && glDeleteShader)
    {
        for (i = 0; i < TOTAL_SHADERS; i++)
        {
            glDeleteProgram(progObj[i]);
            glDeleteShader(vShader[i]);
        }
    }

    return 0;
}
