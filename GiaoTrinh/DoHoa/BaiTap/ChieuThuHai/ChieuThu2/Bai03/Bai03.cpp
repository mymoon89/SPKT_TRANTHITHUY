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
int m;

int Mod(int x, int n)
{
	if (x>=0)
		x = x%n;
	else
		while (x<0)
			x=x+n;
	return x;
}

void CrossProduct(VERTEX3F &V, VERTEX3F V1, VERTEX3F V2)
{
	V.x = V1.y*V2.z-V1.z*V2.y;
	V.y = V1.z*V2.x-V1.x*V2.z;
	V.z = V1.x*V2.y-V1.y*V2.x;
	return;
}

BOOL IdentifyConcavePolygon(POLYGON P, int &m)
{
	VERTEX3F *E;
	VERTEX3F Q;
	int i, n;
	n = P.n;
	E = (VERTEX3F *)calloc(n,sizeof(VERTEX3F));
	// Tao lap cac canh
	for (i=0; i<n; i++) {
		E[Mod(i,n)].x = P.V[Mod(i+1,n)].x - P.V[Mod(i,n)].x;
		E[Mod(i,n)].y = P.V[Mod(i+1,n)].y - P.V[Mod(i,n)].y;
		E[Mod(i,n)].z = P.V[Mod(i+1,n)].z - P.V[Mod(i,n)].z;
	}
	// Cross Product cac canh
	for (i=0; i<n; i++) {
		CrossProduct(Q,E[Mod(i,n)],E[Mod(i+1,n)]);
		if (Q.z < 0) {
			m = Mod(i+1,n);
			glColor3f(0,0,1);
			glPointSize(5);
			glBegin(GL_POINTS);
			glVertex2f(P.V[m].x,P.V[m].y);
			glEnd();
			glFlush();
			return TRUE;
		}
	}
	return FALSE;
}

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

void ProcessSelectionRightMouse(void)
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
void ProcessMenu(int value)
{
    if(value == 0)
		ProcessSelectionRightMouse();
	else if (value == 1)
		IdentifyConcavePolygon(P, m);
	return;
}



void ComputerGraphics(void)
{
	glClear(GL_COLOR_BUFFER_BIT);
	//MidPointEllipse(300,200);
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
	glutAddMenuEntry("Save Image",0);
    // Create the Menu and add choices
	glutCreateMenu(ProcessMenu);
	glutAddMenuEntry("Draw Polygon",0);
    glutAddMenuEntry("Is Concave Polygon",1);
    glutAddMenuEntry("Split Concave",2);
    glutAttachMenu(GLUT_RIGHT_BUTTON);

	glutDisplayFunc(ComputerGraphics);
	init();
	glutMainLoop();
	return 0;
}
