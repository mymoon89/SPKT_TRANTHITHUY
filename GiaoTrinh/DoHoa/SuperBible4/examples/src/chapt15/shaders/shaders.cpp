// shaders.cpp
// OpenGL SuperBible, Chapter 15
// Demonstrates GLSL shaders
// Program by Benjamin Lipchak

#include "../../shared/gltools.h"
#undef FREEGLUT_VERSION_2_0

GLint windowWidth = 1024;                // window size
GLint windowHeight = 768;

GLboolean useVertexShader = GL_TRUE;
GLboolean useFragmentShader = GL_TRUE;
GLboolean doBlink = GL_FALSE;

GLboolean needsValidation = GL_TRUE;

GLuint vShader, fShader, progObj;
GLint flickerLocation = -1;

GLfloat cameraPos[] = {100.0f, 150.0f, 200.0f, 1.0f};
GLdouble cameraZoom = 0.6;

#define MAX_INFO_LOG_SIZE 2048

void Link(GLboolean firstTime)
{
    GLint success;

    glLinkProgram(progObj);
    glGetProgramiv(progObj, GL_LINK_STATUS, &success);
    if (!success)
    {
        GLchar infoLog[MAX_INFO_LOG_SIZE];
        glGetProgramInfoLog(progObj, MAX_INFO_LOG_SIZE, NULL, infoLog);
        glColor4f(1.0f, 0.0f, 0.0f, 1.0f);
        //gltPrintf(GLUT_BITMAP_9_BY_15, 0, 0, "Error in program linkage!  Info log:");
        //gltPrintf(GLUT_BITMAP_HELVETICA_10, 2, 0, "%s", infoLog);
        glutSwapBuffers();
        Sleep(5000);
        exit(0);
    }

    if (firstTime)
        glUseProgram(progObj);

    // Find out where the flicker constant lives
    flickerLocation = glGetUniformLocation(progObj, "flickerFactor");

    // Initially set the blink parameter to 1 (no flicker)
    if (flickerLocation != -1)
        glUniform1f(flickerLocation, 1.0f);

    // Program object has changed, so we should revalidate
    needsValidation = GL_TRUE;
}

void Relink()
{
    Link(GL_FALSE);
}

// Called to draw scene objects
void DrawModels(void)
{
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

    // Draw yellow cone
    glColor3f(1.0f, 1.0f, 0.0f);
    glPushMatrix();
    glRotatef(-90.0f, 1.0f, 0.0f, 0.0f);
    glTranslatef(60.0f, 0.0f, -24.0f);
    glutSolidCone(25.0f, 50.0f, 50, 50);
    glPopMatrix();

    // Draw magenta torus
    glColor3f(1.0f, 0.0f, 1.0f);
    glPushMatrix();
    glTranslatef(0.0f, 0.0f, 60.0f);
    glutSolidTorus(8.0f, 16.0f, 50, 50);
    glPopMatrix();

    // Draw cyan octahedron
    glColor3f(0.0f, 1.0f, 1.0f);
    glPushMatrix();
    glTranslatef(0.0f, 0.0f, -60.0f);
    glScalef(25.0f, 25.0f, 25.0f);
    glutSolidOctahedron();
    glPopMatrix();
}

// Called to draw scene
void RenderScene(void)
{
    static GLfloat flickerFactor = 1.0f;

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

    if (doBlink && (flickerLocation != -1))
    {
        // Pick a random flicker factor
        flickerFactor += ((((GLfloat)rand())/((GLfloat)RAND_MAX)) - 0.5f) * 0.1f;
        if (flickerFactor > 1.0f) flickerFactor = 1.0f;
        if (flickerFactor < 0.0f) flickerFactor = 0.0f;
        glUniform1f(flickerLocation, flickerFactor);
    }

    // Validate our shader before first use
    if (needsValidation)
    {
        GLint success;

        glValidateProgram(progObj);
        glGetProgramiv(progObj, GL_VALIDATE_STATUS, &success);
        if (!success)
        {
            GLchar infoLog[MAX_INFO_LOG_SIZE];
            glGetProgramInfoLog(progObj, MAX_INFO_LOG_SIZE, NULL, infoLog);
            glColor4f(1.0f, 0.0f, 0.0f, 1.0f);
            //gltPrintf(GLUT_BITMAP_9_BY_15, 0, 0, "Error in program validation!  Info log:");
            //gltPrintf(GLUT_BITMAP_HELVETICA_10, 2, 0, "%s", infoLog);
            glutSwapBuffers();
            Sleep(5000);
            exit(0);
        }

        needsValidation = GL_FALSE;
    }
    
    // Draw objects in the scene
    DrawModels();
    
    glColor4f(1.0f, 1.0f, 1.0f, 1.0f);
    glDisable(GL_DEPTH_TEST);
    //gltPrintf(GLUT_BITMAP_9_BY_15, 0, 3, "Controls:");
    //gltPrintf(GLUT_BITMAP_9_BY_15, 2, 3, "    Right-click for menu");
    //gltPrintf(GLUT_BITMAP_9_BY_15, 4, 3, "    x/X      Move +/- in x direction");
    //gltPrintf(GLUT_BITMAP_9_BY_15, 5, 3, "    y/Y      Move +/- in y direction");
    //gltPrintf(GLUT_BITMAP_9_BY_15, 6, 3, "    z/Z      Move +/- in z direction");
    //gltPrintf(GLUT_BITMAP_9_BY_15, 8, 3, "    q        Exit demo");
    glEnable(GL_DEPTH_TEST);

    if (glGetError() != GL_NO_ERROR)
    {
        glColor4f(1.0f, 0.0f, 0.0f, 1.0f);
        //gltPrintf(GLUT_BITMAP_9_BY_15, 10, 0, "GL Error!");
    }

    // Flush drawing commands
    glutSwapBuffers();

    if (doBlink && (flickerLocation != -1))
        glutPostRedisplay();
}

