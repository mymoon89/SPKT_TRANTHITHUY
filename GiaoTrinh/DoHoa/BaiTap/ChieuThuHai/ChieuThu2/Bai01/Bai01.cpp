#include <windows.h>
#include <gl\glut.h>
#include <math.h>


void init(void)
{
    // Set clear color to white
    glClearColor(1.0f, 1.0f, 1.0f, 0.0f);
	return;
}

void ChangeSize(GLsizei w, GLsizei h)
{
	GLfloat aspectRatio;
// Prevent a divide by zero
	if(h == 0)
		h = 1;
// Set Viewport to window dimensions
	glViewport(0, 0, w, h);
// Reset coordinate system
	glMatrixMode(GL_PROJECTION);
	glLoadIdentity();
	gluOrtho2D(0,0,w,h);
	// Establish clipping volume (left, right, bottom, top, near, far)
}


int Round(double a)
{
	return (a+0.5);
}


void points(void)
{
	int x;
	int y;
	glClear(GL_COLOR_BUFFER_BIT);

   	// Set current drawing color to red
	//		   R	 G	   B
	glColor3f(1.0f, 0.0f, 0.0f);
	GLfloat sizes[2]; // Store supported point size range
	GLfloat step; // Store supported point size increments
	// Get supported point size range and step size
	glPointSize(1.0);
	glGetFloatv(GL_POINT_SIZE_RANGE,sizes);
	glGetFloatv(GL_POINT_SIZE_GRANULARITY,&step);
	
	glBegin(GL_POINTS);
		x=0; y=0;
		glVertex2i(x,y);
		while (x<200) {
			x = x + 1;
			y = Round(1.0*x/3);
			glVertex2i(x,y);
		}
	glEnd();
	glFlush();
	return;
}




void lineSegment(void)
{

	glEnable(GL_LINE_STIPPLE);

	// Clear the window with current clearing color
	glClear(GL_COLOR_BUFFER_BIT);

   	// Set current drawing color to red
	//		   R	 G	   B
	glColor3f(1.0f, 0.0f, 0.0f);
	
	glLineWidth(5.0);
	GLint factor = 5;			// Stippling factor
	GLushort pattern = 0x88FF;	// Stipple pattern
	glLineStipple(factor,pattern);

	glBegin(GL_LINES);
		glVertex2i(15,15);
		glVertex2i(180,15);
	glEnd();
	// Flush drawing commands
    glFlush(); 
	glDisable(GL_LINE_STIPPLE);

	return;
}

int main(int argc, char *argv[])
{
	glutInit(&argc, argv);
	glutInitDisplayMode(GLUT_SINGLE | GLUT_RGB);
	glutInitWindowPosition(50,100);
	glutInitWindowSize(400,300);
	glutCreateWindow("An Example OpenGL Programming");
	glutDisplayFunc(points);
	glutReshapeFunc(ChangeSize);
	init();
	glutMainLoop();

	return 0;
}
