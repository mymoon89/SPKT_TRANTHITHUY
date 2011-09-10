// occquery.cpp
// OpenGL SuperBible, Chapter 13
// Demonstrates occlusion queries
// Program by Benjamin Lipchak

#include "../../shared/gltools.h"
#include "../../shared/stopwatch.h" // General purpose stop watch class

#undef FREEGLUT_VERSION_2_0
#define gltPrintf(a, b, c, d)
#include <stdio.h>

GLint windowWidth = 1024;                // window size
GLint windowHeight = 768;

GLint mainMenu, bboxMenu;               // menu handles

GLboolean showMenu = GL_TRUE;
GLboolean occlusionDetection = GL_TRUE;
GLboolean showBoundingVolume = GL_FALSE;
GLint boundingVolume = 0;
GLuint queryIDs[27];

GLfloat ambientLight[] = { 0.4f, 0.4f, 0.4f, 1.0f};
GLfloat diffuseLight[] = { 0.9f, 0.9f, 0.9f, 1.0f};
GLfloat lightPos[]     = { 100.0f, 300.0f, 100.0f, 1.0f};

GLfloat cameraPos[]    = { 200.0f, 300.0f, 400.0f, 1.0f};
GLdouble cameraZoom = 0.6;

// Called to draw the occluding grid
void DrawOccluder(void)
{
    glColor3f(0.5f, 0.25f, 0.0f);

    glPushMatrix();
    glScalef(30.0f, 30.0f, 1.0f);
    glTranslatef(0.0f, 0.0f, 50.0f);
    glutSolidCube(10.0f);
    glTranslatef(0.0f, 0.0f, -100.0f);
    glutSolidCube(10.0f);
    glPopMatrix();

    glPushMatrix();
    glScalef(1.0f, 30.0f, 30.0f);
    glTranslatef(50.0f, 0.0f, 0.0f);
    glutSolidCube(10.0f);
    glTranslatef(-100.0f, 0.0f, 0.0f);
    glutSolidCube(10.0f);
    glPopMatrix();

    glPushMatrix();
    glScalef(30.0f, 1.0f, 30.0f);
    glTranslatef(0.0f, 50.0f, 0.0f);
    glutSolidCube(10.0f);
    glTranslatef(0.0f, -100.0f, 0.0f);
    glutSolidCube(10.0f);
    glPopMatrix();
}

// Called to draw sphere
void DrawSphere(GLint sphereNum)
{
    GLboolean occluded = GL_FALSE;

    if (occlusionDetection)
    {
        GLint passingSamples;

        // Check if this sphere would be occluded
        glGetQueryObjectiv(queryIDs[sphereNum], GL_QUERY_RESULT, 
                           &passingSamples);
        if (passingSamples == 0)
            occluded = GL_TRUE;
    }

    if (!occluded)
    {
        glutSolidSphere(50.0f, 100, 100);
    }
}

