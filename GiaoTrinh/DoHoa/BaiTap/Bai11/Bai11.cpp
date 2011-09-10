#include <math.h>
#include <gl\glut.h>

int width  = 800;
int height = 600;

int xmin = 50, xmax = 200, ymin = 50, ymax = 150;

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

void XenCanhLeft(POLYGON &P)
{
	// Them dinh cuoi cung bang dinh dau tien de de lap trinh
	P.Vert[P.NumVert] = P.Vert[0];
	POLYGON Q;
	Q.NumVert = 0;
	double y;
	for (int n=0; n<P.NumVert; n++) {
		/***************************************************/ 
		/* Truong hop 1: S va P nam hoan toan o mien trong */
		/*               Dinh P duoc them vao danh sach    */
		/***************************************************/
		if (P.Vert[n].x>=xmin && P.Vert[n+1].x>=xmin) {
			Q.Vert[Q.NumVert] = P.Vert[n+1];
			Q.NumVert++;
		}
		/****************************************************/ 
		/* Truong hop 2: S o mien trong va P o mien ngoai   */
		/*               Giao diem I duoc them vao danh sach*/
		/****************************************************/
		else if (P.Vert[n].x>=xmin && P.Vert[n+1].x<xmin) {
			y = 1.0*(P.Vert[n+1].y - P.Vert[n].y)*(xmin-P.Vert[n].x)/(P.Vert[n+1].x - P.Vert[n].x) + P.Vert[n].y;
			Q.Vert[Q.NumVert].x = xmin;
			Q.Vert[Q.NumVert].y = y;
			Q.NumVert++;
		}
		/****************************************************/ 
		/* Truong hop 3: S va P deu nam o mien ngoai        */
		/*               Ta khong them gi ca                */
		/****************************************************/
		/****************************************************/ 
		/* Truong hop 4: S nam ngoai, P nam o mien trong    */
		/*               Giao diem I va P duoc them vao ds  */
		/****************************************************/
		else if (P.Vert[n].x<xmin && P.Vert[n+1].x>=xmin) {
			y = 1.0*(P.Vert[n+1].y - P.Vert[n].y)*(xmin-P.Vert[n].x)/(P.Vert[n+1].x - P.Vert[n].x) + P.Vert[n].y;
			Q.Vert[Q.NumVert].x = xmin;
			Q.Vert[Q.NumVert].y = y;
			Q.NumVert++;
			Q.Vert[Q.NumVert] = P.Vert[n+1];
			Q.NumVert++;
		}
	}
	P = Q;
	return;
}
void XenCanhTop(POLYGON &P)
{
	// Them dinh cuoi cung bang dinh dau tien de de lap trinh
	P.Vert[P.NumVert] = P.Vert[0];
	POLYGON Q;
	Q.NumVert = 0;
	double x;
	for (int n=0; n<P.NumVert; n++) {
		/***************************************************/ 
		/* Truong hop 1: S va P nam hoan toan o mien trong */
		/*               Dinh P duoc them vao danh sach    */
		/***************************************************/
		if (P.Vert[n].y<=ymax && P.Vert[n+1].y<=ymax) {
			Q.Vert[Q.NumVert] = P.Vert[n+1];
			Q.NumVert++;
		}
		/****************************************************/ 
		/* Truong hop 2: S o mien trong va P o mien ngoai   */
		/*               Giao diem I duoc them vao danh sach*/
		/****************************************************/
		else if (P.Vert[n].y<=ymax && P.Vert[n+1].y>ymax) {
			x = (P.Vert[n+1].x - P.Vert[n].x)*(ymax-P.Vert[n].y)/(P.Vert[n+1].y - P.Vert[n].y) + P.Vert[n].x;
			Q.Vert[Q.NumVert].x = x;
			Q.Vert[Q.NumVert].y = ymax;
			Q.NumVert++;
		}
		/****************************************************/ 
		/* Truong hop 3: S va P deu nam o mien ngoai        */
		/*               Ta khong them gi ca                */
		/****************************************************/
		/****************************************************/ 
		/* Truong hop 4: S nam ngoai, P nam o mien trong    */
		/*               Giao diem I va P duoc them vao ds  */
		/****************************************************/
		else if (P.Vert[n].y>ymax && P.Vert[n+1].y<=ymax) {
			x = (P.Vert[n+1].x - P.Vert[n].x)*(ymax-P.Vert[n].y)/(P.Vert[n+1].y - P.Vert[n].y) + P.Vert[n].x;
			Q.Vert[Q.NumVert].x = x;
			Q.Vert[Q.NumVert].y = ymax;
			Q.NumVert++;
			Q.Vert[Q.NumVert] = P.Vert[n+1];
			Q.NumVert++;
		}
	}
	P = Q;
	return;
}

