#ifndef FDENC_H
#define FDENC_H

#include "system.h"
#include "../userprog/syscall.h"
#include "fdbase.h"
#define  KEY 'a'

class FDEnc:public FDBase{
 public:
  FDEnc(OpenFile *f);
  ~FDEnc();

  int   fWrite(int virtAddr,int size);
  int   fRead(int virtAddr,int size);
  int   fClose();
  int   fSeek(int offset);
  char* Encypt(char*,int);
  char* Decrypt(char*,int);
 private:
  OpenFile* file;
};
#endif

