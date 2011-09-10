#include <math.h>
#include <stdlib.h>
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

GLfloat Blend(int k, int d, GLfloat u, GLfloat *knot)
{
	if (d == 1)
		if (knot[k] <= u && u < knot[k+1])
			return 1;
		else 
			return 0;
	else {
		if ((knot[k+d-1]-knot[k]) == 0 && (knot[k+d]-knot[k+1]) != 0)
			return (knot[k+d]-u)/(knot[k+d]-knot[k+1])*Blend(k+1,d-1,u,knot);
		else if ((knot[k+d-1]-knot[k]) != 0 && (knot[k+d]-knot[k+1]) == 0)
			return (u-knot[k])/(knot[k+d-1]-knot[k])*Blend(k,d-1,u,knot);
		else if ((knot[k+d-1]-knot[k]) != 0 && (knot[k+d]-knot[k+1]) != 0)
			return (u-knot[k])/(knot[k+d-1]-knot[k])*Blend(k,d-1,u,knot)+(knot[k+d]-u)/(knot[k+d]-knot[k+1])*Blend(k+1,d-1,u,knot);
		else
			return 0;
	}
}


void VeDuongCongBspline(GLfloat color[3])
{
	glColor3fv(color);
	int n = P.NumVert-1;
	const int d = 4;

	GLfloat *knot = (GLfloat *)calloc(n+d+1,sizeof(GLfloat));
	int j;
	
	// Tao vector knot khong deu
	for (j=0; j<n+d+1; j++)
		if (j<d)
			knot[j] = 0;
		else if (j<=n)
			knot[j] = j-d+1;
		else
			knot[j] = n-d+2;

	const int M = 200;
	int k, m;

	GLfloat u, du = (knot[n+d]-knot[0])/M;
	GLfloat x, y;

	glBegin(GL_POINTS);
	for (m=0; m<M; m++) {
		u = m*du;
		x = 0;
		y = 0;
		for (k=0; k<=n; k++) {
			x = x + P.Vert[k].x*Blend(k,d,u,knot);
			y = y + P.Vert[k].y*Blend(k,d,u,knot);
		}
		glVertex2f(x,y);
	}
	glEnd();
	free(knot);
	glFlush();
	return;
}


void VeDuongCongBsplineKhepKin(GLfloat color[3])
{
	glColor3fv(color);

	P.Vert[P.NumVert+2] = P.Vert[2];
	P.Vert[P.NumVert+1] = P.Vert[1];
	P.Vert[P.NumVert]   = P.Vert[0];
	P.NumVert = P.NumVert+3;

	VeDaGiac(color);

	int n = P.NumVert-1;
	const int d = 4;

	GLfloat *knot = (GLfloat *)calloc(n+d+1,sizeof(GLfloat));
	int j;
	
	// Tao vector knot deu
	for (j=0; j<n+d+1; j++)
		knot[j] = j;

	const int M = 200;
	int k, m;

	GLfloat u, du = (knot[n+d]-knot[0])/M;
	GLfloat umin = knot[d-1], umax = knot[n+1];

	GLfloat x, y;

	glBegin(GL_LINE_LOOP);
	for (m=0; m<M; m++) {
		u = m*du;
		if (umin <= u && u <= umax) {
			x = 0;
			y = 0;
			for (k=0; k<=n; k++) {
				x = x + P.Vert[k].x*Blend(k,d,u,knot);
				y = y + P.Vert[k].y*Blend(k,d,u,knot);
			}
			glVertex2f(x,y);
		}
	}
	glEnd();
	free(knot);
	glFlush();
	return;
}


void ProcessMenu(int value)
{
	GLfloat polygoncolor[] = {0,1,0};
	GLfloat bsplinecolor[] = {1,0,0};
	if (value == 0)
		VeDaGiac(polygoncolor);
	else if (value == 1)
		VeDuongCongBspline(bsplinecolor);
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
	glutAddMenuEntry("Ve Duong Cong Bspline",1);
	glutAttachMenu(GLUT_RIGHT_BUTTON);
	init();
	glutDisplayFunc(ComputerGraphics);
	glutMainLoop();
	return 0;
}