// Called to draw scene objects
void DrawModels(void)
{
    GLint r, g, b;

    // Draw main occluder first
    DrawOccluder();

    if (occlusionDetection || showBoundingVolume)
    {
        // All we care about for bounding box is resulting depth values
        glShadeModel(GL_FLAT);
        // Texturing is already disabled
        if (showBoundingVolume)
        {
            glEnable(GL_POLYGON_STIPPLE);
        }
        else
        {
            glDisable(GL_LIGHTING);
            glDisable(GL_COLOR_MATERIAL);
            glDisable(GL_NORMALIZE);
            glDepthMask(GL_FALSE);
            glColorMask(0, 0, 0, 0);
        }

        // Draw 27 spheres in a color cube
        for (r = 0; r < 3; r++)
        {
            for (g = 0; g < 3; g++)
            {
                for (b = 0; b < 3; b++)
                {
                    if (showBoundingVolume)
                        glColor3f(r * 0.5f, g * 0.5f, b * 0.5f);

                    glPushMatrix();
                    glTranslatef(100.0f * r - 100.0f, 
                                 100.0f * g - 100.0f, 
                                 100.0f * b - 100.0f);
                    glBeginQuery(GL_SAMPLES_PASSED, queryIDs[(r*9)+(g*3)+b]);
                    switch (boundingVolume)
                    {
                    case 0:
                        glutSolidCube(100.0f);
                        break;
                    case 1:
                        glScalef(150.0f, 150.0f, 150.0f);
                        glutSolidTetrahedron();
                        break;
                    case 2:
                        glScalef(90.0f, 90.0f, 90.0f);
                        glutSolidOctahedron();
                        break;
                    case 3:
                        glScalef(40.0f, 40.0f, 40.0f);
                        glutSolidDodecahedron();
                        break;
                    case 4:
                        glScalef(65.0f, 65.0f, 65.0f);
                        glutSolidIcosahedron();
                        break;
                    }
                    glEndQuery(GL_SAMPLES_PASSED);
                    glPopMatrix();
                }
            }
        }

        // Restore normal drawing state
        glDisable(GL_POLYGON_STIPPLE);
        glShadeModel(GL_SMOOTH);
        glEnable(GL_LIGHTING);
        glEnable(GL_COLOR_MATERIAL);
        glEnable(GL_NORMALIZE);
        glColorMask(1, 1, 1, 1);
        glDepthMask(GL_TRUE);
    }

    // Turn on texturing just for spheres
    glEnable(GL_TEXTURE_2D);
    glEnable(GL_TEXTURE_GEN_S);
    glEnable(GL_TEXTURE_GEN_T);

    // Draw 27 spheres in a color cube
    for (r = 0; r < 3; r++)
    {
        for (g = 0; g < 3; g++)
        {
            for (b = 0; b < 3; b++)
            {
                glColor3f(r * 0.5f, g * 0.5f, b * 0.5f);

                glPushMatrix();
                glTranslatef(100.0f * r - 100.0f, 
                             100.0f * g - 100.0f, 
                             100.0f * b - 100.0f);
                DrawSphere((r*9)+(g*3)+b);
                glPopMatrix();
            }
        }
    }

    glDisable(GL_TEXTURE_2D);
    glDisable(GL_TEXTURE_GEN_S);
    glDisable(GL_TEXTURE_GEN_T);
}

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

    // Draw objects in the scene
    DrawModels();

    if (showMenu)
    {
        glColor4f(1.0f, 1.0f, 1.0f, 1.0f);
        glDisable(GL_LIGHTING);
        glDisable(GL_DEPTH_TEST);
        gltPrintf(GLUT_BITMAP_9_BY_15, 0, 3, "Controls:");
        gltPrintf(GLUT_BITMAP_9_BY_15, 2, 3, "    Right-click for menu");
        gltPrintf(GLUT_BITMAP_9_BY_15, 4, 3, "    x/X      Move +/- in x direction");
        gltPrintf(GLUT_BITMAP_9_BY_15, 5, 3, "    y/Y      Move +/- in y direction");
        gltPrintf(GLUT_BITMAP_9_BY_15, 6, 3, "    z/Z      Move +/- in z direction");
        gltPrintf(GLUT_BITMAP_9_BY_15, 8, 3, "    b        Switch bounding volume");
        gltPrintf(GLUT_BITMAP_9_BY_15, 9, 3, "    s        Toggle show bounding volume");
        gltPrintf(GLUT_BITMAP_9_BY_15, 10, 3, "    o        Toggle occlusion culling");
        gltPrintf(GLUT_BITMAP_9_BY_15, 12, 3, "    m        Show menu");
        gltPrintf(GLUT_BITMAP_9_BY_15, 13, 3, "    q        Exit demo");
        glEnable(GL_LIGHTING);
        glEnable(GL_DEPTH_TEST);
    }

    if (glGetError() != GL_NO_ERROR)
    {
        glColor4f(1.0f, 0.0f, 0.0f, 1.0f);
        glDisable(GL_LIGHTING);
        glDisable(GL_DEPTH_TEST);
        gltPrintf(GLUT_BITMAP_9_BY_15, 15, 0, "GL Error!");
        glEnable(GL_LIGHTING);
        glEnable(GL_DEPTH_TEST);
    }

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
        if (occlusionDetection)
            sprintf(cBuffer,"Draw scene with occlusion detection %.1f fps", fps);
        else
            sprintf(cBuffer,"Draw scene without occlusion detection %.1f fps", fps);
            
        glutSetWindowTitle(cBuffer);
        frameTimer.Reset();
        iFrames = 1;
    }
        
    // Do it again
    glutPostRedisplay();
}

