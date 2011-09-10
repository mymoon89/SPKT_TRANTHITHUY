#ifndef FDCOUT_H
#define FDCOUT_H

#include "system.h"
//#include "syscall.h"
#include "bitmap.h"
#include "fdbase.h"


class FDCout:public FDBase{
 public:
  FDCout();
  ~FDCout();

  int   fWrite(int virtAddr,int size);
  int   fRead(int virtAddr,int size);
  int   fClose();
  int   fSeek(int pos);
 private:
  OpenFile* file;
};
#endif
