#include <windows.h>
#include <gl\glut.h>
#include <math.h>

int width  = 800;
int height = 600;


#define MAXVERT 100
#define MAXEDGE 100

typedef struct tagVERTEX3F {
	double x;
	double y;
	double z;
} VERTEX3F;

typedef struct tagPOLYGON {
	int n;
	VERTEX3F V[MAXVERT];
} POLYGON;

typedef struct tagEDGE {
	double x1, y1, x2, y2;
	double xmin, xmax, ymin, ymax;
	double a, b, c;
} EDGE;

typedef struct tagEDGELIST {
	int n;
	EDGE E[MAXEDGE];
} EDGELIST;

POLYGON P={0};
POLYGON P1={0};
POLYGON P2={0};

BOOL Ve = TRUE;
int m;


BOOL SplitConcavePolygon(POLYGON P, POLYGON &P1, POLYGON &P2);


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
	else if (value == 2)
		SplitConcavePolygon(P, P1, P2);
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



BOOL Intersection(VERTEX3F &V, EDGE E1, EDGE E2)
{
	double a1, b1, c1, a2, b2, c2;
	a1 = E1.a;
	b1 = E1.b;
	c1 = E1.c;

	a2 = E2.a;
	b2 = E2.b;
	c2 = E2.c;

	if (fabs(a1*b2 - a2*b1) > 1.0E-6) {
		V.x = (b1*c2-b2*c1)/(a1*b2 - a2*b1);
		V.y = (a2*c1-a1*c2)/(a1*b2 - a2*b1);
		V.z = 0;
		return TRUE;
	}
	return FALSE;
}

BOOL SplitConcavePolygon(POLYGON P, POLYGON &P1, POLYGON &P2)
{
	int m;
	BOOL result;
	EDGELIST EdgeList;
	EdgeList.n = P.n;
	int n = P.n;
	int i, j, k, count;
	double x1,y1,x2,y2,xmin,xmax,ymin,ymax,a,b,c;
	VERTEX3F V;
	EDGE E1, E2;
	// Tao danh sach cac canh
	for (i=0; i<n; i++) {
		x1 = P.V[Mod(i,n)].x;
		y1 = P.V[Mod(i,n)].y;
		x2 = P.V[Mod(i+1,n)].x;
		y2 = P.V[Mod(i+1,n)].y;
		if (x1 < x2) {
			xmin = x1;
			xmax = x2;
		}
		else {
			xmin = x2;
			xmax = x1;
		}

		if (y1 < y2) {
			ymin = y1;
			ymax = y2;
		}
		else {
			ymin = y2;
			ymax = y1;
		}
		a = y2-y1;
		b = -(x2-x1);
		c = -x1*(y2-y1) + y1*(x2-x1);
		EdgeList.E[Mod(i,n)].x1 = x1;
		EdgeList.E[Mod(i,n)].y1 = y1;
		EdgeList.E[Mod(i,n)].x2 = x2;
		EdgeList.E[Mod(i,n)].y2 = y2;
		EdgeList.E[Mod(i,n)].xmin = xmin;
		EdgeList.E[Mod(i,n)].xmax = xmax;
		EdgeList.E[Mod(i,n)].ymin = ymin;
		EdgeList.E[Mod(i,n)].ymax = ymax;
		EdgeList.E[Mod(i,n)].a = a;
		EdgeList.E[Mod(i,n)].b = b;
		EdgeList.E[Mod(i,n)].c = c;
	}

	result = IdentifyConcavePolygon(P, m);

	if (result) {
		P1.V[0] = P.V[Mod(m,n)];
		P1.V[1] = P.V[Mod(m+1,n)];
		P1.n = 2;
		j = m+1;
		E1 = EdgeList.E[Mod(m-1,n)];
		for (count =0; count<n-3; count++) {
			E2 = EdgeList.E[Mod(j,n)];
			if (Intersection(V,E1,E2)) {
				xmin = E2.xmin;
				xmax = E2.xmax;
				ymin = E2.ymin;
				ymax = E2.ymax;
				if ((xmin <= V.x && V.x <= xmax) && (ymin <= V.y && V.y <= ymax)) {
					P1.V[P1.n] = V;
					P1.n++;
					glColor3f(1,0,0);
					glLineWidth(5);
					glBegin(GL_LINE_LOOP);
					for (k=0; k<P1.n; k++)
						glVertex2f(P1.V[k].x,P1.V[k].y);
					glEnd();
					glFlush();
					// Tao ra da giac P2
					P2.V[P2.n] = V;
					P2.n++;
					P2.V[P2.n].x = E2.x2;
					P2.V[P2.n].y = E2.y2;
					P2.V[P2.n].z = 0;
					P2.n++;
					count++;
					j++;
					for (k=count; k<n-2; k++) {
						E2 = EdgeList.E[Mod(j,n)];
						P2.V[P2.n].x = E2.x2;
						P2.V[P2.n].y = E2.y2;
						P2.V[P2.n].z = 0;
						P2.n++;
						j++;
					}
					glColor3f(0,0,1);
					glLineWidth(5);
					glBegin(GL_LINE_LOOP);
					for (k=0; k<P2.n; k++)
						glVertex2f(P2.V[k].x,P2.V[k].y);
					glEnd();
					glFlush();
					return TRUE;
				}
				else {	
					P1.V[P1.n].x  = E2.x2;
					P1.V[P1.n].y  = E2.y2;
					P1.V[P1.n].z  = 0;
					P1.n++;
				}
			}
			else {
				P1.V[P1.n].x  = E2.x2;
				P1.V[P1.n].y  = E2.y2;
				P1.V[P1.n].z  = 0;
				P1.n++;
			}
			j++;
		}
	}
	return FALSE;
}
