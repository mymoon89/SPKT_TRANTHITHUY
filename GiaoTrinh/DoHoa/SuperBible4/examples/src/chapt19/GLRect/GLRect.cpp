// GLRect.cpp
// OpenGL SuperBible, 
// Program by Richard S. Wright Jr.
// This program shows a very simple OpenGL program using
// the standard Win32 API function calls.

#include <windows.h>
#include <gl\gl.h>
#include <gl\glu.h>

// Initial square position and size
GLfloat x1 = 100.0f;
GLfloat y1 = 150.0f;
GLsizei rsize = 50;

// Step size in x and y directions
// (number of pixels to move each time)
GLfloat xstep = 1.0f;
GLfloat ystep = 1.0f;

// Keep track of windows changing width and height
GLfloat windowWidth;
GLfloat windowHeight;


static LPCTSTR lpszAppName = "GLRect";


// Declaration for Window procedure
LRESULT CALLBACK WndProc(	HWND 	hWnd,
							UINT	message,
							WPARAM	wParam,
							LPARAM	lParam);

// Set Pixel Format function - forward declaration
void SetDCPixelFormat(HDC hDC);


///////////////////////////////////////////
// Window has changed size
void ChangeSize(GLsizei w, GLsizei h)
	{
	// Prevent a divide by zero, when window is too short
	// (you cant make a window of zero width).
	if(h == 0)
		h = 1;

	// Set the viewport to be the entire window
    glViewport(0, 0, w, h);

	// Reset the coordinate system before modifying
    glLoadIdentity();


	// Keep the square square, this time, save calculated
	// width and height for later use
	if (w <= h) 
		{
		windowHeight = 250.0f*h/w;
		windowWidth = 250.0f;
		}
    else 
		{
		windowWidth = 250.0f*w/h;
		windowHeight = 250.0f;
		}

	// Set the clipping volume
	gluOrtho2D(0.0f, windowWidth, 0.0f, windowHeight);
	}


////////////////////////////////////////////////////////////////
// Called by timer routine to effect movement of the rectangle.
void IdleFunction(void)
	{
	// Reverse direction when you reach left or right edge
	if(x1 > windowWidth-rsize || x1 < 0)
		xstep = -xstep;

	// Reverse direction when you reach top or bottom edge
	if(y1 > windowHeight-rsize || y1 < 0)
		ystep = -ystep;


	// Check bounds.  This is incase the window is made
	// smaller and the rectangle is outside the new
	// clipping volume
	if(x1 > windowWidth-rsize)
		x1 = windowWidth-rsize-1;

	if(y1 > windowHeight-rsize)
		y1 = windowHeight-rsize-1;

	// Actually move the square
	x1 += xstep;
	y1 += ystep;
	}


/////////////////////////////////////////////////////////////
// Called to draw scene
void RenderScene(void)
	{
	// Set background clearing color to blue
	glClearColor(0.0f, 0.0f, 1.0f, 1.0f);
	
	// Clear the window with current clearing color
	glClear(GL_COLOR_BUFFER_BIT);

	// Set drawing color to Red, and draw rectangle at
	// current position.
	glColor3f(1.0f, 0.0f, 0.0f);
	glRectf(x1, y1, x1+rsize, y1+rsize);
	}



/////////////////////////////////////////////////////////////////
// Select the pixel format for a given device context
void SetDCPixelFormat(HDC hDC)
	{
	int nPixelFormat;

	static PIXELFORMATDESCRIPTOR pfd = {
		sizeof(PIXELFORMATDESCRIPTOR),	// Size of this structure
		1,								// Version of this structure	
		PFD_DRAW_TO_WINDOW |			// Draw to Window (not to bitmap)
		PFD_SUPPORT_OPENGL |			// Support OpenGL calls in window
		PFD_DOUBLEBUFFER,				// Double buffered mode
		PFD_TYPE_RGBA,					// RGBA Color mode
		32,								// Want 32 bit color 
		0,0,0,0,0,0,					// Not used to select mode
		0,0,							// Not used to select mode
		0,0,0,0,0,						// Not used to select mode
		16,								// Size of depth buffer
		0,								// Not used 
		0,								// Not used 
		0,	            				// Not used 
		0,								// Not used 
		0,0,0 };						// Not used 

	// Choose a pixel format that best matches that described in pfd
	nPixelFormat = ChoosePixelFormat(hDC, &pfd);

	// Set the pixel format for the device context
	SetPixelFormat(hDC, nPixelFormat, &pfd);
	}


