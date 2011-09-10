#include <math.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <gl\glut.h>

int width = 800, height = 600, znear = 400, zfar = 1000;


void init(void)
{
    // Set clear color to white
    glClearColor(1.0f, 1.0f, 1.0f, 0.0f);
	glMatrixMode(GL_PROJECTION);
	glLoadIdentity();
	glOrtho(-width/2,width/2,-height/2,height/2,znear,zfar);
	glMatrixMode(GL_MODELVIEW);
	glLoadIdentity();

	return;
} 


void DrawCylinder(void)
{
	glPushMatrix();
	glTranslatef(0,0,-znear-200);
	glRotatef(-45,1,0,0);
	glColor3f(1,0,0);

	GLUquadricObj *qobj;

	qobj = gluNewQuadric();
	
	gluQuadricDrawStyle(qobj,GLU_LINE);

	// Mat tru
	//gluCylinder(qobj,100,100,100,20,20);
	// Mat non
	//gluCylinder(qobj,100,0,100,20,20);
	// Mat cau
	//gluSphere(qobj,100,20,20);
	// Chiec nhan
	glutWireTorus(20,100,20,20);

	gluDeleteQuadric(qobj);
	glPopMatrix();

	return;
}



void DrawCoordinateAxis(void)
{
	glPushMatrix();
	glTranslatef(0,0,-znear-1);
	glColor3f(1,0,0);
	glBegin(GL_LINES);
	glVertex3f(-1.0*width/2,0,0);
	glVertex3f(1.0*width/2,0,0);
	glVertex3f(0,-1.0*height/2,0);
	glVertex3f(0,1.0*height/2,0);
	glEnd();
	glPopMatrix();
	glFlush();
}


void ComputersGraphics(void)
{
	glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);
	DrawCoordinateAxis();
	DrawCylinder();
	glFlush();
}

int main(int argc, char **argv)
{
	glutInit(&argc, argv);
	glutInitDisplayMode(GLUT_SINGLE | GLUT_RGB | GLUT_DEPTH);
	glutInitWindowPosition(10,10);
	glutInitWindowSize(width,height);
	glutCreateWindow("Computers Graphics With OpenGL Programming");
	init();
	glutDisplayFunc(ComputersGraphics);
	glutMainLoop();
	return 0;
}
