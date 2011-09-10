// Begin DU~NG TRUNG TRAN
#include "fdtable.h"
#include "fdcout.h"
#include "fdcin.h"
#include "schandle.h"
#include "fdenc.h"
#include "fdrw.h"
#include "fdro.h"
#include "fdenc.h"

//Constructor
FDTable:: FDTable(int size)
{
  ASSERT (size >= 2);
    
  bm = NULL;
  bm = new BitMap(size);
  ASSERT(bm != NULL);

  tsize = size;

  for (int i =0 ; i < size; i++)
    {
      fTable[i] = NULL;
    }
  createCout();
  createCin();
}

//Destructor
FDTable::~FDTable()
{
  for (int i =0 ; i < tsize; i++)
    {
      if (bm->Test(i))
	{
	  delete fTable[i];
	  fTable[i] = NULL;
	}
    }  
  delete bm;
  tsize = 0 ;
}


/*
Input: 
Output: 
Purpose: create standard console output
*/
void FDTable::createCout()
{
  bm->Mark(COUT);  
  fTable[COUT] = new FDCout();
}

/*
Input:
Output:
Purpose: create standard console input
*/
void FDTable::createCin(){
  bm->Mark(CIN);
  fTable[CIN] = new FDCin(); 
}

/*
Input:
Output:
Purpose: write to console output or file
*/
int   FDTable::fdWrite(int reg4,int reg5,int reg6)
{
  int rs = 0;
  int virtAddr = reg4;
  int size = reg5;
  int id = reg6;

  rs = fTable[id]->fWrite(virtAddr,size);
   
  return rs;
}

/*
Input:
Output:
Purpose: read from a standard console input or a file
*/
int   FDTable::fdRead(int reg4,int reg5,int reg6)
{
  int rs = 0;
  int virtAddr = reg4;
  int size = reg5;
  int id = reg6;
 
  rs = fTable[id]->fRead(virtAddr,size);
  return rs;
}

/*
Input: user space address
       filetype (0-standard, 1- read only, 2- encrypt)
Output:OpenFileID - success, -1 - fail
       
Purpose:open a file
*/
int   FDTable::fdOpen(int virtAddr,int t,int i,OpenFile *of)
{
  int vA = virtAddr;
  int type = t;
  int id = i;

  FDRw  *rw;
  FDRo  *ro;
  FDEnc *enc;
  switch(type)
    {
    case WRFILE:
      rw = new FDRw(of);
      fTable[id] = (FDBase*) rw; 
      break;
    case ROFILE:
      ro = new FDRo(of);
      fTable[id] = (FDBase*) ro;
      break;
    case ENCRYPTFILE:
      enc = new FDEnc(of);
      fTable[id] = (FDBase*) enc;
      break;
    default:
      printf("\n FDTable:OpenFileError - unknow file type %d",type);
      break;
    }

  bm->Mark(id);

  return id;
}

/*
Input: OpenFileID = reg4
Output:0 - success, -1 - fail
Purpose: close a file
*/
int   FDTable::fdClose(int reg4)
{
  int id = reg4;
  int rs = fTable[id]->fClose();
  if (id >= 2 && id < tsize)
    bm->Clear(id);
  return rs;
}

/*
Input: Offset = reg4, OpenFileID = reg5
Output: currentOffset
Purpose: seek to the input Offset
*/
int   FDTable::fdSeek(int reg4,int reg5)
{
  int id = reg5;
  int offset = reg4;
  int pos = fTable[id]->fSeek(offset);

  machine->WriteRegister(2,pos);

  return pos;
}


/*
Input:
Output: size of FDTable = maximum number of files nachos can handle at the same time
Purpose: get maximum  of FDTable's size
*/
int   FDTable::GetMax()
{
  return tsize;
}

/*
Input:
Output:OpenfileID
Purpose: find a free slot in FDTable
*/
int FDTable::FindFreeSlot()
{
  return (bm->Find());
}

/*
Input:
Output: true - exist, otherwise - fail
Purpose: check OpenFileID is opened or not
*/
bool   FDTable::IsExist(int id)
{
  return bm->Test(id);
}

//End DU~NG TRUNG TRAN