//////////////////////////////////////////////////////////////////
// Entry point of all Windows programs
int APIENTRY WinMain(	HINSTANCE 	hInstance,
						HINSTANCE 	hPrevInstance,
						LPSTR 		lpCmdLine,
						int			nCmdShow)
	{
	MSG			msg;		// Windows message structure
	WNDCLASS	wc;			// Windows class structure
	HWND		hWnd;		// Storeage for window handle


	// Register Window style
	wc.style			= CS_HREDRAW | CS_VREDRAW | CS_OWNDC;
	wc.lpfnWndProc		= (WNDPROC) WndProc;
	wc.cbClsExtra		= 0;
	wc.cbWndExtra		= 0;
	wc.hInstance 		= hInstance;
	wc.hIcon			= NULL;
	wc.hCursor			= LoadCursor(NULL, IDC_ARROW);
	
	// No need for background brush for OpenGL window
	wc.hbrBackground	= NULL;		
	
	wc.lpszMenuName		= NULL;
	wc.lpszClassName	= lpszAppName;

	// Register the window class
	if(RegisterClass(&wc) == 0)
		return FALSE;


	// Create the main application window
	hWnd = CreateWindow(
				lpszAppName,
				lpszAppName,
				
				// OpenGL requires WS_CLIPCHILDREN and WS_CLIPSIBLINGS
				WS_OVERLAPPEDWINDOW | WS_CLIPCHILDREN | WS_CLIPSIBLINGS,
	
				// Window position and size
				100, 100,
				250, 250,
				NULL,
				NULL,
				hInstance,
				NULL);

	// If window was not created, quit
	if(hWnd == NULL)
		return FALSE;


	// Display the window
	ShowWindow(hWnd,SW_SHOW);
	UpdateWindow(hWnd);

	// Process application messages until the application closes
	while( GetMessage(&msg, NULL, 0, 0))
		{
		TranslateMessage(&msg);
		DispatchMessage(&msg);
		}

	return msg.wParam;
	}


//////////////////////////////////////////////////////////////
// Window procedure, handles all messages for this program
LRESULT CALLBACK WndProc(	HWND 	hWnd,
							UINT	message,
							WPARAM	wParam,
							LPARAM	lParam)
	{
	static HGLRC hRC = NULL;		// Permenant Rendering context
	static HDC hDC = NULL;			// Private GDI Device context

	switch (message)
	   	{
		// Window creation, setup for OpenGL
		case WM_CREATE:
			// Store the device context
			hDC = GetDC(hWnd);		

			// Select the pixel format
			SetDCPixelFormat(hDC);		

			// Create the rendering context and make it current
			hRC = wglCreateContext(hDC);
			wglMakeCurrent(hDC, hRC);

			// Create a timer that fires 30 times a second
			SetTimer(hWnd,33,1,NULL);
			break;

		// Window is being destroyed, cleanup
		case WM_DESTROY:
			// Kill the timer that we created
			KillTimer(hWnd,101);

			// Deselect the current rendering context and delete it
			wglMakeCurrent(hDC,NULL);
			wglDeleteContext(hRC);

			// Tell the application to terminate after the window
			// is gone.
			PostQuitMessage(0);
			break;

		// Window is resized.
		case WM_SIZE:
			// Call our function which modifies the clipping
			// volume and viewport
			ChangeSize(LOWORD(lParam), HIWORD(lParam));
			break;

		// Timer, moves and bounces the rectangle, simply calls
		// our previous OnIdle function, then invalidates the 
		// window so it will be redrawn.
		case WM_TIMER:
			{
			IdleFunction();
		
			InvalidateRect(hWnd,NULL,FALSE);
			}
			break;

		// The painting function.  This message sent by Windows 
		// whenever the screen needs updating.
		case WM_PAINT:
			{
			// Call OpenGL drawing code
			RenderScene();

			// Call function to swap the buffers
			SwapBuffers(hDC);

			// Validate the newly painted client area
			ValidateRect(hWnd,NULL);
			}
			break;


        default:   // Passes it on if unproccessed
            return (DefWindowProc(hWnd, message, wParam, lParam));

        }

    return (0L);
	}


