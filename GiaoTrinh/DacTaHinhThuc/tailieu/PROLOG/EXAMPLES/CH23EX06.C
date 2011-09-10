/*
   Turbo Prolog 2.0 Reference Guide Chapter 3, Example Program 6
   
   Copyright (c) 1986, 88 by Borland International, Inc
   
*/
   
void *alloc_gstack(unsigned);

typedef struct {
   char functor;  /* Type of functor */
   int ival;  /* Value of the functor */
   char cval;
   double rval;
} mydom;

pack_0(int P1, char P2, double P3, mydom **P4 )
{
   mydom *p=*P4=alloc_gstack(sizeof(mydom));
   p->functor=1;
   p->ival=P1;
   p->cval=P2;
   p->rval=P3;
}
