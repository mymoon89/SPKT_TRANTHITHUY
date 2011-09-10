#ifndef FDRW_H
#define FDRW_H

#include "system.h"
#include "../userprog/syscall.h"
#include "fdbase.h"


class FDRw:public FDBase{
 public:
  FDRw(OpenFile *f);
  ~FDRw();

  int   fWrite(int virtAddr,int size);
  int   fRead(int virtAddr,int size);
  int   fClose();
  int   fSeek(int offset);
 private:
  OpenFile* file;
};
#endif
