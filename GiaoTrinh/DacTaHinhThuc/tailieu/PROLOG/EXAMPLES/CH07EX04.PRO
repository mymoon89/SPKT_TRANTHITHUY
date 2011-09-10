/*
   Turbo Prolog 2.0 Chapter 7, Example Program 4
   
   Copyright (c) 1986, 88 by Borland International, Inc
   
*/
   
/* Tail recursive program that never runs out of memory */

predicates
   count(real)

   /* Reals can be much bigger than integers. */

clauses
   count(N) :- 
      write(N), nl,
      NewN = N+1,
      count(NewN).

goal
   count(1).
