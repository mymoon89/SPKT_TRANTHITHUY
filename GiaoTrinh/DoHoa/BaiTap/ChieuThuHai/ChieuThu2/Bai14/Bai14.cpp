#include <windows.h>
#include <math.h>
#include <gl\glut.h>

int width  = 800;
int height = 600;

int xmin = 50, xmax = 200, ymin = 50, ymax = 150;

GLdouble left_equation[] = {1,0,0,-xmin};
GLdouble top_equation[]  = {0,-1,0,ymax};
GLdouble right_equation[] = {-1,0,0,xmax};
GLdouble bottom_equation[] = {0,1,0,-ymin};

typedef GLvoid (_stdcall *CallBack)();


#define MAXVERT 100

typedef struct tagPOINT3D {
	double x, y, z;
} POINT3D;

typedef struct tagPOLYGON {
	int NumVert;
	POINT3D Vert[MAXVERT];
} POLYGON;

POLYGON P = {0};
int count = 0;
bool Nhap = true;

GLdouble vertex[MAXVERT][3];

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
void tessError(GLenum error)
{
	// Get error message string
	const char *szError = (const char *)gluErrorString(error);

	// Set error message as window caption
	glutSetWindowTitle(szError);
}


void VeDaGiac(GLfloat color[3])
{
	Nhap = false;
	for (int i=0; i<P.NumVert; i++) {
		vertex[i][0] = P.Vert[i].x;
		vertex[i][1] = P.Vert[i].y;
		vertex[i][2] = P.Vert[i].z;
	}

	glColor3fv(color);

	// Tesselator object
	GLUtesselator *pTess;
	// Buoc 1 
	// Create the tesselator object
	pTess = gluNewTess();

	// Buoc 2 Thiet lap cac ham callback
	// Set callback functions
	// Just call glBegin at begining of triangle batch
	gluTessCallback(pTess, GLU_TESS_BEGIN, (CallBack)glBegin); 

	// Just call glEnd at end of triangle batch
	gluTessCallback(pTess, GLU_TESS_END, (CallBack)glEnd);

	// Just call glVertex3dv for each  vertex
	gluTessCallback(pTess, GLU_TESS_VERTEX, (CallBack)glVertex3dv);

	// Register error callback
	gluTessCallback(pTess, GLU_TESS_ERROR, (CallBack)tessError);

	// Begin the polygon
	gluTessBeginPolygon(pTess, NULL);

	// the one and only contour
	gluTessBeginContour(pTess);
	// Feed in the list of vertices
	for(int i = 0; i < P.NumVert; i++) {
		gluTessVertex(pTess, vertex[i], vertex[i]); // Can't be NULL
	}
	// Close contour and polygon
	gluTessEndContour(pTess);

	gluTessEndPolygon(pTess);
	gluDeleteTess(pTess);
	glFlush();
	
}


void Xen(GLfloat clipcolor[3])
{
	glClipPlane(GL_CLIP_PLANE0,left_equation);
	glEnable(GL_CLIP_PLANE0);
	
	glClipPlane(GL_CLIP_PLANE1,top_equation);
	glEnable(GL_CLIP_PLANE1);

	glClipPlane(GL_CLIP_PLANE2,right_equation);
	glEnable(GL_CLIP_PLANE2);

	glClipPlane(GL_CLIP_PLANE3,bottom_equation);
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