// This function does any needed initialization on the rendering
// context. 
void SetupRC()
{
    GLint success;
    const GLchar *vsStringPtr[1];
    const GLchar *fsStringPtr[1];

    GLchar vsString[] = 
        "void main(void)\n"
        "{\n"
        "    // This is our Hello World vertex shader\n"
        "    // notice how comments are preceded by '//'\n"
        "\n"
        "    // normal MVP transform\n"
        "    vec4 clipCoord = gl_ModelViewProjectionMatrix * gl_Vertex;\n"
        "    gl_Position = clipCoord;\n"
        "\n"
        "    // Copy the primary color\n"
        "    gl_FrontColor = gl_Color;\n"
        "\n"
        "    // Calculate NDC\n"
        "    vec4 ndc = vec4(clipCoord.xyz, 0) / clipCoord.w;\n"
        "\n"
        "    // Map from [-1,1] to [0,1] before outputting\n"
        "    gl_FrontSecondaryColor = (ndc * 0.5) + 0.5;\n"
        "}\n";

    GLchar fsString[] = 
        "uniform float flickerFactor;\n"
        "\n"
        "void main(void)\n"
        "{\n"
        "    // Mix primary and secondary colors, 50/50\n"
        "    vec4 temp = mix(gl_Color, vec4(vec3(gl_SecondaryColor), 1.0), 0.5);\n"
        "\n"
        "    // Multiply by flicker factor\n"
        "    gl_FragColor = temp * flickerFactor;\n"
        "}\n";

    glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);
    glColor4f(1.0f, 0.0f, 0.0f, 1.0f);

    // Make sure required functionality is available!
    if (!GLEE_VERSION_2_0 && (!GLEE_ARB_vertex_shader || 
                              !GLEE_ARB_fragment_shader || 
                              !GLEE_ARB_shader_objects || 
                              !GLEE_ARB_shading_language_100))
    {
        //gltPrintf(GLUT_BITMAP_9_BY_15, 0, 3, "GLSL extensions not available!");
        glutSwapBuffers();
        Sleep(2000);
        exit(0);
    }

    if (!GLEE_VERSION_1_4 && !GLEE_EXT_secondary_color)
    {
        //gltPrintf(GLUT_BITMAP_9_BY_15, 0, 3, "Neither OpenGL 1.4 nor GL_EXT_secondary_color");
        //gltPrintf(GLUT_BITMAP_9_BY_15, 1, 3, " extension is available!");
        glutSwapBuffers();
        Sleep(2000);
        exit(0);
    }

    // Black background
    glClearColor(0.0f, 0.0f, 0.0f, 1.0f );
    glSecondaryColor3f(1.0f, 1.0f, 1.0f);

    // Hidden surface removal
    glEnable(GL_DEPTH_TEST);
    glDepthFunc(GL_LEQUAL);

    glShadeModel(GL_SMOOTH);

    // Create shader objects and specify shader text
    vShader = glCreateShader(GL_VERTEX_SHADER);
    fShader = glCreateShader(GL_FRAGMENT_SHADER);
    vsStringPtr[0] = vsString;
    glShaderSource(vShader, 1, vsStringPtr, NULL);
    fsStringPtr[0] = fsString;
    glShaderSource(fShader, 1, fsStringPtr, NULL);

    // Compile shaders and check for any errors
    glCompileShader(vShader);
    glGetShaderiv(vShader, GL_COMPILE_STATUS, &success);
    if (!success)
    {
        GLchar infoLog[MAX_INFO_LOG_SIZE];
        glGetShaderInfoLog(vShader, MAX_INFO_LOG_SIZE, NULL, infoLog);
        //gltPrintf(GLUT_BITMAP_9_BY_15, 0, 0, "Error in vertex shader compilation!  Info log:");
        //gltPrintf(GLUT_BITMAP_HELVETICA_10, 2, 0, "%s", infoLog);
        glutSwapBuffers();
        Sleep(5000);
        exit(0);
    }
    glCompileShader(fShader);
    glGetShaderiv(fShader, GL_COMPILE_STATUS, &success);
    if (!success)
    {
        GLchar infoLog[MAX_INFO_LOG_SIZE];
        glGetShaderInfoLog(fShader, MAX_INFO_LOG_SIZE, NULL, infoLog);
        //gltPrintf(GLUT_BITMAP_9_BY_15, 0, 0, "Error in fragment shader compilation!  Info log:");
        //gltPrintf(GLUT_BITMAP_HELVETICA_10, 2, 0, "%s", infoLog);
        glutSwapBuffers();
        Sleep(5000);
        exit(0);
    }

    // Create program object, attach shaders, then link
    progObj = glCreateProgram();
    if (useVertexShader)
        glAttachShader(progObj, vShader);
    if (useFragmentShader)
        glAttachShader(progObj, fShader);

    Link(GL_TRUE);
}