void XenCanhRight(POLYGON &P)
{
	// Them dinh cuoi cung bang dinh dau tien de de lap trinh
	P.Vert[P.NumVert] = P.Vert[0];
	POLYGON Q;
	Q.NumVert = 0;
	double y;
	for (int n=0; n<P.NumVert; n++) {
		/***************************************************/ 
		/* Truong hop 1: S va P nam hoan toan o mien trong */
		/*               Dinh P duoc them vao danh sach    */
		/***************************************************/
		if (P.Vert[n].x<=xmax && P.Vert[n+1].x<=xmax) {
			Q.Vert[Q.NumVert] = P.Vert[n+1];
			Q.NumVert++;
		}
		/****************************************************/ 
		/* Truong hop 2: S o mien trong va P o mien ngoai   */
		/*               Giao diem I duoc them vao danh sach*/
		/****************************************************/
		else if (P.Vert[n].x<=xmax && P.Vert[n+1].x>xmax) {
			y = (P.Vert[n+1].y - P.Vert[n].y)*(xmax-P.Vert[n].x)/(P.Vert[n+1].x - P.Vert[n].x) + P.Vert[n].y;
			Q.Vert[Q.NumVert].x = xmax;
			Q.Vert[Q.NumVert].y = y;
			Q.NumVert++;
		}
		/****************************************************/ 
		/* Truong hop 3: S va P deu nam o mien ngoai        */
		/*               Ta khong them gi ca                */
		/****************************************************/
		/****************************************************/ 
		/* Truong hop 4: S nam ngoai, P nam o mien trong    */
		/*               Giao diem I va P duoc them vao ds  */
		/****************************************************/
		else if (P.Vert[n].x>xmax && P.Vert[n+1].x<=xmax) {
			y = (P.Vert[n+1].y - P.Vert[n].y)*(xmax-P.Vert[n].x)/(P.Vert[n+1].x - P.Vert[n].x) + P.Vert[n].y;
			Q.Vert[Q.NumVert].x = xmax;
			Q.Vert[Q.NumVert].y = y;
			Q.NumVert++;
			Q.Vert[Q.NumVert] = P.Vert[n+1];
			Q.NumVert++;
		}
	}
	P = Q;
	return;
}


void XenCanhBottom(POLYGON &P)
{
	// Them dinh cuoi cung bang dinh dau tien de de lap trinh
	P.Vert[P.NumVert] = P.Vert[0];
	POLYGON Q;
	Q.NumVert = 0;
	double x;
	for (int n=0; n<P.NumVert; n++) {
		/***************************************************/ 
		/* Truong hop 1: S va P nam hoan toan o mien trong */
		/*               Dinh P duoc them vao danh sach    */
		/***************************************************/
		if (P.Vert[n].y>=ymin && P.Vert[n+1].y>=ymin) {
			Q.Vert[Q.NumVert] = P.Vert[n+1];
			Q.NumVert++;
		}
		/****************************************************/ 
		/* Truong hop 2: S o mien trong va P o mien ngoai   */
		/*               Giao diem I duoc them vao danh sach*/
		/****************************************************/
		else if (P.Vert[n].y>=ymin && P.Vert[n+1].y<ymin) {
			x = (P.Vert[n+1].x - P.Vert[n].x)*(ymin-P.Vert[n].y)/(P.Vert[n+1].y - P.Vert[n].y) + P.Vert[n].x;
			Q.Vert[Q.NumVert].x = x;
			Q.Vert[Q.NumVert].y = ymin;
			Q.NumVert++;
		}
		/****************************************************/ 
		/* Truong hop 3: S va P deu nam o mien ngoai        */
		/*               Ta khong them gi ca                */
		/****************************************************/
		/****************************************************/ 
		/* Truong hop 4: S nam ngoai, P nam o mien trong    */
		/*               Giao diem I va P duoc them vao ds  */
		/****************************************************/
		else if (P.Vert[n].y<ymin && P.Vert[n+1].y>=ymin) {
			x = (P.Vert[n+1].x - P.Vert[n].x)*(ymin-P.Vert[n].y)/(P.Vert[n+1].y - P.Vert[n].y) + P.Vert[n].x;
			Q.Vert[Q.NumVert].x = x;
			Q.Vert[Q.NumVert].y = ymin;
			Q.NumVert++;
			Q.Vert[Q.NumVert] = P.Vert[n+1];
			Q.NumVert++;
		}
	}
	P = Q;
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
	XenCanhLeft(P);
	XenCanhTop(P);
	XenCanhRight(P);
	XenCanhBottom(P);
	VeDaGiac(clipcolor);
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

