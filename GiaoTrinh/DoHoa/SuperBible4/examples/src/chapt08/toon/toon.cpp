// Toon.cpp
// OpenGL SuperBible
// Demonstrates Cell/Toon shading with a 1D texture
// Program by Richard S. Wright Jr.

#include "../../shared/gltools.h"	// OpenGL toolkit
#include "../../shared/math3d.h"    // 3D Math Library
#include <math.h>

// Vector pointing towards the light
M3DVector3f vLightDir = { -1.0f, 1.0f, 1.0f };


// Draw a torus (doughnut), using the current 1D texture for light shading
void toonDrawTorus(GLfloat majorRadius, GLfloat minorRadius, 
                             int numMajor, int numMinor, M3DVector3f vLightDir)
    {
    M3DMatrix44f mModelViewMatrix;
    M3DMatrix44f mInvertedLight;
    M3DVector3f vNewLight;
    M3DVector3f vNormal;
    double majorStep = 2.0f*M3D_PI / numMajor;
    double minorStep = 2.0f*M3D_PI / numMinor;
    int i, j;
    
    // Get the modelview matrix
    glGetFloatv(GL_MODELVIEW_MATRIX, mModelViewMatrix);
    
    // Instead of transforming every normal and then dotting it with
    // the light vector, we will transform the light into object 
    // space by multiplying it by the inverse of the modelview matrix
    m3dInvertMatrix44(mInvertedLight, mModelViewMatrix);
    m3dTransformVector3(vNewLight, vLightDir, mInvertedLight);
    vNewLight[0] -= mInvertedLight[12];
    vNewLight[1] -= mInvertedLight[13];
    vNewLight[2] -= mInvertedLight[14];
    m3dNormalizeVector(vNewLight);
    
    // Draw torus as a series of triangle strips
    for (i=0; i<numMajor; ++i) 
        {
        double a0 = i * majorStep;
        double a1 = a0 + majorStep;
        GLfloat x0 = (GLfloat) cos(a0);
        GLfloat y0 = (GLfloat) sin(a0);
        GLfloat x1 = (GLfloat) cos(a1);
        GLfloat y1 = (GLfloat) sin(a1);

        glBegin(GL_TRIANGLE_STRIP);
        for (j=0; j<=numMinor; ++j) 
            {
            double b = j * minorStep;
            GLfloat c = (GLfloat) cos(b);
            GLfloat r = minorRadius * c + majorRadius;
            GLfloat z = minorRadius * (GLfloat) sin(b);

            // First point
            vNormal[0] = x0*c;
            vNormal[1] = y0*c;
            vNormal[2] = z/minorRadius;
            m3dNormalizeVector(vNormal);
            
            // Texture coordinate is set by intensity of light
            glTexCoord1f(m3dDotProduct(vNewLight, vNormal));
            glVertex3f(x0*r, y0*r, z);

            // Second point
            vNormal[0] = x1*c;
            vNormal[1] = y1*c;
            vNormal[2] = z/minorRadius;
            m3dNormalizeVector(vNormal);
            
            // Texture coordinate is set by intensity of light
            glTexCoord1f(m3dDotProduct(vNewLight, vNormal));
            glVertex3f(x1*r, y1*r, z);
            }
        glEnd();
        }
	}
        
        
// Called to draw scene
void RenderScene(void)
	{
    // Rotation angle
    static GLfloat yRot = 0.0f;
    
        
	// Clear the window with current clearing color
	glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);
	glPushMatrix();
        glTranslatef(0.0f, 0.0f, -2.5f);
        glRotatef(yRot, 0.0f, 1.0f, 0.0f);
        toonDrawTorus(0.35f, 0.15f, 50, 25, vLightDir);
	glPopMatrix();

	// Do the buffer Swap
    glutSwapBuffers();
    
    // Rotate 1/2 degree more each frame
    yRot += 0.5f;
	}

// This function does any needed initialization on the rendering
// context. 
void SetupRC()
    {
    // Load a 1D texture with toon shaded values
    // Green, greener...
    GLbyte toonTable[4][3] = { { 0, 32, 0 },
                               { 0, 64, 0 },
                               { 0, 128, 0 },
                               { 0, 192, 0 }};

    // Bluish background
    glClearColor(0.0f, 0.0f, .50f, 1.0f );
    glEnable(GL_DEPTH_TEST);
    glEnable(GL_CULL_FACE);
        
    glTexEnvi(GL_TEXTURE_ENV, GL_TEXTURE_ENV_MODE, GL_DECAL);
    glTexParameteri(GL_TEXTURE_1D, GL_TEXTURE_MAG_FILTER, GL_NEAREST);
    glTexParameteri(GL_TEXTURE_1D, GL_TEXTURE_MIN_FILTER, GL_NEAREST);
    glTexParameteri(GL_TEXTURE_1D, GL_TEXTURE_WRAP_S, GL_CLAMP);
    glPixelStorei(GL_UNPACK_ALIGNMENT, 1);
    glTexImage1D(GL_TEXTURE_1D, 0, GL_RGB, 4, 0, GL_RGB, GL_UNSIGNED_BYTE, toonTable);
    
    glEnable(GL_TEXTURE_1D);
    }

///////////////////////////////////////////////////////////
// Called by GLUT library when idle (window not being
// resized or moved)
void TimerFunction(int value)
    {
    // Redraw the scene with new coordinates
    glutPostRedisplay();
    glutTimerFunc(33,TimerFunction, 1);
    }



void ChangeSize(int w, int h)
	{
	GLfloat fAspect;

	// Prevent a divide by zero, when window is too short
	// (you cant make a window of zero width).
	if(h == 0)
            h = 1;

    glViewport(0, 0, w, h);
        
    fAspect = (GLfloat)w / (GLfloat)h;

	// Reset the coordinate system before modifying
	glMatrixMode(GL_PROJECTION);
	glLoadIdentity();
	
	// Set the clipping volume
	gluPerspective(35.0f, fAspect, 1.0f, 50.0f);
        
    glMatrixMode(GL_MODELVIEW);
    glLoadIdentity();
    }

///////////////////////////////////////////////////
// Program entry point
int main(int argc, char* argv[])
	{
	glutInit(&argc, argv);
	glutInitDisplayMode(GLUT_DOUBLE | GLUT_RGB | GLUT_DEPTH);
    glutInitWindowSize(800,600);
	glutCreateWindow("Toon/Cell Shading Demo");
	glutReshapeFunc(ChangeSize);
	glutDisplayFunc(RenderScene);
    glutTimerFunc(33, TimerFunction, 1);

	SetupRC();
 	glutMainLoop();

	return 0;
	}
