// starrynight.cpp
// OpenGL SuperBible
// Demonstrates vertex arrays (with point sprites!)
// Program by Richard S. Wright Jr.
#include "../../shared/gltools.h"	// OpenGL toolkit
#include "../../shared/glframe.h"
#include <math.h>


// Array of small stars
#define SMALL_STARS 100
M3DVector2f  vSmallStars[SMALL_STARS];

#define MEDIUM_STARS   40
M3DVector2f vMediumStars[MEDIUM_STARS];

#define LARGE_STARS 15
M3DVector2f vLargeStars[LARGE_STARS];

#define SCREEN_X    800
#define SCREEN_Y    600

int drawMode = 1;       // Normal points

GLuint  textureObjects[2];    // Texture Objects

///////////////////////////////////////////////////////////////////////
// Reset flags as appropriate in response to menu selections
void ProcessMenu(int value)
    {
    drawMode = value;

    switch(value)
        {
        case 1:
            // Turn off blending and all smoothing
            glDisable(GL_BLEND);
            glDisable(GL_LINE_SMOOTH);
            glDisable(GL_POINT_SMOOTH);
            glDisable(GL_TEXTURE_2D);
            glDisable(GL_POINT_SPRITE);
            break;

        case 2:
            // Turn on antialiasing, and give hint to do the best
            // job possible.
            glBlendFunc(GL_SRC_ALPHA, GL_ONE_MINUS_SRC_ALPHA);
            glEnable(GL_BLEND);
            glEnable(GL_POINT_SMOOTH);
            glHint(GL_POINT_SMOOTH_HINT, GL_NICEST);
            glEnable(GL_LINE_SMOOTH);
            glHint(GL_LINE_SMOOTH_HINT, GL_NICEST);
            glDisable(GL_TEXTURE_2D);
            glDisable(GL_POINT_SPRITE);
            break;

        case 3:     // Point Sprites
            glEnable(GL_BLEND);
            glBlendFunc(GL_SRC_COLOR, GL_ONE_MINUS_SRC_COLOR);
            glDisable(GL_LINE_SMOOTH);
            glDisable(GL_POINT_SMOOTH);
            glDisable(GL_POLYGON_SMOOTH);
            break;


        default:
            break;
        }
        
    // Trigger a redraw
    glutPostRedisplay();
    }


///////////////////////////////////////////////////
// Called to draw scene
void RenderScene(void)
    {
    int i;                  // Loop variable
    GLfloat x = 700.0f;     // Location and radius of moon
    GLfloat y = 500.0f;
    GLfloat r = 50.0f;
    GLfloat angle = 0.0f;   // Another looping variable
		        
    // Clear the window
    glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);
         
    // Everything is white
    glColor3f(1.0f, 1.0f, 1.0f);
    
    if(drawMode == 3)
        {
        glEnable(GL_POINT_SPRITE);
        glEnable(GL_TEXTURE_2D);
        glBindTexture(GL_TEXTURE_2D, textureObjects[0]);
        glEnable(GL_BLEND);
        }

    glEnableClientState(GL_VERTEX_ARRAY);

    // Draw small stars
    glPointSize(7.0f);          // 1.0
    /*
    glBegin(GL_POINTS);
        for(i = 0; i < SMALL_STARS; i++)
            glVertex2fv(vSmallStars[i]);
    glEnd();
    */
    glVertexPointer(2, GL_FLOAT, 0, vSmallStars);
    glDrawArrays(GL_POINTS, 0, SMALL_STARS);
    
    
    // Draw medium sized stars
    glPointSize(12.0f);         // 3.0
    /*glBegin(GL_POINTS);
        for(i = 0; i< MEDIUM_STARS; i++)
            glVertex2fv(vMediumStars[i]);
    glEnd();
    */
    glVertexPointer(2, GL_FLOAT, 0, vMediumStars);
    glDrawArrays(GL_POINTS, 0, MEDIUM_STARS);
            
    // Draw largest stars
    glPointSize(20.0f);      // 5.5
    /*glBegin(GL_POINTS);
        for(i = 0; i < LARGE_STARS; i++)
            glVertex2fv(vLargeStars[i]);
    glEnd();
    */
    glVertexPointer(2, GL_FLOAT, 0, vLargeStars);
    glDrawArrays(GL_POINTS, 0, LARGE_STARS);        
                
    glDisableClientState(GL_VERTEX_ARRAY);
        
    glPointSize(120.0f);
    if(drawMode == 3)
        {
        glDisable(GL_BLEND);
        glBindTexture(GL_TEXTURE_2D, textureObjects[1]);
        }

    glBegin(GL_POINTS);
        glVertex2f(x, y);
    glEnd();


    glDisable(GL_TEXTURE_2D);
    glDisable(GL_POINT_SPRITE);

    // Draw distant horizon
    glLineWidth(3.5);
    glBegin(GL_LINE_STRIP);
        glVertex2f(0.0f, 25.0f);
        glVertex2f(50.0f, 100.0f);
        glVertex2f(100.0f, 25.0f);
        glVertex2f(225.0f, 115.0f);
        glVertex2f(300.0f, 50.0f);
        glVertex2f(375.0f, 100.0f);
        glVertex2f(460.0f, 25.0f);
        glVertex2f(525.0f, 100.0f);
        glVertex2f(600.0f, 20.0f);
        glVertex2f(675.0f, 70.0f);
        glVertex2f(750.0f, 25.0f);
        glVertex2f(800.0f, 90.0f);    
    glEnd();


    // Swap buffers
    glutSwapBuffers();
    }


