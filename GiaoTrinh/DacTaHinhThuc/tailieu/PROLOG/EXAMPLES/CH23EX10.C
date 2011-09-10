/*
   Turbo Prolog 2.0 Reference Guide Chapter 3, Example Program 10
   
   Copyright (c) 1986, 88 by Borland International, Inc
   
*/
   
pascal mydate_0(int Year, int Month, int Day)
{
   asm	mov      cx,Year
   asm	mov      dh,Month
   asm	mov      dl,Day
   asm	mov      ah,02BH
   asm	int      21H /* Set the new date */
}

pascal mydate_1(int *Year, int *Month, int *Day)
{
   asm	mov      ah,2AH
   asm	int      21H

/* Now the date is placed in the registers: CX=Year, DH=Month,
DL=Day */
   asm	les      di,Year
   asm	mov      es:[di],cx
   asm	les      di,Month
   asm	mov      es:[di],dh
   asm	mov      es:1[di],byte ptr 0
   asm	les      di,Day
   asm	mov      es:[di],dl
   asm	mov      es:1[di],byte ptr 0
}
