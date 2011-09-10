#include "fdcout.h"
#include "schandle.h"

FDCout::FDCout(){
}

FDCout::~FDCout() 
{
  /*  delete file;
  char *filename = "stdout";
  ASSERT(fileSystem->Remove(filename) == TRUE);
  */
}

int   FDCout::fWrite(int virtAddr,int size)
{
  int addr = virtAddr;
  int sz = size;

  if (sz < 0){
    printf("\n FDCout:fWrite Error unexpected bytes to write %d",size);
    return -1;
  }
  else if (sz == 0)
    return 0;

  char *buf = User2System(addr,sz);
  if (buf == NULL || buf == (char*)0)
    {
      printf("\n FDCout:fWrite Error- user memory space empty");
      if (buf != NULL) delete buf;
      return -1;
    }
  int rs = gSynchConsole->Write(buf,strlen(buf));
  if (rs < 0)
    printf("FDCout:fWrite Error- SynchConsole write fail!..");

  delete buf;
  return rs;
}

int FDCout::fRead(int virtAddr,int size)
{
  printf("\n System msg: Can't read on standard output...");
  return -1;// can't read
}

int   FDCout::fClose()
{
  printf("\n System msg: Can't close standard output..."); 
  return -1;// can't close 
}

int   FDCout::fSeek(int pos)
{
  printf("\n System msg: Can't seeek on standard output...");
  return -1;
}