// This function does any needed initialization on the rendering
// context. 
void SetupRC()
    {
    int i;
        
    // Populate star list
    for(i = 0; i < SMALL_STARS; i++)
        {
        vSmallStars[i][0] = (GLfloat)(rand() % SCREEN_X);
        vSmallStars[i][1] = (GLfloat)(rand() % (SCREEN_Y - 100))+100.0f;
        }
            
    // Populate star list
    for(i = 0; i < MEDIUM_STARS; i++)
        {
        vMediumStars[i][0] = (GLfloat)(rand() % SCREEN_X * 10)/10.0f;
        vMediumStars[i][1] = (GLfloat)(rand() % (SCREEN_Y - 100))+100.0f;
        }

    // Populate star list
    for(i = 0; i < LARGE_STARS; i++)
        {
        vLargeStars[i][0] = (GLfloat)(rand() % SCREEN_X*10)/10.0f;
        vLargeStars[i][1] = (GLfloat)(rand() % (SCREEN_Y - 100)*10.0f)/ 10.0f +100.0f;
        }
            
            
    // Black background
    glClearColor(0.0f, 0.0f, 0.0f, 1.0f );

    // Set drawing color to white
    glColor3f(0.0f, 0.0f, 0.0f);

    // Load our textures
    glGenTextures(2, textureObjects);
    GLbyte *pBytes;
    GLint iWidth, iHeight, iComponents;
    GLenum eFormat;
     
    glBindTexture(GL_TEXTURE_2D, textureObjects[0]);
     
       
    // Load this texture map
    glTexParameteri(GL_TEXTURE_2D, GL_GENERATE_MIPMAP, GL_TRUE);
    pBytes = gltLoadTGA("star.tga", &iWidth, &iHeight, &iComponents, &eFormat);
    glTexImage2D(GL_TEXTURE_2D, 0, iComponents, iWidth, iHeight, 0, eFormat, GL_UNSIGNED_BYTE, pBytes);
    free(pBytes);
    
    glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MAG_FILTER, GL_LINEAR);
    glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MIN_FILTER, GL_LINEAR_MIPMAP_LINEAR);
    glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_S, GL_CLAMP_TO_EDGE);
    glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_T, GL_CLAMP_TO_EDGE);

    glBindTexture(GL_TEXTURE_2D, textureObjects[1]);
    glTexParameteri(GL_TEXTURE_2D, GL_GENERATE_MIPMAP, GL_TRUE);
    pBytes = gltLoadTGA("moon.tga", &iWidth, &iHeight, &iComponents, &eFormat);
    glTexImage2D(GL_TEXTURE_2D, 0, iComponents, iWidth, iHeight, 0, eFormat, GL_UNSIGNED_BYTE, pBytes);
    free(pBytes);
    
    glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MAG_FILTER, GL_LINEAR);
    glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MIN_FILTER, GL_LINEAR_MIPMAP_LINEAR);
    glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_S, GL_CLAMP_TO_EDGE);
    glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_T, GL_CLAMP_TO_EDGE);

    glTexEnvi(GL_POINT_SPRITE, GL_COORD_REPLACE, GL_TRUE);
    glTexEnvi(GL_TEXTURE_ENV, GL_TEXTURE_ENV_MODE, GL_DECAL);

    // Point Sprites enabled by default
    ProcessMenu(3);
    }

/////////////////////////////////////////////////
// Clean up texture objects
void ShutdownRC(void)
    {
    glDeleteTextures(2, textureObjects);
    }


void ChangeSize(int w, int h)
    {
    // Prevent a divide by zero
    if(h == 0)
        h = 1;

    // Set Viewport to window dimensions
    glViewport(0, 0, w, h);

    // Reset projection matrix stack
    glMatrixMode(GL_PROJECTION);
    glLoadIdentity();

    // Establish clipping volume (left, right, bottom, top, near, far)
    gluOrtho2D(0.0, SCREEN_X, 0.0, SCREEN_Y);


    // Reset Model view matrix stack
    glMatrixMode(GL_MODELVIEW);
    glLoadIdentity();
    }

int main(int argc, char* argv[])
	{
	glutInit(&argc, argv);
	glutInitDisplayMode(GLUT_DOUBLE | GLUT_RGB | GLUT_DEPTH);
	glutInitWindowSize(800, 600);
	glutCreateWindow("Starry Starry Night");
	
	// Create the Menu
	glutCreateMenu(ProcessMenu);

	glutAddMenuEntry("Normal Points",1);
	glutAddMenuEntry("Antialiased Points",2);
    glutAddMenuEntry("Point Sprites", 3);

	glutAttachMenu(GLUT_RIGHT_BUTTON);
	
	glutReshapeFunc(ChangeSize);
	glutDisplayFunc(RenderScene);
	SetupRC();
	glutMainLoop();
    ShutdownRC();

	return 0;
	}
