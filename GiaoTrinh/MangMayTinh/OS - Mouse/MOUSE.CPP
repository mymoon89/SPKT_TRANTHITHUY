#include <stdio.h>
#include <dos.h>
#include <conio.h>
#include <graphics.h>

//Prototype
void DetechMouse();
void ShowMouse();
void HidingMouse();
void Detect();
void GetMousePosition();




union REGS in, out;

void DetectMouse()
{
	in.x.ax = 0;
	int86(0x33,&in,&out);
	if(out.x.ax == 0)
		printf("Mouse failed to initialized.");
	else
		printf("Mouse was succesfully initialized.");
}

void ShowMouse()
{
	in.x.ax = 1;
	int86(0x33,&in,&out);
	printf("\nMouse was showed.\n");
}

void HidingMouse()
{
	in.x.ax = 2;
	int86(0x33,&in,&out);
}

void Detect()
{
	int button;
	while(!kbhit())
	{
		in.x.ax = 3;
		int86(0x33,&in,&out);
		button = out.x.bx&7;
		switch(button)
		{
			case 1:
				printf("Left button pressed.\n");
				break;
			case 2:
				printf("Right button pressed.\n");
				break;
			case 3:
				printf("Left and Right button pressed.\n");
				break;
			case 4:
				printf("Middle button pressed.\n");
				break;
			case 5:
				printf("Left and Middle button pressed.\n");
				break;
			case 6:
				printf("Right and Middle button pressed.\n");
				break;
			case 7:
				printf("All the three buttons pressed.\n");
				break;
			default:
				printf("No button pressed\n");
		}
		delay(200); //Otherwise due to quick computer respond 100s of words will get print
	}
}


void GetMousePosition()
{
	int x,y;
	while(!kbhit())
	{
		in.x.ax = 3;
		int86(0x33,&in,&out);
		if(out.x.bx == 1)
		{
			x = out.x.cx;
			y = out.x.dx;
			printf("\nMOUSE POSITION:\n");
			printf("X:%d - Y:%d",x,y);
		}
		delay(200); //Otherwise due to quick computer respond 100s of words will get print
	}
}

void main()
{
	clrscr();
	DetectMouse();
	ShowMouse();
	//Detect();
        GetMousePosition();
	getch();
}