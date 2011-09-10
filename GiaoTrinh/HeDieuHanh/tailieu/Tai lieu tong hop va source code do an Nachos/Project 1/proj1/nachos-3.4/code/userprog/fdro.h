#ifndef FDRO_H
#define FDRO_H

#include "system.h"
#include "syscall.h"
#include "fdbase.h"
#include "../filesys/openfile.h"

class FDRo:public FDBase{
 public:
  FDRo(OpenFile *f);
  ~FDRo();

  int   fWrite(int virtAddr,int size);
  int   fRead(int virtAddr,int size);
  int   fClose();
  int   fSeek(int pos);
 private:
  OpenFile* file;
};
#endif

