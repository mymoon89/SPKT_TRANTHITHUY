#include <windows.h>
#include <gl\glut.h>
#include <math.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>

int width  = 800;
int height = 600;

#define MAXVERT 100

typedef struct tagPOLYGON {
	int n;
	float v[MAXVERT][3];
} POLYGON;

POLYGON P = {0};

bool Nhap = TRUE;

void init(void)
{
    // Set clear color to white
    glClearColor(1.0f, 1.0f, 1.0f, 0.0f);
	glMatrixMode(GL_PROJECTION);
	gluOrtho2D(0,width,0,height);
	return;
} 
void ProcessMouse(int button, int state, int x, int y)
{
	if (button == GLUT_LEFT_BUTTON)
		if (state == GLUT_DOWN) 
			if (Nhap) {
				glColor3f(0,0,1);
				glPointSize(5);
				glBegin(GL_POINTS);
				glVertex2i(x,height-y);
				P.v[P.n][0] = x;
				P.v[P.n][1] = height-y;
				P.v[P.n][2] = 0;
				P.n++;
				glEnd();
				glFlush();
			}
	return;
}

void DrawPolygon(POLYGON P)
{
	Nhap = FALSE;
	glClear(GL_COLOR_BUFFER_BIT);
	glColor3f(1,0,0);
	glBegin(GL_LINE_LOOP);
	for (int i=0; i<P.n; i++) 
		glVertex2f(P.v[i][0],P.v[i][1]);
	glEnd();
	glFlush();
	return;
}

void FillPolygon(POLYGON P)
{
	/*
	GLubyte pattern[] = {
		0xFF,0x00,0xFF,0x00,
		0xFF,0x00,0xFF,0x00,
		0xFF,0x00,0xFF,0x00,
		0xFF,0x00,0xFF,0x00,
		0xFF,0x00,0xFF,0x00,
		0xFF,0x00,0xFF,0x00,
		0xFF,0x00,0xFF,0x00,
		0xFF,0x00,0xFF,0x00,

		0x00,0xFF,0x00,0xFF,
		0x00,0xFF,0x00,0xFF,
		0x00,0xFF,0x00,0xFF,
		0x00,0xFF,0x00,0xFF,
		0x00,0xFF,0x00,0xFF,
		0x00,0xFF,0x00,0xFF,
		0x00,0xFF,0x00,0xFF,
		0x00,0xFF,0x00,0xFF,

		0xFF,0x00,0xFF,0x00,
		0xFF,0x00,0xFF,0x00,
		0xFF,0x00,0xFF,0x00,
		0xFF,0x00,0xFF,0x00,
		0xFF,0x00,0xFF,0x00,
		0xFF,0x00,0xFF,0x00,
		0xFF,0x00,0xFF,0x00,
		0xFF,0x00,0xFF,0x00,
		0x00,0xFF,0x00,0xFF,
		0x00,0xFF,0x00,0xFF,
		0x00,0xFF,0x00,0xFF,
		0x00,0xFF,0x00,0xFF,
		0x00,0xFF,0x00,0xFF,
		0x00,0xFF,0x00,0xFF,
		0x00,0xFF,0x00,0xFF,
		0x00,0xFF,0x00,0xFF};
	*/
	GLubyte pattern[] = {
		0x00,0x01,0x80,0x00,
		0x00,0x03,0xC0,0x00,
		0x00,0x07,0xE0,0x00,
		0x00,0x0f,0xF0,0x00,
		
		0x00,0x00,0x00,0x00,
		0x00,0x00,0x00,0x00,
		0x00,0x00,0x00,0x00,
		0x00,0x00,0x00,0x00,

		0x00,0x00,0x00,0x00,
		0x00,0x00,0x00,0x00,
		0x00,0x00,0x00,0x00,
		0x00,0x00,0x00,0x00,

		0x00,0x00,0x00,0x00,
		0x00,0x00,0x00,0x00,
		0x00,0x00,0x00,0x00,
		0x00,0x00,0x00,0x00,

		0x00,0x00,0x00,0x00,
		0x00,0x00,0x00,0x00,
		0x00,0x00,0x00,0x00,
		0x00,0x00,0x00,0x00,

		0x00,0x00,0x00,0x00,
		0x00,0x00,0x00,0x00,
		0x00,0x00,0x00,0x00,
		0x00,0x00,0x00,0x00,

		0x00,0x00,0x00,0x00,
		0x00,0x00,0x00,0x00,
		0x00,0x00,0x00,0x00,
		0x00,0x00,0x00,0x00,

		0x00,0x00,0x00,0x00,
		0x00,0x00,0x00,0x00,
		0x00,0x00,0x00,0x00,
		0x00,0x00,0x00,0x00};



	Nhap = FALSE;
	glClear(GL_COLOR_BUFFER_BIT);
	glShadeModel(GL_FLAT);
	glPolygonStipple(pattern);
	glEnable(GL_POLYGON_STIPPLE);
	glBegin(GL_TRIANGLE_FAN);
	for (int i=0; i<P.n; i++) {
		if (i%2 == 0)
			glColor3f(0,1,0);
		else
			glColor3f(1,0,0);
		glVertex2f(P.v[i][0],P.v[i][1]);
	}
	glEnd();
	glDisable(GL_POLYGON_STIPPLE);
	glFlush();
	return;
}


