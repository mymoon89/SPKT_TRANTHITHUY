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
	glOrtho(-width/2,width/2,-height/2,height/2,-width,width);
	glMatrixMode(GL_MODELVIEW);
	glLoadIdentity();

	return;
}


void DrawCube(void)
{	
	glPushMatrix();
	glRotatef(30,1,0,0);
	glRotatef(30,0,1,0);
	glColor3f(0,0,1);
	glutWireCube(100);
	glPopMatrix();
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


void ComputerGraphics(void)
{
	glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);
	DrawAxisCoordinate();
	DrawCube();
	glTranslatef(200,200,0);
	DrawCube();
	glFlush(); 
	return;
}

int main(int argc, char *argv[])
{
	glutInit(&argc, argv);
	glutInitDisplayMode(GLUT_SINGLE | GLUT_RGB | GLUT_DEPTH);
	glutInitWindowPosition(50,50);
	glutInitWindowSize(width+1,height+1);
	glutCreateWindow("Computer Graphics");
	init();
	glutDisplayFunc(ComputerGraphics);
	glutMainLoop();
	return 0;
}
