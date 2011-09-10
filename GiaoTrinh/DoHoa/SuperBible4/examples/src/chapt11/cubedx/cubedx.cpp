// CubeDX.cpp
// OpenGL SuperBible
// Demonstrates rendering with Indexed Vertex Arrays
// Program by Richard S. Wright Jr.

#include "../../shared/gltools.h"	// OpenGL toolkit


// Array containing the six vertices of the cube
static GLfloat corners[] = { -25.0f, 25.0f, 25.0f, // 0 // Front of cube
                              25.0f, 25.0f, 25.0f, // 1
                              25.0f, -25.0f, 25.0f,// 2
                             -25.0f, -25.0f, 25.0f,// 3
                             -25.0f, 25.0f, -25.0f,// 4  // Back of cube
                              25.0f, 25.0f, -25.0f,// 5
                              25.0f, -25.0f, -25.0f,// 6
                             -25.0f, -25.0f, -25.0f };// 7

// Array of indexes to create the cube
static GLubyte indexes[] = { 0, 1, 2, 3,	// Front Face
                             4, 5, 1, 0,	// Top Face
                             3, 2, 6, 7,	// Bottom Face
                             5, 4, 7, 6,	// Back Face
							 1, 5, 6, 2,	// Right Face
							 4, 0, 3, 7 };	// Left Face

// Rotation amounts
static GLfloat xRot = 0.0f;
static GLfloat yRot = 0.0f;



// Called to draw scene
void RenderScene(void)
    {
    // Clear the window with current clearing color
    glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);

    // Make the cube a wire frame
	glPolygonMode(GL_FRONT_AND_BACK, GL_LINE);
	
	// Save the matrix state
    glMatrixMode(GL_MODELVIEW);
    glPushMatrix();
    glTranslatef(0.0f, 0.0f, -200.0f);
    
    // Rotate about x and y axes
    glRotatef(xRot, 1.0f, 0.0f, 0.0f);
    glRotatef(yRot, 0.0f, 0.0f, 1.0f);

    // Enable and specify the vertex array
    glEnableClientState(GL_VERTEX_ARRAY);
    glVertexPointer(3, GL_FLOAT, 0, corners);
       
    // Using Drawarrays
    glDrawElements(GL_QUADS, 24, GL_UNSIGNED_BYTE, indexes);
  
    glPopMatrix();

    // Swap buffers
    glutSwapBuffers();
    }


// This function does any needed initialization on the rendering
// context. 
void SetupRC()
    {
    // Black background
    glClearColor(1.0f, 1.0f, 1.0f, 1.0f );

	glColor3ub(0,0,0);
    }

///////////////////////////////////////////////////////////////////////////////
// Process arrow keys
void SpecialKeys(int key, int x, int y)
    {
    if(key == GLUT_KEY_UP)
        xRot-= 5.0f;

    if(key == GLUT_KEY_DOWN)
        xRot += 5.0f;

    if(key == GLUT_KEY_LEFT)
        yRot -= 5.0f;

    if(key == GLUT_KEY_RIGHT)
        yRot += 5.0f;

    if(key > 356.0f)
        xRot = 0.0f;

    if(key < -1.0f)
        xRot = 355.0f;

    if(key > 356.0f)
        yRot = 0.0f;

    if(key < -1.0f)
        yRot = 355.0f;

    // Refresh the Window
    glutPostRedisplay();
    }


void ChangeSize(int w, int h)
    {
    // Prevent a divide by zero
    if(h == 0)
        h = 1;

    // Set Viewport to window dimensions
    glViewport(0, 0, w, h);

    // Reset coordinate system
    glMatrixMode(GL_PROJECTION);
    glLoadIdentity();

    // Establish clipping volume (left, right, bottom, top, near, far)
    gluPerspective(35.0f, (float)w/(float)h, 1.0f, 1000.0f);

    glMatrixMode(GL_MODELVIEW);
    glLoadIdentity();
    }

int main(int argc, char* argv[])
    {
    glutInit(&argc, argv);

    glutInitDisplayMode(GLUT_DOUBLE | GLUT_RGB | GLUT_DEPTH);
    glutInitWindowSize(800,600);
    glutCreateWindow("Cube DX");
    glutReshapeFunc(ChangeSize);
    glutSpecialFunc(SpecialKeys);
    glutDisplayFunc(RenderScene);

	SetupRC();

	glutMainLoop();
    return 0;
    }
