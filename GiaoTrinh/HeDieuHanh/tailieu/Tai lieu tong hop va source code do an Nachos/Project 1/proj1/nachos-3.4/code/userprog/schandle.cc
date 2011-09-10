// Syscall handle file: process all syscall exception except SC_Halt
// Begin DU~NG TRUNG TRAN

#include "schandle.h"
#include "fdtable.h"

//FDTable *fTab = new FDTable(MAX);

/*
Input: - User space address (int)
       - Limit of buffer (int)
Output:- Buffer (char*)
Purpose: Copy buffer from User memory space to System memory space
*/

char* User2System(int virtAddr,int limit)
{
  int i;// index
  int oneChar;
  char* kernelBuf = NULL;
  
  kernelBuf = new char[limit +1];//need for terminal string
  if (kernelBuf == NULL)
    return kernelBuf;

  memset(kernelBuf,0,limit+1);
  
  //printf("\n Filename u2s:");
  for (i = 0 ; i < limit ;i++)
    {
      machine->ReadMem(virtAddr+i,1,&oneChar);
      kernelBuf[i] = (char)oneChar;
      //printf("%c",kernelBuf[i]);
      if (oneChar == 0)
	break;
    }

    return kernelBuf;
}


/*
Input: - User space address (int)
       - Limit of buffer (int)
       - Buffer (char[])
Output:- Number of bytes copied (int)
Purpose: Copy buffer from System memory space to User  memory space
*/
int   System2User(int virtAddr,int len,char* buffer)
{
  if (len < 0) return -1;
  if (len == 0)return len;
  int i = 0;
  int oneChar = 0 ;
  do{
    oneChar= (int) buffer[i];
    machine->WriteMem(virtAddr+i,1,oneChar);
    i ++;
  }while(i < len && oneChar != 0);

  return i;
}

/*
Input: reg4 -filename (string)
Output:
Purpose: process the event SC_Create of System call    
*/

int doSC_Create()
{
  int virtAddr;
  char* filename;

    //  printf("\n SC_Create call...");
  //printf("\n Reading virtual address of file name.");
  DEBUG(dbgFile,"\n SC_Create call ...");
  DEBUG(dbgFile,"\n Reading virtual address of filename");
  
  // check for exception
  virtAddr = machine->ReadRegister(4);
  DEBUG (dbgFile,"\n Reading filename.");
  filename = User2System(virtAddr,MaxFileLength+1);
  if (filename == NULL)
    {
      printf("\n Not enough memory in system");
      DEBUG(dbgFile,"\n Not enough memory in system");
      machine->WriteRegister(2,-1);
      delete filename;
      return -1;
    }
  
  if (strlen(filename) == 0 || (strlen(filename) >= MaxFileLength+1))
    {
      printf("\n Too many characters in filename: %s",filename);
      DEBUG(dbgFile,"\n Too many characters in filename");
      machine->WriteRegister(2,-1);
      delete filename;
      return -1;
    }

  //printf("\n Finish reading filename.");
  //printf("\n File name: '%s'",filename);
  DEBUG(dbgFile,"\n Finish reading filename.");
  //DEBUG(dbgFile,"\n File name : '"<<filename<<"'");

  // Create file with size = 0
  if (!fileSystem->Create(filename,0))
    {
      printf("\n Error create file '%s'",filename);
      delete filename;
      machine->WriteRegister(2,-1);
      delete filename;
      return -1;
    }
  //printf("\n Create file '%s' success",filename);

  machine->WriteRegister(2,0);

  delete filename;
  return 0;
}

/*
Input: 
Output:
Purpose: End thread , because exit() was called
*/
int doSC_Exit()
{
  printf("\n\n Calling SC_Exit.");
  DEBUG(dbgFile, "\n\n Calling SC_Exit.");

  // avoid harry
  IntStatus oldLevel = interrupt->SetLevel(IntOff);

  int exitStatus;
  //ProcessHashData *processData;

  exitStatus = machine->ReadRegister(4);

  // if process exited with error, print error
  if (exitStatus != 0)
    printf("\nProcess %s exited with error level %d",currentThread->getName(),exitStatus);

  //  currentThread->Finish();
  (void) interrupt->SetLevel(oldLevel);
  interrupt->Halt();
  return 0;
}

 
/*
Input: OpenfileID = reg4
Output: 0- success , -1 - fail
Purpose: do close file 
*/
int doSC_Close()
{
  int id = machine->ReadRegister(4);
  if (id < 0 || id >= currentThread->fTab->GetMax())
    {
      printf("\n CloseError: Unexpected file id: %d",id);
      return -1;
    }
  if (!currentThread->fTab->IsExist(id)){
    printf("\n CloseError: closing file id %d is not opened",id);
    return -1;
  }

  //currentThread->
  currentThread->fTab->fdClose(id);
  return 0;
}

