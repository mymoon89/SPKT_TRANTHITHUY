#include "fdcin.h"
#include "schandle.h"
FDCin::FDCin()
{
  /*
  file = NULL;
  char *filename = "stdin";

  ASSERT(fileSystem->Create(filename,0) == TRUE);
  file = fileSystem->Open(filename);
  ASSERT(file == NULL);
  */
}

FDCin::~FDCin() 
{
  /*
  delete file;
  char *filename = "stdin";
  ASSERT(filename->Remove(filename) == TRUE);
  */
}

int   FDCin::fWrite(int virtAddr,int size)
{
  printf("\n System msg: Can't write to standard input...");
  return -1; // can't not
}

int FDCin::fRead(int virtAddr,int size)
{
  int addr = virtAddr;
  int si = size;
  char *buf = new char[si + 1];

  ASSERT(buf != NULL);

  int rs = gSynchConsole->Read(buf,si);
  
  // clean extra input
  if (rs == si && buf[rs] != 10){
    char temp[11];
    int len =  0;
    do{
      len = gSynchConsole->Read(temp,10);
    }  while (len == 10 && temp[len-1] != 10);
  }

  if (rs < 0){
    printf("FDCin:fRead Error- SynchConsole read fail!..");
    delete buf;
    return -1;
  }

  int rsl = System2User(addr,rs,buf);
  if (rsl < 0)
      printf("\n FDCin:Read:Error write to user space");

  //  machine->WriteRegister(2,rsl);

  delete buf;
  return rsl; 
}

int   FDCin::fClose()
{
  printf("\n System msg: Can't close standard input...");
  return -1;// can't close 
}

int   FDCin::fSeek(int pos)
{
  printf("\n System msg: Can't seek on standard input...");
  return -1;// can't seek
}


