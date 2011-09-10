#ifndef SCHANDLE_H
#define SCHANDLE_H

#include "../userprog/syscall.h"
#include "system.h"
#define MaxFileLength 32

char* User2System(int virtAddr,int maxfilelen);
int   System2User(int virtAddr,int len,char* buffer);
int doSC_Create();
int doSC_Exit();
int doSC_Open();
int doSC_Close();
int doSC_Read();
int doSC_Write();
int doSC_Seek();
int doSC_CreateFile();
int doSC_CreateMailBox();
int doSC_Exec();
int doSC_Join();
int doSC_Fork();

#endif
