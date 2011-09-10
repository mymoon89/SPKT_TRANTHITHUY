/*
   Turbo Prolog 2.0 Chapter 7, Example Program 3
   
   Copyright (c) 1986, 88 by Borland International, Inc
   
*/
   
/* Recursive program to compute factorials.
   Ordinary recursion, not tail recursion. */

predicates
   factorial(integer, real)

clauses
   factorial(1, 1) :- !.

   factorial(X, FactX) :-
      Y = X-1,
      factorial(Y, FactY),
      FactX = X*FactY.
