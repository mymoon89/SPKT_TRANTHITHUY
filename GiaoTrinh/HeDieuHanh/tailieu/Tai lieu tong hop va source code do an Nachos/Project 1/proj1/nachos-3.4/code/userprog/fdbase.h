#ifndef FDBASE_H
#define FDBASE_H

//#include "system.h"
//#include "syscall.h"
//#include "bitmap.h"


class FDBase{
 public:
  virtual ~FDBase() = 0;

  virtual int   fWrite(int virtAddr,int size) = 0;
  virtual int   fRead(int virtAddr,int size)  = 0;
  virtual int   fClose() = 0;
  virtual int   fSeek(int pos)  = 0;
 private:

};
#endif