/*
Input: offset = reg4, OpenFileID = reg5
Output: currentOffset, or -1 - fail
Purpose: do seek the pointer of a file. If seek to offset -1 mean SEEK_END 
*/
int doSC_Seek()
{
  int id = machine->ReadRegister(5);
  if (id < 0 || id >= currentThread->fTab->GetMax())
    {
      printf("\n SC_SeekError: Unexpected file id: %d",id);
      return -1;
    }
  if (!currentThread->fTab->IsExist(id)){
    printf("\n SC_SeekError: seeking file id %d is not opened",id);
    return -1;
  }

  int offset = machine->ReadRegister(4);
  currentThread->fTab->fdSeek(offset,id);

  return 0;
}

/*
Input: User space address = reg4, buffer size = reg5, OpenfileID = reg6
Output: -1: error
        numbytes were read
Purpose: do read from file or console
*/
int doSC_Read()
{
  //  printf("\n Calling SC_Read.");
  int virtAddr = machine->ReadRegister(4);
  int size = machine->ReadRegister(5);
  int id = machine->ReadRegister(6);
  
  if (size <= 0)
    {
      printf("\nSC_ReadError: unexpected buffer size: %d",size);
      return -1;
    }

  if (id < 0 || id >= currentThread->fTab->GetMax())
    {
      printf("\n ReadError: Unexpected file id: %d",id);
      return -1;
    }
  if (!currentThread->fTab->IsExist(id)){
    printf("\n ReadError: reading file id %d is not opened",id);
    return -1;
  }

  int rs = currentThread->fTab->fdRead(virtAddr,size,id);
  
  machine->WriteRegister(2,rs);

  return rs;
}

/*
Input: User space address = reg4, buffer size= reg5, OpenFileID = reg6
Output: = -1 - error
        or = numbytes were writen
Purpose: do write to file or console
*/
int doSC_Write()
{
  //  printf("\n Calling SC_Write.");
  int virtAddr = machine->ReadRegister(4);
  int size = machine->ReadRegister(5);
  int id = machine->ReadRegister(6);

  if (size < 0)
    {
      printf("\nSC_WriteError: unexpected buffer size: %d",size);
      return -1;
    }
  else if (size == 0)
    return 0;

  if (id < 0 || id >= currentThread->fTab->GetMax())
    {
      printf("\n WriteError: Unexpected file id: %d",id);
      return -1;
    }
  if (!currentThread->fTab->IsExist(id)){
    printf("\n WriteError: writing file id %d is not opened",id);
    return -1;
  }

  int rs = currentThread->fTab->fdWrite(virtAddr,size,id);
  
  machine->WriteRegister(2,rs);

  return rs;
}

/*
Input: file type (reg5)
       0 - standard file
       1 - read only
       2 - encrypted

Output:  -1 - error
         OpenFileID -success
 
Purpose: do Open a file
*/
int doSC_Open()
{
  //  printf("\n Calling SC_Open.");
  int virtAddr = machine->ReadRegister(4);
  int type = machine->ReadRegister(5);

  if (type < 0 || type > 2)
    {
      printf("\n SC_OpenError: unexpected file type: %d",type);
      return -1;
    }
  
  int id = currentThread->fTab->FindFreeSlot();
  if (id < 0)
    {
      printf("\n SC_OpenError: No free slot.");
      return -1;
    }

  char *filename = User2System(virtAddr,MaxFileLength+1);

  if (filename == NULL)
    {
      printf("\n Not enough memory in system");
      DEBUG(dbgFile,"\n Not enough memory in system");
      machine->WriteRegister(2,-1);
      delete filename;
      return -1;
    }

  if (strlen(filename) == 0 || (strlen(filename) >= MaxFileLength+1))
    {
      printf("\n Too many characters in filename: %s",filename);
      DEBUG(dbgFile,"\n Too many characters in filename");
      machine->WriteRegister(2,-1);
      delete filename;
      return -1;
    }

  OpenFile* of = fileSystem->Open(filename);

  if (of == NULL){
    printf("\n Error opening file:  %s",filename);
    DEBUG(dbgFile,"\n Error opening file.");
    machine->WriteRegister(2,-1);
    delete filename;
    return -1;
  }

  int rs = currentThread->fTab->fdOpen(virtAddr,type,id,of);
  
  machine->WriteRegister(2,rs);

  return rs;
}
//End DU~NG TRUNG TRAN
