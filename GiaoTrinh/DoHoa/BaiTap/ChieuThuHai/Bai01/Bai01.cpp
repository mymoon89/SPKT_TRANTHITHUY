// Bai01.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <windows.h>
#include <gl\glut.h>


void init(void)
{
    // Set clear color to white
    glClearColor(1.0f, 1.0f, 1.0f, 0.0f);
	glMatrixMode(GL_PROJECTION);
	gluOrtho2D(0.0,200.0,0.0,150.0);
	return;
}

void lineSegment(void)
{

	glEnable(GL_LINE_STIPPLE);

	// Clear the window with current clearing color
	glClear(GL_COLOR_BUFFER_BIT);

   	// Set current drawing color to red
	//		   R	 G	   B
	glColor3f(1.0f, 0.0f, 0.0f);
	
	glLineWidth(5.0);
	GLint factor = 5;			// Stippling factor
	GLushort pattern = 0x88FF;	// Stipple pattern
	glLineStipple(factor,pattern);

	glBegin(GL_LINES);
		glVertex2i(15,15);
		glVertex2i(180,15);
	glEnd();
	// Flush drawing commands
    glFlush(); 
	glDisable(GL_LINE_STIPPLE);

	return;
}

int _tmain(int argc, _TCHAR* argv[])
{
	glutInit(&argc, argv);
	glutInitDisplayMode(GLUT_SINGLE | GLUT_RGB);
	glutInitWindowPosition(50,100);
	glutInitWindowSize(400,300);
	glutCreateWindow("An Example OpenGL Programming");

	init();
	glutDisplayFunc(lineSegment);
	glutMainLoop();

	return 0;
}
