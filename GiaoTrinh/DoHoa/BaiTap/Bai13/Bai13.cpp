#include <math.h>
#include <gl\glut.h>

int width  = 800;
int height = 600;

int xmin = 50, xmax = 200, ymin = 50, ymax = 150;

GLdouble left_plane[] = {1,0,0,-xmin};
GLdouble top_plane[] = {0,-1,0,ymax};
GLdouble right_plane[] = {-1,0,0,xmax};
GLdouble bottom_plane[] = {0,1,0,-ymin};

#define MAXVERT 100

typedef struct tagPOINT {
	double x, y, z;
} POINT;

typedef struct tagPOLYGON {
	int NumVert;
	POINT Vert[MAXVERT];
} POLYGON;

POLYGON P = {0};
int count = 0;
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

void VeCuaSoXen(void)
{
	glColor3f(0,0,0);
	glBegin(GL_LINE_LOOP);
	glVertex2i(xmin, ymin);
	glVertex2i(xmax, ymin);
	glVertex2i(xmax, ymax);
	glVertex2i(xmin, ymax);
	glEnd();
	glFlush();
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
				P.Vert[P.NumVert].z = 0;
				P.NumVert++;
			}
	return;
}


void VeDaGiac(GLfloat color[3])
{
	Nhap = false;
	glColor3fv(color);
	glLineWidth(5);
	glBegin(GL_LINE_LOOP);
	for(int i = 0; i < P.NumVert; i++)
		glVertex2d(P.Vert[i].x,P.Vert[i].y); 
	glEnd();
	glFlush();
}


void Xen(GLfloat clipcolor[3])
{
	glClipPlane(GL_CLIP_PLANE0,left_plane);
	glClipPlane(GL_CLIP_PLANE1,top_plane);
	glClipPlane(GL_CLIP_PLANE2,right_plane);
	glClipPlane(GL_CLIP_PLANE3,bottom_plane);

	glEnable(GL_CLIP_PLANE0);
	glEnable(GL_CLIP_PLANE1);
	glEnable(GL_CLIP_PLANE2);
	glEnable(GL_CLIP_PLANE3);

	VeDaGiac(clipcolor);

	glDisable(GL_CLIP_PLANE0);
	glDisable(GL_CLIP_PLANE1);
	glDisable(GL_CLIP_PLANE2);
	glDisable(GL_CLIP_PLANE3);

	return;
}

void ProcessMenu(int value)
{
	GLfloat fillcolor[] = {0,1,0};
	GLfloat clipcolor[] = {1,0,0};
	if (value == 0)
		VeDaGiac(fillcolor);
	else if (value == 1)
		Xen(clipcolor);
	return;
}



void ComputerGraphics(void)
{
	glClear(GL_COLOR_BUFFER_BIT);
	VeCuaSoXen();
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
	glutAddMenuEntry("Xen",1);
	glutAttachMenu(GLUT_RIGHT_BUTTON);
	init();
	glutDisplayFunc(ComputerGraphics);
	glutMainLoop();
	return 0;
}

