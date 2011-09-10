#include <math.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <gl\glut.h>

int width  = 800;
int height = 600;

GLfloat xwmin = 50, ywmin = 50, xwmax = 200, ywmax = 150;

int count = 0;
GLdouble left_plane[] = {1,0,0,-xwmin};
GLdouble top_plane[] = {0,-1,0,ywmax};
GLdouble right_plane[] = {-1,0,0,xwmax};
GLdouble bottom_plane[] = {0,1,0,-ywmin};

typedef struct tagPOINT2D {
	GLfloat x,y;
} POINT2D;

POINT2D P1, P2;

void init(void)
{
    // Set clear color to white
    glClearColor(1.0f, 1.0f, 1.0f, 0.0f);
	glMatrixMode(GL_PROJECTION);
	glLoadIdentity();
	gluOrtho2D(-width/2,width/2,-height/2,height/2);
	return;
} 

void ProcessMouse(int button, int state, int x, int y)
{
	if (button == GLUT_LEFT_BUTTON)
		if (state == GLUT_DOWN)
			if (count < 2) {
				glPointSize(5);
				glBegin(GL_POINTS);
				glVertex2i(x-width/2,height/2-y);
				glEnd();
				glFlush();
				if (count == 0) {
					P1.x = x-width/2;
					P1.y = height/2-y;
				}
				else {
					P2.x = x-width/2;
					P2.y = height/2-y;
				}
				count++;
			}
	return;
}

void DrawLine(POINT2D P1, POINT2D P2, GLfloat color[3])
{
	glColor3fv(color);
	glLineWidth(5);
	glBegin(GL_LINES);
	glVertex2f(P1.x,P1.y);
	glVertex2f(P2.x,P2.y);
	glEnd();
	glFlush();
	return;
}


void ClipLine(POINT2D P1, POINT2D P2, GLfloat color[3])
{
	glClipPlane(GL_CLIP_PLANE0,left_plane);
	glClipPlane(GL_CLIP_PLANE1,top_plane);
	glClipPlane(GL_CLIP_PLANE2,right_plane);
	glClipPlane(GL_CLIP_PLANE3,bottom_plane);

	glEnable(GL_CLIP_PLANE0);
	glEnable(GL_CLIP_PLANE1);
	glEnable(GL_CLIP_PLANE2);
	glEnable(GL_CLIP_PLANE3);

	DrawLine(P1,P2,color);

	glDisable(GL_CLIP_PLANE0);
	glDisable(GL_CLIP_PLANE1);
	glDisable(GL_CLIP_PLANE2);
	glDisable(GL_CLIP_PLANE3);

	return;
}


void ProcessMenu(int value)
{
	GLfloat linecolor[] = {1,0,0};
	GLfloat clipcolor[] = {0,1,0};
	if (value == 0)
		DrawLine(P1,P2,linecolor);
	else if (value == 1)
		ClipLine(P1,P2,clipcolor);
	return;
}



void ComputerGraphics(void)
{
	glClear(GL_COLOR_BUFFER_BIT);
	glColor3f(1,0,0);
	// Ve cua so xen
	glBegin(GL_LINE_LOOP);
	glVertex2f(xwmin,ywmin);
	glVertex2f(xwmax,ywmin);
	glVertex2f(xwmax,ywmax);
	glVertex2f(xwmin,ywmax);
	glEnd();
	glFlush(); 
	return;
}

int main(int argc, char *argv[])
{
	glutInit(&argc, argv);
	glutInitDisplayMode(GLUT_SINGLE | GLUT_RGB);
	glutInitWindowPosition(50,50);
	glutInitWindowSize(width,height);
	glutCreateWindow("Computer Graphics with OpenGL");
	glutMouseFunc(ProcessMouse);
	glutCreateMenu(ProcessMenu);
	glutAddMenuEntry("Draw Line",0);
	glutAddMenuEntry("Clip Line",1);
	glutAttachMenu(GLUT_RIGHT_BUTTON);
	init();
	glutDisplayFunc(ComputerGraphics);
	glutMainLoop();
	return 0;
}

