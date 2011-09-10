#include <windows.h>
#include <gl\glut.h>
#include <math.h>

int width  = 800;
int height = 600;

bool Nhap = true;
bool NhapDiemCoDinh = false;

#define MAXVERT 100
typedef struct tagPOLYGON {
	int n;
	GLfloat V[MAXVERT][3];
} POLYGON;

POLYGON P = {0};
POLYGON Q;
GLfloat Fix[3];

void DrawCordinationAxis(void);
void DrawPolygon(POLYGON P);
void DrawCompositionPolygon(POLYGON &Q,POLYGON P, GLfloat F[3]);
void MultiMatrix(GLfloat M[3][3], GLfloat M1[3][3], GLfloat M2[3][3]);
void MultiVector(GLfloat Q[3], GLfloat M[3][3], GLfloat P[3]);

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
			if (Nhap) {
				glColor3f(1,0,0);
				glPointSize(5);
				glBegin(GL_POINTS);
				glVertex2i(x-width/2,height/2-y);
				P.V[P.n][0] = x-width/2;
				P.V[P.n][1] = height/2-y;
				P.V[P.n][2] = 1;
				P.n++;
				glEnd();
				glFlush();
			}
			else if (NhapDiemCoDinh) {
				glColor3f(1,0,0);
				glPointSize(5);
				glBegin(GL_POINTS);
				glVertex2i(x-width/2,height/2-y);
				Fix[0] = x-width/2;
				Fix[1] = height/2-y;
				Fix[2] = 1;
				DrawCompositionPolygon(Q,P,Fix);
				glEnd();
				glFlush();
			}
	return;
}


void DrawPolygon(POLYGON P)
{
	Nhap = false;
	NhapDiemCoDinh = true;
	DrawCordinationAxis();
	glColor3f(0,1,0);
	
	glBegin(GL_POLYGON);
	for (int i=0; i<P.n; i++)
		glVertex2f(P.V[i][0],P.V[i][1]);
	glEnd();
	glFlush();
	return;
}


void DrawCompositionPolygon(POLYGON &Q,POLYGON P, GLfloat F[3])
{
	Q.n = P.n;
	GLfloat pi = 4.0*atan(1.0);
	GLfloat theta = 30*pi/180;
	GLfloat M1[3][3] = {{1,0,-F[0]},{0,1,-F[1]},{0,0,1}};
	GLfloat M2[3][3] = {{cos(theta),-sin(theta),0},{sin(theta),cos(theta),0},{0,0,1}};
	GLfloat M3[3][3] = {{1,0,F[0]},{0,1,F[1]},{0,0,1}};
	GLfloat T[3][3],M[3][3];
	MultiMatrix(T,M3,M2);
	MultiMatrix(M,T,M1);

	for (int i=0; i<P.n; i++)
		MultiVector(Q.V[i], M, P.V[i]);

	DrawPolygon(Q);
	return;
}


void MultiVector(GLfloat Q[3], GLfloat M[3][3], GLfloat P[3])
{
	Q[0] = P[0]*M[0][0] + P[1]*M[0][1] + P[2]*M[0][2];
	Q[1] = P[0]*M[1][0] + P[1]*M[1][1] + P[2]*M[1][2];
	Q[2] = P[0]*M[2][0] + P[1]*M[2][1] + P[2]*M[2][2];
	return;
}

void MultiMatrix(GLfloat M[3][3], GLfloat M1[3][3], GLfloat M2[3][3])
{
	int I=3, J=3, K=3; 
	int i, j, k;
	for (i=0; i<I; i++)
		for (k=0; k<K; k++) {
			M[i][k] = 0;
			for (j=0; j<J; j++)
				M[i][k] = M[i][k] + M1[i][j]*M2[j][k];
		}
	return;
}

void DrawCordinationAxis(void)
{
	glColor3f(0,0,0);
	glBegin(GL_LINES);
	glVertex2i(0,height/2);
	glVertex2i(0,-height/2);
	glVertex2i(width/2,0);
	glVertex2i(-width/2,0);
	glEnd();
	return;
}




void Transform2D(POLYGON &Q, POLYGON P)
{
	Q.n = P.n;
	GLfloat tx = 200, ty = 150;
	GLfloat pi = 4.0*atan(1.0);
	GLfloat theta = 30*pi/180;
	GLfloat M[3][3] = {{cos(theta),-sin(theta),0},{sin(theta),cos(theta),0},{0,0,1}};

	for (int i=0; i<P.n; i++)
		MultiVector(Q.V[i], M, P.V[i]);

	DrawPolygon(Q);
	return;
}


void ProcessMenu(int value)
{
	if (value == 0) {
		glClear(GL_COLOR_BUFFER_BIT);
		DrawPolygon(P);
	}
	else if (value == 1)
		Transform2D(Q,P);
	return;
}

void ComputerGraphics(void)
{
	glClear(GL_COLOR_BUFFER_BIT);
	DrawCordinationAxis();
    glFlush(); 
	return;
}

int main(int argc, char *argv[])
{
	glutInit(&argc, argv);
	glutInitDisplayMode(GLUT_SINGLE | GLUT_RGB);
	glutInitWindowPosition(5,5);
	glutInitWindowSize(width+1,height+1);
	glutCreateWindow("Computer Graphics");
	glutMouseFunc(ProcessMouse);
	glutCreateMenu(ProcessMenu);
	glutAddMenuEntry("Draw Polygon",0);
	glutAddMenuEntry("Transform 2D",1);
	glutAttachMenu(GLUT_RIGHT_BUTTON);
	init();
	glutDisplayFunc(ComputerGraphics);
	glutMainLoop();
	return 0;
}