// This function does any needed initialization on the rendering
// context. 
void SetupRC()
{
    GLint queryCounterBits;

    // Make sure required functionality is available!
    if (!GLEE_VERSION_1_5 && !GLEE_ARB_occlusion_query)
    {
        fprintf(stderr, "Neither OpenGL 1.5 nor GL_ARB_occlusion_query"
                        " extension is available!\n");
        Sleep(2000);
        exit(0);
    }

    // Make sure query counter bits is non-zero
    glGetQueryiv(GL_SAMPLES_PASSED, GL_QUERY_COUNTER_BITS, &queryCounterBits);
    if (queryCounterBits == 0)
    {
        fprintf(stderr, "Occlusion queries not really supported!\n");
        fprintf(stderr, "Available query counter bits: 0\n");
        Sleep(2000);
        exit(0);
    }
    
    // Generate occlusion query names
    glGenQueries(27, queryIDs);
    
    // Black background
    glClearColor(0.3f, 0.3f, 0.3f, 1.0f );

    // Hidden surface removal
    glEnable(GL_DEPTH_TEST);
    glDepthFunc(GL_LESS);

    // Screen door transparency
    GLuint mask[32];
    for (int i = 0; i < 32; i += 2) 
    { 
        mask[i] = 0xAAAAAAAA; 
        mask[i+1] = 0x55555555;
    }
    glPolygonStipple((GLubyte *)mask);

    // Set up some lighting state that never changes
    glShadeModel(GL_SMOOTH);
    glEnable(GL_LIGHTING);
    glEnable(GL_COLOR_MATERIAL);
    glEnable(GL_NORMALIZE);
    glEnable(GL_LIGHT0);
    glLightfv(GL_LIGHT0, GL_AMBIENT, ambientLight);
    glLightfv(GL_LIGHT0, GL_DIFFUSE, diffuseLight);
    glLightfv(GL_LIGHT0, GL_POSITION, lightPos);

    // Set up texturing for spheres
    glTexGeni(GL_S, GL_TEXTURE_GEN_MODE, GL_OBJECT_LINEAR);
    glTexGeni(GL_T, GL_TEXTURE_GEN_MODE, GL_OBJECT_LINEAR);
    glTexEnvi(GL_TEXTURE_ENV, GL_TEXTURE_ENV_MODE, GL_MODULATE);
    glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MAG_FILTER, GL_LINEAR);
    glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MIN_FILTER, GL_LINEAR);
    {
        GLfloat p[4] = {1.0f/50.0f, 0.0f, 0.0f, -0.5f};
        GLint w, h, c;
        GLenum format;
        GLbyte *texels = gltLoadTGA("logo.tga", &w, &h, &c, &format);
        glTexImage2D(GL_TEXTURE_2D, 0, c, w, h, 0, format, GL_UNSIGNED_BYTE, texels);
        free(texels);
        glTexGenfv(GL_S, GL_OBJECT_PLANE, p);
        p[0] = 0.0f;
        p[1] = 1.0f/50.0f;
        glTexGenfv(GL_T, GL_OBJECT_PLANE, p);
    }
}

