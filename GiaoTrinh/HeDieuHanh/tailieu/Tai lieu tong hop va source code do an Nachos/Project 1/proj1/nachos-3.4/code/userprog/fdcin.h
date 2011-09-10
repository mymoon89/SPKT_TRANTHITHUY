#ifndef FDCIN_H
#define FDCIN_H

#include "system.h"
#include "../userprog/syscall.h"
#include "bitmap.h"
#include "fdbase.h"


class FDCin:public FDBase{
 public:
  FDCin();
  ~FDCin();

  int   fWrite(int virtAddr,int size);
  int   fRead(int virtAddr,int size);
  int   fClose();
  int   fSeek(int pos);
 private:
  OpenFile *file;
};
#endif
