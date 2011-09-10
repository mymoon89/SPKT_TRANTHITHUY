#include <math.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <gl\glut.h>

int width  = 800;
int height = 600;

GLfloat xwmin = 50, ywmin = 50, xwmax = 200, ywmax = 150;

int count = 0;

typedef struct tagPOINT2D {
	GLfloat x,y;
} POINT2D;

typedef struct tagHSC {
	int l,t,r,b;
} HSC;

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

void DrawLine(POINT2D P1, POINT2D P2)
{
	glBegin(GL_LINES);
	glVertex2f(P1.x,P1.y);
	glVertex2f(P2.x,P2.y);
	glEnd();
	glFlush();
	return;
}

void Encode(HSC &c, POINT2D P)
{
	c.l = P.x < xwmin;
	c.t = P.y > ywmax;
	c.r = P.x > xwmax;
	c.b = P.y < ywmin;
	return;
}

void Swap(HSC &c1, POINT2D &P1, HSC &c2, POINT2D &P2)
{
	HSC c;
	POINT2D P;
	if (c1.l+c1.t+c1.r+c1.b == 0) {
		c = c1;
		P = P1;
		c1 = c2;
		P1 = P2;
		c2 = c;
		P2 = P;
	}
	return;
}

bool CohenSutherland(POINT2D &P1, POINT2D &P2)
{
	HSC c1, c2;
	POINT2D P;
	while (true) {
		Encode(c1,P1);
		Encode(c2,P2);
		if ((c1.l&&c2.l) || (c1.t&&c2.t) || (c1.r&&c2.r) || (c1.b&&c2.b))
			return false;
		else if (c1.l+c1.t+c1.r+c1.b+c2.l+c2.t+c2.r+c2.b==0)
			return true;
		else {
			Swap(c1,P1,c2,P2);
			if (c1.l) {
				P.x = xwmin;
				P.y = (P2.y-P1.y)/(P2.x-P1.x)*(P.x-P1.x)+P1.y;
			}
			else if (c1.t) {
				P.y = ywmax;
				P.x = (P2.x-P1.x)/(P2.y-P1.y)*(P.y-P1.y)+P1.x;
			}
			else if (c1.r) {
				P.x = xwmax;
				P.y = (P2.y-P1.y)/(P2.x-P1.x)*(P.x-P1.x)+P1.y;
			}
			else if (c1.b) {
				P.y = ywmin;
				P.x = (P2.x-P1.x)/(P2.y-P1.y)*(P.y-P1.y)+P1.x;
			}
			P1 = P;
		}
	}
}

void ClipLine(POINT2D P1, POINT2D P2)
{
	if (CohenSutherland(P1,P2)) {
		glColor3f(0,0,1);
		glBegin(GL_LINES);
		glVertex2f(P1.x,P1.y);
		glVertex2f(P2.x,P2.y);
		glEnd();
		glFlush();
	}
	return;
}


void ProcessMenu(int value)
{
	if (value == 0)
		DrawLine(P1,P2);
	else if (value == 1)
		ClipLine(P1,P2);
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

