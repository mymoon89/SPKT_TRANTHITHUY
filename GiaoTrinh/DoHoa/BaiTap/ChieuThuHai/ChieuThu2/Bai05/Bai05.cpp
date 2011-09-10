#include <windows.h>
#include <gl\glut.h>
#include <math.h>

int width  = 800;
int height = 600;


#define MAXVERT 100
typedef struct tagVERTEX3F {
	double x;
	double y;
	double z;
} VERTEX3F;

typedef struct tagPOLYGON {
	int n;
	VERTEX3F V[MAXVERT];
} POLYGON;
POLYGON P = {0};

BOOL Ve = TRUE;
GLdouble vertex[MAXVERT][3];

void init(void)
{
    // Set clear color to white
    glClearColor(1.0f, 1.0f, 1.0f, 0.0f);
	glMatrixMode(GL_PROJECTION);
	glLoadIdentity();
	gluOrtho2D(0,width,0,height);
	return;
}

void ProcessSelectionLeftMouse(int x, int y)
{
	if (Ve) {
		glColor3f(1,0,0);
		glPointSize(5);
		glBegin(GL_POINTS);
			glVertex2i(x,height-y);
			P.V[P.n].x = x;
			P.V[P.n].y = height-y;
			P.V[P.n].z = 0;
			P.n++;
		glEnd();
		glFlush();
	}
	return;
}

void DrawPolygon(void)
{
	Ve = FALSE;
	int i;
	glColor3f(0,0,1);
	glBegin(GL_LINE_LOOP);
	for (i=0; i<P.n; i++)
		glVertex2f(P.V[i].x,P.V[i].y);
	glEnd();

	glFlush();
	return;
}

void MouseCallback(int button, int state, int x, int y)
{
	if (button == GLUT_LEFT_BUTTON && state == GLUT_DOWN)
		ProcessSelectionLeftMouse(x, y);

	return;
}



void FillConvexPolygon(POLYGON P)
{
	// Use Pattern
	GLubyte fillPattern[] = {
		0xFF, 0x00, 0xFF, 0x00,
		0xFF, 0x00, 0xFF, 0x00,
		0xFF, 0x00, 0xFF, 0x00,
		0xFF, 0x00, 0xFF, 0x00,
		0xFF, 0x00, 0xFF, 0x00,
		0xFF, 0x00, 0xFF, 0x00,
		0xFF, 0x00, 0xFF, 0x00,
		0xFF, 0x00, 0xFF, 0x00,

		0x00, 0xFF, 0x00, 0xFF,
		0x00, 0xFF, 0x00, 0xFF,
		0x00, 0xFF, 0x00, 0xFF,
		0x00, 0xFF, 0x00, 0xFF,
		0x00, 0xFF, 0x00, 0xFF,
		0x00, 0xFF, 0x00, 0xFF,
		0x00, 0xFF, 0x00, 0xFF,
		0x00, 0xFF, 0x00, 0xFF,

		0xFF, 0x00, 0xFF, 0x00,
		0xFF, 0x00, 0xFF, 0x00,
		0xFF, 0x00, 0xFF, 0x00,
		0xFF, 0x00, 0xFF, 0x00,
		0xFF, 0x00, 0xFF, 0x00,
		0xFF, 0x00, 0xFF, 0x00,
		0xFF, 0x00, 0xFF, 0x00,
		0xFF, 0x00, 0xFF, 0x00,

		0x00, 0xFF, 0x00, 0xFF,
		0x00, 0xFF, 0x00, 0xFF,
		0x00, 0xFF, 0x00, 0xFF,
		0x00, 0xFF, 0x00, 0xFF,
		0x00, 0xFF, 0x00, 0xFF,
		0x00, 0xFF, 0x00, 0xFF,
		0x00, 0xFF, 0x00, 0xFF,
		0x00, 0xFF, 0x00, 0xFF};

	if (Ve == FALSE) {
		glClear(GL_COLOR_BUFFER_BIT);
		glShadeModel(GL_FLAT);
		glPolygonStipple(fillPattern);
		glEnable(GL_POLYGON_STIPPLE);
		glBegin(GL_TRIANGLE_FAN);
		for (int i=0; i<P.n; i++) {
			if (i%2==0)
				glColor3f(0,1,0);
			else
				glColor3f(1,0,1);
			glVertex2f(P.V[i].x,P.V[i].y);
		}
		glDisable(GL_POLYGON_STIPPLE);
		glEnd();
		glFlush();
		glutSwapBuffers();
	}
	return;
}



void ProcessMenu(int value)
{
    if(value == 0)
		DrawPolygon();
	else if (value == 1)
		FillConvexPolygon(P);
	return;
}

void FillRectangle(int x1, int y1, int x2, int y2)
{
	glColor3f(0,1,0);
	glRecti(x1,y1,x2,y2);
	return;
}




void ComputerGraphics(void)
{
	glClear(GL_COLOR_BUFFER_BIT);
	glFlush(); 
	return;
}

int main(int argc, char *argv[])
{
	glutInit(&argc, argv);
	glutInitDisplayMode(GLUT_SINGLE | GLUT_RGB);
	glutInitWindowPosition(50,100);
	glutInitWindowSize(width,height);
	glutCreateWindow("Computer Graphics");
	glutMouseFunc(MouseCallback);
	glutCreateMenu(ProcessMenu);
    // Create the Menu and add choices
	glutCreateMenu(ProcessMenu);
	glutAddMenuEntry("Draw Polygon",0);
    glutAddMenuEntry("Fill Convex Polygon",1);
    //glutAddMenuEntry("Fill None Convex Polygon",2);
    glutAttachMenu(GLUT_RIGHT_BUTTON);

	glutDisplayFunc(ComputerGraphics);
	init();
	glutMainLoop();
	return 0;
}