GLbyte *MyLoadPPM(const char *szFileName, GLint *iWidth, GLint *iHeight, GLint *iComponents, GLenum *eFormat)
{
	int M, N, x, y, k;
	FILE *fp;          // Pointer to bits
	int  gray;
	char id[3];
	GLbyte	*pBits;
	GLbyte temp;
	fp = fopen(szFileName,"rb");
	fscanf(fp,"%s %d %d %d ",id,&N,&M,&gray);
	pBits = (GLbyte *)calloc(M*N*3,sizeof(GLbyte));
	fread(pBits,sizeof(GLbyte),M*N*3,fp);
	for (x=0; x<M; x++)
		for (y=0; y<N; y++) {
			k = (x*N+y)*3;
			temp = pBits[k];
			pBits[k] = pBits[k+2];
			pBits[k+2] = temp;
		}

	fclose(fp);
	*iWidth = N;
	*iHeight = M;
	return pBits;
}



void FillPolygonByImage(POLYGON P)
{
	// Init mode load image to polygon
	GLbyte *pBytes;
	GLint iWidth, iHeight, iComponents;
	GLenum eFormat;
	glClear(GL_COLOR_BUFFER_BIT);
	// Load texture
	glPixelStorei(GL_UNPACK_ALIGNMENT, 1);
	pBytes = MyLoadPPM("Stone.ppm", &iWidth, &iHeight, &iComponents, &eFormat);
	glTexImage2D(GL_TEXTURE_2D, 0, GL_RGB8, iWidth, iHeight, 0, GL_BGR_EXT, GL_UNSIGNED_BYTE, pBytes);
	free(pBytes);

	glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MIN_FILTER, GL_LINEAR);
	glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MAG_FILTER, GL_LINEAR);
	glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_S, GL_CLAMP);
	glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_T, GL_CLAMP);

	glTexEnvi(GL_TEXTURE_ENV, GL_TEXTURE_ENV_MODE, GL_DECAL);
	glEnable(GL_TEXTURE_2D);
	
	GLfloat xmin, ymin, xmax, ymax;
	xmin = P.v[0][0];
	xmax = P.v[0][0];

	ymin = P.v[0][1];
	ymax = P.v[0][1];
	for (int i=1; i<P.n; i++) {
		if (P.v[i][0] < xmin)
			xmin = P.v[i][0];

		if (P.v[i][0] > xmax)
			xmax = P.v[i][0];

		if (P.v[i][1] < ymin)
			ymin = P.v[i][1];

		if (P.v[i][1] > ymax)
			ymax = P.v[i][1];
	}

	glNormal3f(0.0f, 0.0f, -1.0f);
	glBegin(GL_POLYGON);
	for (int i=0; i<P.n; i++) {
		glTexCoord2f((P.v[i][0]-xmin)/(xmax-xmin),(ymax-P.v[i][1])/(ymax-ymin));
		glVertex3fv(P.v[i]);
	}

	glEnd();
	glDisable(GL_TEXTURE_2D);
	glFlush();
	return;
}


void ProcessMenu(int value)
{
	if (value == 0)
		DrawPolygon(P);
	else if (value == 1)
		FillPolygon(P);
	else if (value == 2)
		FillPolygonByImage(P);
	return;
}


void ComputerGraphics(void)
{
	// Clear the window with current clearing color
	glClear(GL_COLOR_BUFFER_BIT);
	glFlush(); 
	return;
}

int main(int argc, char *argv[])
{
	glutInit(&argc, argv);
	glutInitDisplayMode(GLUT_SINGLE | GLUT_RGB);
	glutInitWindowPosition(0,0);
	glutInitWindowSize(width,height);
	glutCreateWindow("Computer Graphics with OpenGL");

	init();
	glutMouseFunc(ProcessMouse);
	glutCreateMenu(ProcessMenu);
	glutAddMenuEntry("Draw Polygon", 0);
	glutAddMenuEntry("Fill Polygon", 1);
	glutAddMenuEntry("Fill Polygon By Image", 2);

	glutAttachMenu(GLUT_RIGHT_BUTTON);

	glutDisplayFunc(ComputerGraphics);
	glutMainLoop();
	return 0;
}

