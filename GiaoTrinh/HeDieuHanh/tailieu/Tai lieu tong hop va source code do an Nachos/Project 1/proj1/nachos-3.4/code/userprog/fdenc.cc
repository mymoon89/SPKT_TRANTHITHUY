#include "fdenc.h"
#include "schandle.h"

FDEnc::FDEnc(OpenFile *f)
{
  file = f;
}

FDEnc::~FDEnc()
{
  if (file != NULL)
    delete file;
}

int FDEnc::fClose()
{
  delete file;
  file = NULL;
  return 0;
}

int FDEnc::fWrite(int virtAddr, int size)
{
  int rs = 0;
  int vA = virtAddr;
  int sz = size;

  if (sz < 0){
    printf("\n FDEnc:fWrite Error unexpected bytes to write %d",size);
    return -1;
  }
  else if (sz == 0)
    return 0;

  char *buf = User2System(vA,sz);
  if (buf == NULL || buf == (char*)0)
    {
      printf("\n FDEnc:fWrite Error- user memory space empty");
      if (buf != NULL) delete buf;
      return -1;
    }

  char *enbuf = Encypt(buf,strlen(buf));

  /*printf("%s",enbuf);*/
  rs = file->Write(enbuf,strlen(enbuf));
  if (rs <= 0)
    printf("\n FDEnc:fWrite Error - fail to write");

  delete buf;
  delete enbuf;
  return rs;
}

int FDEnc::fSeek(int offset)
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

int FDEnc::fRead(int virtAddr,int size)
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

  char *debuf = Decrypt(buf,bytesread);

  rs = System2User(vA,strlen(debuf),debuf);

  //  machine->WriteRegister(2,rs);

  delete buf;
  delete debuf;
  return rs;
}

char* FDEnc::Encypt(char* buf,int size)
{
  char *buffer = new char[size+1];
  ASSERT(buffer != NULL)
  
  int code[256];  
  for (int i = 0 ;i < 255 ; i++)
    code[i] = i+4;

    for (int i = 0 ; i < size ; i++){
      buffer[i] = code[(unsigned char)buf[i]];//^KEY;
    }  
  buffer[size] = 0;
  return buffer;
}

char* FDEnc::Decrypt(char* buf,int size)
{
  char *buffer = new char[size+1];
  ASSERT(buffer != NULL)

  int code[260];
  for (int i = 0 ;i < 260 ; i++)
    code[i] = i-4;

    for (int i = 0 ; i < size ; i++){
      buffer[i] = code[(unsigned char)buf[i]];//^KEY;
    }
  buffer[size] = 0;
  return buffer;
}
