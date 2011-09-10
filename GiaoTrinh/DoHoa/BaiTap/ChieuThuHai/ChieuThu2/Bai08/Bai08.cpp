#include <gl\glut.h>
#include <math.h>

int width  = 800;
int height = 600;

bool Nhap = true;
bool NhapDiemCoDinh = false;
float m = 0.6;
float b = 100;


#define MAXVERT 100
typedef struct tagPOLYGON {
	int n;
	GLfloat V[MAXVERT][4];
} POLYGON;

POLYGON P = {0};

void DrawCompositionPolygon(POLYGON P, GLfloat F[3]);

void init(void)
{
    // Set clear color to white
    glClearColor(1.0f, 1.0f, 1.0f, 0.0f);
	glMatrixMode(GL_PROJECTION);
	glLoadIdentity();
	gluOrtho2D(-width/2,width/2,-height/2,height/2);
	P.n = 4;
	P.V[0][0] = 0;		P.V[0][1] = 0;		P.V[0][2] = 0; P.V[0][3] = 1;
	P.V[1][0] = 100;	P.V[1][1] = 0;		P.V[1][2] = 0; P.V[1][3] = 1;
	P.V[2][0] = 100;	P.V[2][1] = 100;	P.V[2][2] = 0; P.V[2][3] = 1;
	P.V[3][0] = 0;		P.V[3][1] = 100;	P.V[3][2] = 0; P.V[3][3] = 1;
	glMatrixMode(GL_MODELVIEW);
	glLoadIdentity();


	return;
}

void DrawAxisCoordinate(void)
{
	glColor3f(1,0,0);
	glBegin(GL_LINES);
	glVertex2i(0,-height/2);
	glVertex2i(0,height/2);
	glVertex2i(-width/2,0);
	glVertex2i(width/2,0);
	glEnd();
}

void DrawPolygon(POLYGON P)
{
	glColor3f(0,1,0);
	glBegin(GL_POLYGON);
	for (int i=0; i<P.n; i++)
		glVertex2f(P.V[i][0],P.V[i][1]);
	glEnd();
	glFlush();
	return;
}

void ErasePolygon(POLYGON P)
{
	glColor3f(1,1,1);
	glBegin(GL_POLYGON);
	for (int i=0; i<P.n; i++)
		glVertex2f(P.V[i][0],P.V[i][1]);
	glEnd();
	glFlush();
	return;
}


void Translation(POLYGON P)
{
	ErasePolygon(P);
	glTranslatef(200,100,0);
	DrawPolygon(P);
	return;
}

void Rotation(POLYGON P)
{
	ErasePolygon(P);
	glRotatef(45,0,0,1);
	DrawPolygon(P);
	return;
}

void Scaling(POLYGON P)
{
	ErasePolygon(P);
	glScalef(2,2,1);
	DrawPolygon(P);
	return;
}

void Composition(POLYGON P)
{
	ErasePolygon(P);
	glRotatef(-45,0,0,1);
	glScalef(1,2,1);
	glRotatef(45,0,0,1);
	DrawPolygon(P);
	return;
}

void DrawLine(void)
{
	glColor3f(1,0,0);
	glBegin(GL_LINES);
	glVertex2f(-1.0*width/2,-m*width/2+b);
	glVertex2f(1.0*width/2,m*width/2+b);
	glEnd();
	glFlush();
}

void GeneralReflection(POLYGON P)
{
	DrawAxisCoordinate();
	DrawLine();
	GLfloat pi = 4.0*atan(1.0);
	GLfloat theta = atan(m)*180/pi;

	P.n = 4;
	P.V[0][0] = 20; 	P.V[0][1] = 150;	P.V[0][2] = 0;	P.V[0][3] = 1;
	P.V[1][0] = 70; 	P.V[1][1] = 150;	P.V[1][2] = 0;	P.V[1][3] = 1;
	P.V[2][0] = 70; 	P.V[2][1] = 250;	P.V[2][2] = 0;	P.V[2][3] = 1;
	P.V[3][0] = 20; 	P.V[3][1] = 250;	P.V[3][2] = 0;	P.V[3][3] = 1;
	DrawPolygon(P);
	glTranslatef(0,b,0);
	glRotatef(theta,0,0,1);
	glRotatef(180,1,0,0);
	glRotatef(-theta,0,0,1);
	glTranslatef(0,-b,0);
	DrawPolygon(P);
	glFlush();
	return;
}





void ProcessMenu(int value)
{
	if (value == 0) {
		DrawPolygon(P);
	}

	else if (value == 1) {
		Translation(P);
	}
	else if (value == 2) {
		Rotation(P);
	}
	else if (value == 3) {
		Scaling(P);
	}
	else if (value == 4) {
		Composition(P);
	}
	else if (value == 5) {
		GeneralReflection(P);
	}

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
	glutInitWindowPosition(5,5);
	glutInitWindowSize(width+1,height+1);
	glutCreateWindow("Computer Graphics");
	glutCreateMenu(ProcessMenu);
	glutAddMenuEntry("Draw Polygon",0);
	glutAddMenuEntry("Translation",1);
	glutAddMenuEntry("Rotation",2);
	glutAddMenuEntry("Scaling",3);
	glutAddMenuEntry("Composition",4);
	glutAddMenuEntry("GeneralReflection",5);

	glutAttachMenu(GLUT_RIGHT_BUTTON);

	init();
	glutDisplayFunc(ComputerGraphics);
	glutMainLoop();
	return 0;
}

