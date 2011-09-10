#include <math.h>
#include <gl\glut.h>

int width  = 800;
int height = 600;

#define MAXVERT 100

typedef struct tagPOINT {
	GLfloat x, y;
} POINT;

typedef struct tagPOLYGON {
	int NumVert;
	POINT Vert[MAXVERT];
} POLYGON;

POLYGON P = {0};
bool Nhap = true;

void init(void)
{
    // Set clear color to white
    glClearColor(1.0f, 1.0f, 1.0f, 0.0f);
	glMatrixMode(GL_PROJECTION);
	glLoadIdentity();
	gluOrtho2D(-width/2,width/2,-height/2,height/2);
	glMatrixMode(GL_MODELVIEW);
	glLoadIdentity();
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
				glEnd();
				glFlush();
				P.Vert[P.NumVert].x = x-width/2;
				P.Vert[P.NumVert].y = height/2-y;
				P.NumVert++;
			}
	return;
}


GLfloat Factorial(int n)
{
	GLfloat result = 1;
	int k;
	for (k=2; k<=n; k++)
		result = result*k;
	return result;
}

GLfloat Combination(int n, int k)
{
	return Factorial(n)/(Factorial(k)*Factorial(n-k));
}



GLfloat BEZ(int k, int n, GLfloat t)
{
	return Combination(n,k)*pow(1-t,n-k)*pow(t,k);
}

void VeDuongCongBezier(GLfloat color[3])
{
	glColor3fv(color);
	int m, M = 100;
	GLfloat t, dt = 1.0/M;
	int k, n = P.NumVert-1;

	POINT Q;
	glBegin(GL_POINTS);
	for (m=0; m<=M; m++) {
		t = m*dt;
		Q.x = 0; Q.y = 0;
		for (k=0; k<=n; k++) {
			Q.x = Q.x + P.Vert[k].x*BEZ(k,n,t);
			Q.y = Q.y + P.Vert[k].y*BEZ(k,n,t);
		}
		glVertex2f(Q.x,Q.y);
	}
	glEnd();
	glFlush();
	return;
}




void VeDaGiac(GLfloat color[3])
{
	Nhap = false;
	glColor3fv(color);
	glLineWidth(5);
	glBegin(GL_LINE_STRIP);
	for(int i = 0; i < P.NumVert; i++)
		glVertex2f(P.Vert[i].x,P.Vert[i].y); 
	glEnd();
	glFlush();
}

void ProcessMenu(int value)
{
	GLfloat polygoncolor[] = {0,1,0};
	GLfloat beziercolor[] = {1,0,0};
	if (value == 0)
		VeDaGiac(polygoncolor);
	else if (value == 1)
		VeDuongCongBezier(beziercolor);
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
	glutInitWindowPosition(0,0);
	glutInitWindowSize(width+1,height+1);
	glutCreateWindow("Computer Graphics");
	glutMouseFunc(ProcessMouse);
	glutCreateMenu(ProcessMenu);
	glutAddMenuEntry("Ve Da Giac",0);
	glutAddMenuEntry("Ve Duong Cong Bezier",1);
	glutAttachMenu(GLUT_RIGHT_BUTTON);
	init();
	glutDisplayFunc(ComputerGraphics);
	glutMainLoop();
	return 0;
}

