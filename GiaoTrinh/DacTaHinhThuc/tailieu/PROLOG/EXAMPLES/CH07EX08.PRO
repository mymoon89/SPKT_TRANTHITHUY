/*
   Turbo Prolog 2.0 Chapter 7, Example Program 8
   
   Copyright (c) 1986, 88 by Borland International, Inc
   
*/

predicates
   factorial(integer,real)
   factorial(integer, real, integer, real)

/* Numbers likely to exceed 32767 are declared as reals. */

clauses
   factorial(N,FactN):-
      factorial(N,FactN,1,1).
      
   factorial(N, FactN, N, FactN):- !.
   factorial(N, FactN, I, P):-
      NewI = I+1,
      NewP = P*NewI,
      factorial(N, FactN, NewI, NewP).