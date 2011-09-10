#include "fdrw.h"
#include "schandle.h"

FDRw::FDRw(OpenFile *f)
{
  file = f;
}

FDRw::~FDRw()
{
  if (file != NULL)
    delete file;
}

int FDRw::fClose()
{
  delete file;
  file = NULL;
  return 0;
}

int FDRw::fWrite(int virtAddr, int size)
{
  int rs = 0;
  int vA = virtAddr;
  int sz = size;

  if (sz < 0){
      printf("\n FDRw:fWrite Error unexpected bytes to write %d",size);
      return -1;
    }
  else if (sz == 0)
    return 0;

  char *buf = User2System(vA,sz);
  if (buf == NULL || buf == (char*)0)
    {
      printf("\n FDRw:fWrite Error- user memory space empty");
      if (buf != NULL) delete buf;
      return -1;
    }
  
  rs = file->Write(buf,strlen(buf));
  if (rs <= 0)
    printf("\n FDRw:fWrite Error - fail to write");

  delete buf;
  return rs;
}

int FDRw::fSeek(int offset)
{
  int length = file->Length();
  int pos = 0;
  if (offset < -1 || offset >= length){
    printf("\nFDRw:fSeek Error - unexpected offset %d",offset);
    return -1;
  }

  pos = file->Seek(offset);
  return pos;
}

int FDRw::fRead(int virtAddr,int size)
{
  int rs = 0;
  int vA = virtAddr;
  int sz = size;

  char *buf = new char[sz +1];

  ASSERT(buf != NULL);

  int bytesread = file->Read(buf,sz);
  if (bytesread < 0){
    printf("\n FDRw:fRead Error- read fail.");
    //    machine->WriteRegister(2,-1);
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

  //  machine->WriteRegister(2,rs);

  delete buf;
  return rs;
}
