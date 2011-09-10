/* copy.c
 * implement COPY user program
 */

#include "syscall.h"
#include "copyright.h"
#include "util.h"
#define MAXFILELEN  32
#define MAXLEN      256
#define READONLY 1
#define RW       0
#define ENCRYPT  2

int
main()
{
  char buffer[MAXLEN+1];
  char srcfile[MAXFILELEN + 1];
  char dstfile[MAXFILELEN + 1];

  char *msgsrc  = "\nSource file name:~";
  char *msgdst  = "\nDestination file name:~";

  char *msgout = "\nContent of file:\n~";
  int lensrc = 0;
  int lendst = 0;
  int fs = 0;
  int fd = 0;
  int lenbuf = 0 ;
  int rs = 0 ;
 
  /* Input source file name */
  do{
    Write("\nSrc file:",10,OUT);
    lensrc = Read(srcfile,MAXLEN,IN);
  }while(lensrc <= 0 );

  /* Input destination file name */
  do{
    Write("\nDst file:",10,OUT);
    lendst = Read(dstfile,MAXLEN,IN);
  }while(lendst == 0 );

  /*Open file to read*/

  fs  = Open(srcfile,READONLY);

  if (fs < 0) {
    Halt();
  }

  rs  = CreateFile(dstfile);
  if (rs != 0){
    Write(dstfile,lendst,OUT);
    Halt();
  }

  /*Open file to write*/
  
  fd  = Open(dstfile,RW);

  if (fd < 0) {
    Close(fs);
    Halt();
  }
  

  /*Read file data*/
  
  do {
    lenbuf = Read(buffer,MAXLEN,fs);    
    if (lenbuf >0 )
      Write(buffer,lenbuf,fd);

    if (lenbuf < MAXLEN) break;
  }while(1);
  
  print("\nCopy file success.~");
  
  /*close file*/  
  Close(fs);
  Close(fd);
  
  Halt();
}