void ProcessMenu(int value)
{
    switch(value)
    {
    case 1:
        useVertexShader = !useVertexShader;
        if (useVertexShader)
        {
            glutChangeToMenuEntry(1, "Toggle vertex shader (currently ON)", 1);
            glAttachShader(progObj, vShader);
        }
        else
        {
            glutChangeToMenuEntry(1, "Toggle vertex shader (currently OFF)", 1);
            glDetachShader(progObj, vShader);
        }

        Relink();
        break;

    case 2:
        useFragmentShader = !useFragmentShader;
        if (useFragmentShader)
        {
            glutChangeToMenuEntry(2, "Toggle fragment shader (currently ON)", 2);
            glAttachShader(progObj, fShader);
        }
        else
        {
            glutChangeToMenuEntry(2, "Toggle fragment shader (currently OFF)", 2);
            glDetachShader(progObj, fShader);
        }

        Relink();
        break;

    case 3:
        doBlink = !doBlink;
        if (doBlink)
        {
            glutChangeToMenuEntry(3, "Toggle flicker (currently ON)", 3);
        }
        else
        {
            glutChangeToMenuEntry(3, "Toggle flicker (currently OFF)", 3);
        }
        if (!doBlink && (flickerLocation != -1))
            glUniform1f(flickerLocation, 1.0f);
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
#ifdef FREEGLUT_VERSION_2_0
        glutLeaveMainLoop();
#else
        exit(0);
#endif
    }

    // Refresh the Window
    glutPostRedisplay();
}

void SpecialKeys(int key, int x, int y)
{
    switch (key)
    {
    case GLUT_KEY_LEFT:
        cameraPos[0] -= 5.0f;
        break;
    case GLUT_KEY_RIGHT:
        cameraPos[0] += 5.0f;
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
    windowWidth = w;
    windowHeight = h;
}

void MouseWheel(int wheel_number, int direction, int x, int y)
{
    cameraZoom = cameraZoom * ((direction > 0) ? 1.1 : 0.9);

    glutPostRedisplay();
}

int main(int argc, char* argv[])
{
    glutInit(&argc, argv);
    glutInitDisplayMode(GLUT_DOUBLE | GLUT_RGB | GLUT_DEPTH);
    glutInitWindowSize(windowWidth, windowHeight);
    glutCreateWindow("GLSL Shaders Demo");
    glutReshapeFunc(ChangeSize);
    glutKeyboardFunc(KeyPressFunc);
    glutSpecialFunc(SpecialKeys);
    glutDisplayFunc(RenderScene);

#ifdef FREEGLUT_VERSION_2_0
    glutMouseWheelFunc(MouseWheel);
    glutSetOption(GLUT_ACTION_ON_WINDOW_CLOSE, GLUT_ACTION_GLUTMAINLOOP_RETURNS);
#endif

    // Create the Menu
    glutCreateMenu(ProcessMenu);
    glutAddMenuEntry("Toggle vertex shader (currently ON)", 1);
    glutAddMenuEntry("Toggle fragment shader (currently ON)", 2);
    glutAddMenuEntry("Toggle flicker (currently OFF)", 3);
    glutAttachMenu(GLUT_RIGHT_BUTTON);

    SetupRC();

    glutMainLoop();

    if (glDeleteShader && glDeleteProgram)
    {
        glDeleteProgram(progObj);
        glDeleteShader(fShader);
        glDeleteShader(vShader);
    }

    return EXIT_SUCCESS;
}
