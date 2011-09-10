/*Begin DU~NG TRUNG TRAN*/
#ifndef FDTABLE_H
#define FDTABLE_H

#include "bitmap.h"
#include "fdbase.h"
#define  COUT 1
#define  CIN  0
#define  MAX  10
#define  WRFILE 0
#define  ROFILE 1
#define  ENCRYPTFILE 2

class FDTable{
 public:
  FDTable(int size);
  ~FDTable();
  void  createCout();
  void  createCin();
  int   fdWrite(int reg4,int reg5,int reg6);
  int   fdRead(int reg4,int reg5,int reg6);
  int   fdOpen(int reg4,int reg5,int reg6,OpenFile *of);
  int   fdClose(int reg4);
  int   fdSeek(int reg4,int reg5);
  int   GetMax();
  int   FindFreeSlot();
  bool  IsExist(int id);
 private:
  //int MAX;
  int tsize;
  BitMap *bm;
  FDBase *fTable[MAX];
};

#endif

/*End DU~NG TRUNG TRAN*/
