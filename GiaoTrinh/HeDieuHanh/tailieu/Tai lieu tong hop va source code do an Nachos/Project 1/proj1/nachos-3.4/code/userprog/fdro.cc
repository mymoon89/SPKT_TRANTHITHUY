#include "fdro.h"
#include "schandle.h"

FDRo::FDRo(OpenFile *f)
{
  file = f;
}
  
FDRo::~FDRo()
{
  if (file != NULL)
    delete file;
}

int FDRo::fClose()
{
  delete file;
  file = NULL;
  return 0;
}

int FDRo::fWrite(int virtAddr, int size)
{
  printf("\n Can't write to read-only file");
  return -1;
}  

int FDRo::fSeek(int offset)
{
  int length = file->Length();
  int pos;
  if (offset < -1 || offset >= length){
    printf("\nFDRo:fSeek Error - unexpected offset %d",offset);
    return -1;
  }

  pos = file->Seek(offset);
  return pos;
}

int FDRo::fRead(int virtAddr,int size)
{
  int rs = 0;
  int vA = virtAddr;
  int sz = size;
  
  char *buf = new char[sz +1];

  ASSERT(buf != NULL);

  int bytesread = file->Read(buf,sz);
  if (bytesread < 0){
    printf("\n FDRo:fRead Error- read fail.");
    //machine->WriteRegister(2,-1);
    delete buf;
    return -1;
  }  
  else if (bytesread == 0)
    {
      //  machine->WriteRegister(2,0 );
      delete buf;
      return 0;
    }
  
  rs = System2User(vA,bytesread,buf);

  //machine->WriteRegister(2,rs);

  delete buf;
  return rs;
}