void ProcessMenu(int value)
{
    switch(value)
    {
    case 1:
        occlusionDetection = !occlusionDetection;
        if (occlusionDetection)
        {
            glutChangeToMenuEntry(1, "Toggle occlusion culling (currently ON)", 1);
        }
        else
        {
            glutChangeToMenuEntry(1, "Toggle occlusion culling (currently OFF)", 1);
        }
        break;

    case 2:
        showBoundingVolume = !showBoundingVolume;
        if (showBoundingVolume)
        {
            glutChangeToMenuEntry(2, "Toggle bounding volume (currently ON)", 2);
        }
        else
        {
            glutChangeToMenuEntry(2, "Toggle bounding volume (currently OFF)", 2);
        }
        break;

    default:
        boundingVolume = value - 3;
        glutSetMenu(mainMenu);
        switch (boundingVolume)
        {
        case 0:
            glutChangeToSubMenu(3, "Choose bounding volume (currently BOX)", bboxMenu);
            break;
        case 1:
            glutChangeToSubMenu(3, "Choose bounding volume (currently TETRAHEDRON)", bboxMenu);
            break;
        case 2:
            glutChangeToSubMenu(3, "Choose bounding volume (currently OCTAHEDRON)", bboxMenu);
            break;
        case 3:
            glutChangeToSubMenu(3, "Choose bounding volume (currently DODECAHEDRON)", bboxMenu);
            break;
        case 4:
            glutChangeToSubMenu(3, "Choose bounding volume (currently ICOSAHEDRON)", bboxMenu);
            break;
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
        boundingVolume = (boundingVolume+1)%5;
        glutSetMenu(mainMenu);
        switch (boundingVolume)
        {
        case 0:
            glutChangeToSubMenu(3, "Choose bounding volume (currently BOX)", bboxMenu);
            break;
        case 1:
            glutChangeToSubMenu(3, "Choose bounding volume (currently TETRAHEDRON)", bboxMenu);
            break;
        case 2:
            glutChangeToSubMenu(3, "Choose bounding volume (currently OCTAHEDRON)", bboxMenu);
            break;
        case 3:
            glutChangeToSubMenu(3, "Choose bounding volume (currently DODECAHEDRON)", bboxMenu);
            break;
        case 4:
            glutChangeToSubMenu(3, "Choose bounding volume (currently ICOSAHEDRON)", bboxMenu);
            break;
        }
        break;
    case 's':
    case 'S':
        showBoundingVolume = !showBoundingVolume;
        if (showBoundingVolume)
        {
            glutChangeToMenuEntry(2, "Toggle bounding volume (currently ON)", 2);
        }
        else
        {
            glutChangeToMenuEntry(2, "Toggle bounding volume (currently OFF)", 2);
        }
        break;
    case 'o':
    case 'O':
        occlusionDetection = !occlusionDetection;
        if (occlusionDetection)
        {
            glutChangeToMenuEntry(1, "Toggle occlusion culling (currently ON)", 1);
        }
        else
        {
            glutChangeToMenuEntry(1, "Toggle occlusion culling (currently OFF)", 1);
        }
        break;
    case 'm':
    case 'M':
        showMenu = !showMenu;
        break;
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
        cameraPos[0] += 5.0f;
        break;
    case GLUT_KEY_RIGHT:
        cameraPos[0] -= 5.0f;
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
    glutCreateWindow("Occlusion Query Demo");
    glutReshapeFunc(ChangeSize);
    glutKeyboardFunc(KeyPressFunc);
    glutSpecialFunc(SpecialKeys);
    glutDisplayFunc(RenderScene);

#ifdef FREEGLUT_VERSION_2_0
    glutMouseWheelFunc(MouseWheel);
    glutSetOption(GLUT_ACTION_ON_WINDOW_CLOSE, GLUT_ACTION_GLUTMAINLOOP_RETURNS);
#endif

    // Create the Menu
    bboxMenu = glutCreateMenu(ProcessMenu);
    glutAddMenuEntry("BOX (CUBE)", 3);
    glutAddMenuEntry("TETRAHEDRON", 4);
    glutAddMenuEntry("OCTAHEDRON", 5);
    glutAddMenuEntry("DODECAHEDRON", 6);
    glutAddMenuEntry("ICOSAHEDRON", 7);

    mainMenu = glutCreateMenu(ProcessMenu);
    glutAddMenuEntry("Toggle occlusion query (currently ON)", 1);
    glutAddMenuEntry("Show bounding volume (currently OFF)", 2);
    glutAddSubMenu("Choose bounding volume (currently BOX)", bboxMenu);
    glutAttachMenu(GLUT_RIGHT_BUTTON);

    SetupRC();

    glutMainLoop();

    if (glDeleteQueries)
        glDeleteQueries(27, queryIDs);

    return 0;
}
