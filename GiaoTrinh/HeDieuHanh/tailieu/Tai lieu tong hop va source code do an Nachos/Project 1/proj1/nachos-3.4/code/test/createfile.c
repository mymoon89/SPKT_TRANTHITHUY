/* createfile.c
 *	Simple program to test whether running a user program works.
 *	
 *	Just do a "syscall" that shuts down the OS.
 *
 * 	NOTE: for some reason, user programs with global data structures 
 *	sometimes haven't worked in the Nachos environment.  So be careful
 *	out there!  One option is to allocate data structures as 
 * 	automatics within a procedure, but if you do this, you have to
 *	be careful to allocate a big enough stack to hold the automatics!
 */

#include "syscall.h"
#include "copyright.h"
#include "util.h"
#define maxlen 32

/*
#define IN 0
#define OUT 1

void print(char* buf)
{
  char buffer[1024];
  int j = 0 ;
  int i;
  for( i = 0 ; i < 1023 ;)
    {
      buffer[i] = buf[j];
      j ++;
      if (buffer[i] == 0)
	break;
      else if (buffer[i] == '~'){
	buffer[i] = 0;
	break;
      }
      i ++;
      if (i == 1023){
	buffer[i] = 0;
        Write(buffer,1023,OUT);
	i = 0;
      }
    }
  Write(buffer,i,OUT);
}
*/
int
main()
{
  int len;
  char filename[maxlen +1];

  /*Create a file*/
  print("\n Input file name:~");
  len = Read(filename,maxlen,IN);
 
  if (CreateFile(filename) == -1)
    {
      print("\nCreate file ~");
      
      print(filename);
      print(" fail.");
    }
  else 
    {
      print("\nCreate file ~");
      print(filename);
      print(" success.~");
    }
  
  Halt();
}
