// exception.cc 
//	Entry point into the Nachos kernel from user programs.
//	There are two kinds of things that can cause control to
//	transfer back to here from user code:
//
//	syscall -- The user code explicitly requests to call a procedure
//	in the Nachos kernel.  Right now, the only function we support is
//	"Halt".
//
//	exceptions -- The user code does something that the CPU can't handle.
//	For instance, accessing memory that doesn't exist, arithmetic errors,
//	etc.  
//
//	Interrupts (which can also cause control to transfer from user
//	code into the Nachos kernel) are handled elsewhere.
//
// For now, this only handles the Halt() system call.
// Everything else core dumps.
//
// Copyright (c) 1992-1993 The Regents of the University of California.
// All rights reserved.  See copyright.h for copyright notice and limitation 
// of liability and disclaimer of warranty provisions.

#include "copyright.h"
#include "system.h"
#include "syscall.h"
#include "schandle.h"

//----------------------------------------------------------------------
// ExceptionHandler
// 	Entry point into the Nachos kernel.  Called when a user program
//	is executing, and either does a syscall, or generates an addressing
//	or arithmetic exception.
//
// 	For system calls, the following is the calling convention:
//
// 	system call code -- r2
//		arg1 -- r4
//		arg2 -- r5
//		arg3 -- r6
//		arg4 -- r7
//
//	The result of the system call, if any, must be put back into r2. 
//
// And don't forget to increment the pc before returning. (Or else you'll
// loop making the same system call forever!
//
//	"which" is the kind of exception.  The list of possible exceptions 
//	are in machine.h.
//----------------------------------------------------------------------
void AdvanceProgramCounter()
{
  int pc;
  pc = machine->ReadRegister(PCReg);
  machine->WriteRegister(PrevPCReg, pc);
  pc = machine->ReadRegister(NextPCReg);
  machine->WriteRegister(PCReg, pc);
  pc+=4;
  machine->WriteRegister(NextPCReg, pc);
}

void
ExceptionHandler(ExceptionType which)
{
    int type = machine->ReadRegister(2);

    // Begin DU~NG TRUNG TRAN
 
    switch (which){

    case NoException:
      return;

    case SyscallException:
      switch (type){

      case SC_Halt:
 	DEBUG(dbgAddr, "\n Shutdown, initiated by user program.");
	printf ("\n\n Shutdown, initiated by user program.MMT");
     	interrupt->Halt();
	break;

      case SC_Open:
	doSC_Open();
	break;

      case SC_Close:
	doSC_Close();
	break;

      case SC_Read:
	doSC_Read();
	break;

      case SC_Write:
	doSC_Write();
	break;

      case SC_Seek:
	doSC_Seek();
	break;

      case SC_CreateFile:
	doSC_Create();
	break;

      case SC_CreateMailBox:
	printf("\n\n SC_CreateMailBox");
     	interrupt->Halt();
	break;

      case SC_Exec:
	printf("\n\n SC_Exec");
     	interrupt->Halt();
	break;

      case SC_Join:
 	//DEBUG('a', "\n SC_Exit, initiated by user program.!");
	printf("\n\n SC_Join");
     	interrupt->Halt();
	break;

      case SC_Exit:
	doSC_Exit();
	break;

      case SC_Fork:
	printf("\n SC_Fork");
     	interrupt->Halt();
	break;
      
     default:
	printf("\n SyscallException:  Unexpected system call %d", type);
	//break;
	interrupt->Halt();
      }
      
      //printf("\n Incrementing PC.");
      DEBUG(dbgAddr, "\n Incrementing PC.");
      AdvanceProgramCounter();
      break;
      
    case PageFaultException:
      printf("\n Page fault exception.");
      interrupt->Halt();
      break;

    case ReadOnlyException:
      printf("\n Read only exception.");
      interrupt->Halt();
      break;

    case BusErrorException:
      printf("\n Bus error exception.");
      interrupt->Halt();
      break;
      
    case AddressErrorException:
      printf("\n Address error exception.");
      interrupt->Halt();
      break;

    case OverflowException:
      printf("\n Over flow exception.");
      interrupt->Halt();
      break;


    case IllegalInstrException:
      printf("\n Illegal instruction exception.!");
      interrupt->Halt();
      break;

    case NumExceptionTypes:
      printf("\n Number exception types.");
      interrupt->Halt();
      break;

    default:
      printf("\n Unexpected user mode exception (%d %d)", which, type);
      interrupt->Halt();
    }    
}


// End DU~NG TRUNG TRAN
