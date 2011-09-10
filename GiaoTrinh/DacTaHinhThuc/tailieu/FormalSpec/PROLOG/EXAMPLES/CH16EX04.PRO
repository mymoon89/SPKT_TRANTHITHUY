/*
   Turbo Prolog 2.0 Chapter 16, Example Program 4
   
   Copyright (c) 1986, 88 by Borland International, Inc
   
*/
   
predicates
   dosver(real)
   diskspace(real, real, real)
   makedir(string)
   removedir(string)

clauses
   dosver(Version) :- AX=48*256,
   bios(33, reg(AX, 0, 0, 0, 0, 0, 0, 0), reg(VV,_,_,_,_,_,_,_)),

   /* You could use hex notation, bios($21...) instead of bios(33...) */
   L=VV div 6, H=VV-256*L, Version=H+L/100.

   diskspace(Disk, TotalSpace, FreeSpace) :-
      AAX = 54*256,
      bios(33, reg(AAX, 0, 0, DISK, 0, 0, 0, 0), reg(AX, BX, CX, DX,_,_,_,_)),
      FreeSpace = 1.0*BX*CX*AX, TotalSpace = 1.0*DX*CX*AX.

   makedir(Name) :-
      ptr_dword(Name, DS, DX),
      AX = 256*57,
      bios(33, reg(AX, 0, 0, DX, 0, 0, DS, 0), _).

   removedir(Name) :-
      ptr_dword(Name, DS, DX), AX=256*58,
      bios(33, reg(AX, 0, 0, DX, 0, 0, DS, 0), _).
