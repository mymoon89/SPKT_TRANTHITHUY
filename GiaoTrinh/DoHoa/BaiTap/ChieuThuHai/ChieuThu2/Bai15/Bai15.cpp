#include <math.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <gl\glut.h>

int width = 800, height = 600;

typedef struct tagPOINT3D {
	GLfloat x, y, z;
} POINT3D;

typedef struct tagPOINT2D {
	GLfloat x, y;
} POINT2D;


#define MAXVERT 50
#define MAXEDGE 100

typedef struct tagWIREFRAME {
	int NumVert;
	int NumEdge;
	POINT3D Vert[MAXVERT];
	int	Edge[MAXEDGE][2];
} WIREFRAME;

void init(void)
{
    // Set clear color to white
    glClearColor(1.0f, 1.0f, 1.0f, 0.0f);
	glMatrixMode(GL_PROJECTION);
	glLoadIdentity();
	gluOrtho2D(-width/2,width/2,-height/2,height/2);
	return;
} 

void PhepChieuSongSongTrucGiao(POINT3D P, POINT2D &Q)
{
	Q.x = P.x;
	Q.y = P.y;
	return;
}

void PhepChieuSongSongXien(POINT3D P, POINT2D &Q)
{
	GLfloat L1 = 0.5;
	GLfloat pi = 4.0*atan(1.0);
	GLfloat phi = 45*pi/180;
	Q.x = P.x - P.z*L1*cos(phi);
	Q.y = P.y - P.z*L1*sin(phi);
	return;
}

void PhepBienDangZ(POINT3D P, POINT3D &Q)
{
	GLfloat L1 = 0.8;
	GLfloat pi = 4.0*atan(1.0);
	GLfloat phi = 30*pi/180;
	GLfloat shzx = -L1*cos(phi);
	GLfloat shzy = -L1*sin(phi);

	Q.x = P.x + P.z*shzx;
	Q.y = P.y + P.z*shzy;
	Q.z = P.z;
	return;
}

void PhepChieuPhoiCanh(POINT3D P, POINT2D &Q)
{
	GLfloat zprp = 600;
	Q.x = P.x*zprp/(zprp-P.z);
	Q.y = P.y*zprp/(zprp-P.z);
	return;
}

void PhepQuayQuanhTrucX(POINT3D P1, POINT3D &P2)
{
	GLfloat pi = 4.0*atan(1.0);
	GLfloat theta = 30*pi/180;
	P2.y = P1.y*cos(theta) - P1.z*sin(theta);
	P2.z = P1.y*sin(theta) + P1.z*cos(theta);
	P2.x = P1.x;
	return;
}

void PhepQuayQuanhTrucY(POINT3D P1, POINT3D &P2)
{
	GLfloat pi = 4.0*atan(1.0);
	GLfloat theta = 30*pi/180;
	P2.z = P1.z*cos(theta) - P1.x*sin(theta);
	P2.x = P1.z*sin(theta) + P1.x*cos(theta);
	P2.y = P1.y;
	return;
}

void PhepTinhTien(POINT3D P, POINT3D &Q)
{
	GLfloat tx=0, ty=0, tz = -100;
	Q.x = P.x + tx;
	Q.y = P.y + ty;
	Q.z = P.z + tz;
	return;
}


void DrawCube(void)
{
	WIREFRAME wr;
	wr.NumVert = 8;
	GLfloat scale = 100;
	int n;

	wr.Vert[0].x = 0; wr.Vert[0].y = 0; wr.Vert[0].z = 0;
	wr.Vert[1].x = 1; wr.Vert[1].y = 0; wr.Vert[1].z = 0;
	wr.Vert[2].x = 1; wr.Vert[2].y = 1; wr.Vert[2].z = 0;
	wr.Vert[3].x = 0; wr.Vert[3].y = 1; wr.Vert[3].z = 0;

	wr.Vert[4].x = 0; wr.Vert[4].y = 0; wr.Vert[4].z = 1;
	wr.Vert[5].x = 1; wr.Vert[5].y = 0; wr.Vert[5].z = 1;
	wr.Vert[6].x = 1; wr.Vert[6].y = 1; wr.Vert[6].z = 1;
	wr.Vert[7].x = 0; wr.Vert[7].y = 1; wr.Vert[7].z = 1;

	wr.NumEdge = 12;
	wr.Edge[0][0] = 0; 	wr.Edge[0][1] = 1; 
	wr.Edge[1][0] = 1; 	wr.Edge[1][1] = 2; 
	wr.Edge[2][0] = 2; 	wr.Edge[2][1] = 3;
	wr.Edge[3][0] = 3; 	wr.Edge[3][1] = 0;

	wr.Edge[4][0] = 4; 	wr.Edge[4][1] = 5;
	wr.Edge[5][0] = 5; 	wr.Edge[5][1] = 6;
	wr.Edge[6][0] = 6; 	wr.Edge[6][1] = 7;
	wr.Edge[7][0] = 7; 	wr.Edge[7][1] = 4;

	wr.Edge[8][0] = 0; 	wr.Edge[8][1] = 4;
	wr.Edge[9][0] = 1; 	wr.Edge[9][1] = 5;
	wr.Edge[10][0] = 2; wr.Edge[10][1] = 6;
	wr.Edge[11][0] = 3; wr.Edge[11][1] = 7;

	// Nhan voi he so ty le
	for (n=0; n<wr.NumVert; n++) {
		wr.Vert[n].x = scale*wr.Vert[n].x; 
		wr.Vert[n].y = scale*wr.Vert[n].y; 
		wr.Vert[n].z = scale*wr.Vert[n].z; 
	}

	POINT2D Q1, Q2;
	POINT3D P1, P2, P3, P4, P5, P6;

	glColor3f(1,0,0);
	for (n=0; n<wr.NumEdge; n++) {
		P1 = wr.Vert[wr.Edge[n][0]];
		P2 = wr.Vert[wr.Edge[n][1]];
		PhepBienDangZ(P1,P3);
		PhepBienDangZ(P2,P4);

		PhepTinhTien(P3,P5);
		PhepTinhTien(P4,P6);

		PhepChieuPhoiCanh(P5,Q1);
		PhepChieuPhoiCanh(P6,Q2);

		glBegin(GL_LINES);
		glVertex2f(Q1.x,Q1.y);
		glVertex2f(Q2.x,Q2.y);
		glEnd();
	}
	glFlush();
	return;
}


void DrawCoordinateAxis(void)
{
	glColor3f(1,0,0);
	glBegin(GL_LINES);
	glVertex2f(-1.0*width/2,0);
	glVertex2f(1.0*width/2,0);
	glVertex2f(0,-1.0*height/2);
	glVertex2f(0,1.0*height/2);
	glEnd();
	glFlush();
}


void ComputersGraphics(void)
{
	glClear(GL_COLOR_BUFFER_BIT);
	//DrawCoordinateAxis();
	DrawCube();
	glFlush();
}

int main(int argc, char **argv)
{
	glutInit(&argc, argv);
	glutInitDisplayMode(GLUT_SINGLE | GLUT_RGB);
	glutInitWindowPosition(10,10);
	glutInitWindowSize(width,height);
	glutCreateWindow("Computers Graphics With OpenGL Programming");
	init();
	glutDisplayFunc(ComputersGraphics);
	glutMainLoop();
	return 0;
}
