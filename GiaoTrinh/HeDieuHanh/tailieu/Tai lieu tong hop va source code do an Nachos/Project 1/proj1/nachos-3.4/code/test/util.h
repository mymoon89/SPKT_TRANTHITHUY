#include "syscall.h"
#include "copyright.h"
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
  return;
}

void fprint(char* buf,int id)
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
        Write(buffer,1023,id);
        i = 0;
      }
    }
  Write(buffer,i,id);
  return;
}
