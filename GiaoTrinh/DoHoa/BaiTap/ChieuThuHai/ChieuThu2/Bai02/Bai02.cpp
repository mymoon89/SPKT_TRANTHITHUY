#include <windows.h>
#include <gl\glut.h>
#include <math.h>

int width  = 800;
int height = 600;

void init(void)
{
    // Set clear color to white
    glClearColor(1.0f, 1.0f, 1.0f, 0.0f);
	glMatrixMode(GL_PROJECTION);
	glLoadIdentity();
	gluOrtho2D(-width/2,width/2,-height/2,height/2);
	return;
}

void MidPointCircle(int r, int xc, int yc)
{
	glColor3f(1.0f, 0.0f, 0.0f);
	glPointSize(1.0);
	int x, y;
	int p = 5-4*r;
	glBegin(GL_POINTS);
	x = 0; y = r;
	glVertex2i(xc+x,yc+y);
	glVertex2i(xc+y,yc+x);
	glVertex2i(xc+y,yc-x);
	glVertex2i(xc+x,yc-y);
	glVertex2i(xc-x,yc-y);
	glVertex2i(xc-y,yc-x);
	glVertex2i(xc-y,yc+x);
	glVertex2i(xc-x,yc+y);
	while (x<y) {
		if (p<0) 
			p += 8*x+12;
		else {
			p += 8*x-8*y+20;
			y--;
		}
		x++;
		glVertex2i(xc+x,yc+y);
		glVertex2i(xc+y,yc+x);
		glVertex2i(xc+y,yc-x);
		glVertex2i(xc+x,yc-y);
		glVertex2i(xc-x,yc-y);
		glVertex2i(xc-y,yc-x);
		glVertex2i(xc-y,yc+x);
		glVertex2i(xc-x,yc+y);
	}
	glEnd();
}

void MidPointEllipse(int a, int b)
{
	int p = -4*a*a*b + a*a + 4*b*b;
	int x, y;
	x=0; y=b;
	glColor3f(1.0f, 0.0f, 0.0f);
	glPointSize(1.0);
	glBegin(GL_POINTS);
	glVertex2i(x,y);
	glVertex2i(x,-y);
	glVertex2i(-x,-y);
	glVertex2i(-x,y);
	while (a*a*y>b*b*x) {
		if (p<0)
			p = p + 8*b*b*x + 12*b*b;
		else {
			p = p + 8*b*b*x - 8*a*a*y + 8*a*a + 12*b*b;
			y--;
		}
		x++;
		glVertex2i(x,y);
		glVertex2i(x,-y);
		glVertex2i(-x,-y);
		glVertex2i(-x,y);
	}
	glColor3f(0.0f, 0.0f, 1.0f);
	p = 4*b*b*x*x+4*b*b*x+4*a*a*y*y-8*a*a*y+4*a*a+b*b-4*a*a*b*b;
	while (y>0) {
		if (p<0) {
			p = p + 8*b*b*x - 8*a*a*y + + 12*a*a + 8*b*b;
			x++;
		}
		else
			p = p - 8*a*a*y + 12*a*a;
		y--;
		glVertex2i(x,y);
		glVertex2i(x,-y);
		glVertex2i(-x,-y);
		glVertex2i(-x,y);
	}
	glEnd();
	return;
}



void ComputerGraphics(void)
{
	glClear(GL_COLOR_BUFFER_BIT);
	MidPointEllipse(300,200);
    glFlush(); 
	return;
}

int main(int argc, char *argv[])
{
	glutInit(&argc, argv);
	glutInitDisplayMode(GLUT_SINGLE | GLUT_RGB);
	glutInitWindowPosition(50,100);
	glutInitWindowSize(width+1,height+1);
	glutCreateWindow("Computer Graphics");
	init();
	glutDisplayFunc(ComputerGraphics);
	glutMainLoop();
	return 0;
}
