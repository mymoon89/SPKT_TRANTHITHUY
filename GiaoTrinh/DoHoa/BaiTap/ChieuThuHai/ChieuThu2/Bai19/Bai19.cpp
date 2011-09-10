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

void PhepChieuSongSongTrucGiao(POINT3D P, POINT2D &Q)
{
	Q.x = P.x;
	Q.y = P.y;
	return;
}

void PhepQuayQuanhTrucX(POINT3D P1, POINT3D &P2, GLfloat theta)
{
	P2.y = P1.y*cos(theta) - P1.z*sin(theta);
	P2.z = P1.y*sin(theta) + P1.z*cos(theta);
	P2.x = P1.x;
	return;
}

void Normalization(POINT3D &V)
{
	GLfloat len = sqrt(V.x*V.x+V.y*V.y+V.z*V.z);
	V.x = V.x/len;
	V.y = V.y/len;
	V.z = V.z/len;
	return;
}

GLfloat DotProduct(POINT3D V1, POINT3D V2)
{
	return (V1.x*V2.x + V1.y*V2.y + V1.z*V2.z);
}


void DrawCylinder(void)
{
	GLfloat R = 100, A = 120;
	int M, N;
	GLfloat pi = 4.0*atan(1.0);
	GLfloat theta = 15*pi/180;
	GLfloat u,du;
	GLfloat v,dv;
	POINT3D P,P1;
	POINT2D Q;
	POINT3D NV; // Normal Vector
	POINT3D S={300,-300,300};
	POINT3D L;
	GLfloat I, Ia = 0.8, ka = 0.8, Ip = 0.8, kd = 0.8;

	int m, n;

	// Ve duong kinh tuyen - duong doc
	M = 700; N = 100;
	du = 2*pi/M;
	dv = 1.0/N;
	for (m=M; m>=0; m--) {
		u = m*du;
		glBegin(GL_LINE_STRIP);
		for (n=0; n<=N; n++) {
			v = n*dv;
			P.x = R*cos(u);
			P.y = A*v;
			P.z = R*sin(u);
			NV.x = cos(u);
			NV.y = 0;
			NV.z = sin(u);
			L.x = S.x - P.x;
			L.y = S.y - P.y;
			L.z = S.z - P.z;
			Normalization(NV);
			Normalization(L);
			if (DotProduct(NV,L) > 0)
				I = Ia*ka + Ip*kd*DotProduct(NV,L);
			else
				I = Ia*ka;

			PhepQuayQuanhTrucX(P,P1,theta);
			PhepChieuSongSongTrucGiao(P1,Q);
			glColor3f(I,0,0);
			glVertex2f(Q.x,Q.y);
		}
		glEnd();
	}
	glFlush();
	return;
}


void DrawCone(void)
{
	GLfloat R = 100, A = 120;
	int M, N;
	GLfloat pi = 4.0*atan(1.0);
	GLfloat theta = 15*pi/180;
	GLfloat u,du;
	GLfloat v,dv;
	POINT3D P,P1;
	POINT2D Q;

	glColor3f(1,0,0);
	int m, n;

	// Ve duong kinh tuyen - duong doc
	M = 20; N = 100;
	du = 2*pi/M;
	dv = 1.0/N;
	for (m=0; m<=M; m++) {
		u = m*du;
		glBegin(GL_LINE_STRIP);
		for (n=0; n<=N; n++) {
			v = n*dv;
			P.x = R*cos(u)*(1-v);
			P.y = A*v;
			P.z = R*sin(u)*(1-v);
			PhepQuayQuanhTrucX(P,P1,theta);
			PhepChieuSongSongTrucGiao(P1,Q);
			glVertex2f(Q.x,Q.y);
		}
		glEnd();
	}


	// Ve duong kinh tuyen - duong doc
	M = 100; N = 20;
	du = 2*pi/M;
	dv = 1.0/N;
	for (n=0; n<=N; n++) {
		v = n*dv;
		glBegin(GL_LINE_STRIP);
		for (m=0; m<=M; m++) {
			u = m*du;
			P.x = R*cos(u)*(1-v);
			P.y = A*v;
			P.z = R*sin(u)*(1-v);
			PhepQuayQuanhTrucX(P,P1,theta);
			PhepChieuSongSongTrucGiao(P1,Q);
			glVertex2f(Q.x,Q.y);
		}
		glEnd();
	}
	glFlush();
	return;
}


void DrawSphere(void)
{
	GLfloat R = 100;
	int M, N;
	GLfloat pi = 4.0*atan(1.0);
	GLfloat theta = 15*pi/180;
	GLfloat u,du;
	GLfloat v,dv;
	POINT3D P,P1;
	POINT2D Q;

	glColor3f(1,0,0);
	int m, n;

	// Ve duong kinh tuyen - duong doc
	M = 20; N = 100;
	du = 2*pi/M;
	dv = pi/N;
	for (m=0; m<=M; m++) {
		u = m*du;
		glBegin(GL_LINE_STRIP);
		for (n=-N/2; n<=N/2; n++) {
			v = n*dv;
			P.x = R*cos(v)*cos(u);
			P.y = R*sin(v);
			P.z = R*cos(v)*sin(u);
			PhepQuayQuanhTrucX(P,P1,theta);
			PhepChieuSongSongTrucGiao(P1,Q);
			glVertex2f(Q.x,Q.y);
		}
		glEnd();
	}


	// Ve duong kinh tuyen - duong doc
	M = 100; N = 20;
	du = 2*pi/M;
	dv = pi/N;
	for (n=-N/2; n<=N/2; n++) {
		v = n*dv;
		glBegin(GL_LINE_STRIP);
		for (m=0; m<=M; m++) {
			u = m*du;
			P.x = R*cos(v)*cos(u);
			P.y = R*sin(v);
			P.z = R*cos(v)*sin(u);
			PhepQuayQuanhTrucX(P,P1,theta);
			PhepChieuSongSongTrucGiao(P1,Q);
			glVertex2f(Q.x,Q.y);
		}
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
	DrawCoordinateAxis();
	DrawCylinder();
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
