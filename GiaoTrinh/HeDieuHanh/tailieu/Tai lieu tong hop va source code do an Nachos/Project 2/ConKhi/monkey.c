#include "syscall.h"
#include "monkey.h"
CreateSemaphore("WMutex", 1);
CreateSemaphore("EMutex", 1);
Monkey *WMonkey[10];
Monkey *EMonkey[10];
CreateSemaphore("Rope", 1);
int WQueue = 0;
int EQueue = 0;
/*id InitWQueue(int num)
{
	int i;
	while(i < num)
	{
		monkey[i] = new Monkey("WEST");
		i++;
	}
	WQueue = num;
}*/
void WestComing()
{
	wait("WMutex");
	Write("\n->1 Con khi tu huong Dong vua den cau<-\n", 70, ConsoleOutput);

	WQueue++;
	WMonkey[WQueue] = new Monkey("WEST");
	signal("WMutex");
}
void WestCross()
{
	while(TRUE)
	{
		wait("Rope");
		while(TRUE)
		{
			Write("\n***Mot con khi tu huong Dong dang qua cau***\n",70, ConsoleOutput);
			WMonkey[WQueue]->Cross("WEST");
			wait("WMutex");
			WQueue--;
			if(WQueue == 0)
				break;
			signal("WMutex");
		}
		signal("WMutex");
		signal("Rope");
	}
}
void EastComing()
{
	wait("EMutex");
	Write("\n->1 Con khi tu huong Tay vua den cau<-\n", 70, ConsoleOutput);
	EQueue++;
	EMonkey[EQueue] = new Monkey("EAST");
	signal("EMutex");
}

void EastCross()
{
	while(TRUE)
	{
		wait("Rope");
		while(TRUE)
		{
			Write("\n***Mot con khi tu huong Tay dang qua cau***\n",70, ConsoleOutput);
			EMonkey[EQueue]->Cross("EAST");
			wait("EMutex");
			EQueue--;
			if(EQueue == 0)
				break;
			signal("EMutex");
		}
		signal("EMutex");
		signal("Rope");
	}
}

void main()
{
	char strDepart[10];
	Write("\n*****Tien trinh khi den cau:*****\n", 50, ConsoleOutput);
	Write("Nhap huong den:",20,ConsoleOutput);
	Read(strDepart, 10, ConsoleInput);
	if(strcmp(strDepart, "WEST") == 0 )
		WestComing();
	else if(strcmp(strDepart, "EAST") == 0)
		EastComing();
	else
	{
		Write("\nBan da nhap sai huong!\n", 30, ConsoleOutput);
		Exit(1);
	}
	Write("\n*****Tien trinh khi qua cau*****\n", 50, ConsoleOutput);
	Write("Nhap huong den:",20,ConsoleOutput);
        Read(strDepart, 10, ConsoleInput);
        if(strcmp(strDepart, "WEST") == 0 )
                WestCross();
        else if(strcmp(strDepart, "EAST") == 0)
                EastCross();
        else
        {
                Write("\nBan da nhap sai huong!\n", 30, ConsoleOutput);
                Exit(1);
        }
	Exit(0);
}
