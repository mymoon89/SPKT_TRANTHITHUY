/*
   Turbo Prolog 2.0 Chapter 7, Example Program 7
   
   Copyright (c) 1986, 88 by Borland International, Inc
   
*/
   
predicates
   factorial(integer, real)
   factorial_aux(integer, real, integer, real)

/* Numbers likely to exceed 32767 are declared as reals. */

clauses
   factorial(N, FactN) :-
      factorial_aux(N, FactN, 1, 1).

   factorial_aux(N, FactN, I, P) :-
      I <= N, !,
      NewP = P * I,
      NewI = I + 1,
      factorial_aux(N, FactN, NewI, NewP).

   factorial_aux(N, FactN, I, FactN) :-
      I > N.
