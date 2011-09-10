#include <math.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <gl\glut.h>

int width = 800, height = 600;
int znear = 600, zfar = 1200;

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
	GLfloat pi = 4.0*atan(1.0);
	GLfloat theta = 2.0*atan(1.0*height/(2*znear));
	theta = theta*180/pi;

    // Set clear color to white
    glClearColor(1.0f, 1.0f, 1.0f, 0.0f);
	glMatrixMode(GL_PROJECTION);
	glLoadIdentity();
	//glOrtho(-width/2,width/2,-height/2,height/2,znear,zfar);

	//glFrustum(-width/2,width/2,-height/2,height/2,znear,zfar);
	gluPerspective(theta,1.0*width/height,znear,zfar);


	glMatrixMode(GL_MODELVIEW);
	glLoadIdentity();


	return;
} 


void DrawCube(void)
{

	GLfloat L1 = 0.5;
	GLfloat pi = 4.0*atan(1.0);
	GLfloat phi = 45*pi/180;
	GLfloat shzx = -L1*cos(phi);
	GLfloat shzy = -L1*sin(phi);
	GLfloat MShear[] = {1,0,0,0,
						0,1,0,0,
						shzx,shzy,1,0,
						0,0,0,1};


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

	POINT3D P1, P2;


	glPushMatrix();
	glTranslatef(0,0,-700);
	glMultMatrixf(MShear);

	//glRotatef(30,1,0,0);
	//glRotatef(30,0,1,0);

	glColor3f(1,0,0);
	for (n=0; n<wr.NumEdge; n++) {
		P1 = wr.Vert[wr.Edge[n][0]];
		P2 = wr.Vert[wr.Edge[n][1]];

		glBegin(GL_LINES);

		glVertex3f(P1.x,P1.y,P1.z);
		glVertex3f(P2.x,P2.y,P2.z);

		glEnd();
	}

	glPopMatrix();

	glFlush();
	return;
}


void DrawCoordinateAxis(void)
{
	
	glColor3f(1,0,0);
	glBegin(GL_LINES);
	glVertex3f(-1.0*width/2,0,-2);
	glVertex3f(1.0*width/2,0,-2);
	glVertex3f(0,-1.0*height/2,-2);
	glVertex3f(0,1.0*height/2,-2);
	glEnd();
	glFlush();
}


void ComputersGraphics(void)
{
	glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);
	//DrawCoordinateAxis();
	DrawCube();
	glFlush();
}

int main(int argc, char **argv)
{
	glutInit(&argc, argv);
	glutInitDisplayMode(GLUT_SINGLE | GLUT_RGB | GLUT_DEPTH);
	glutInitWindowPosition(10,10);
	glutInitWindowSize(width,height);
	glutCreateWindow("Computers Graphics With OpenGL Programming");
	init();
	glutDisplayFunc(ComputersGraphics);
	glutMainLoop();
	return 0;
}
