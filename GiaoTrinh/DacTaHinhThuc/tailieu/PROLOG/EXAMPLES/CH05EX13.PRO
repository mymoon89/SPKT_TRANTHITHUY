/*
   Turbo Prolog 2.0 Chapter 5, Example Program 15
   
   Copyright (c) 1986, 88 by Borland International, Inc
   
*/

predicates
   classify(integer, symbol)

clauses
   classify(0, zero).
   classify(X, negative) :- X < 0.
   classify(X, positive) :- X > 0.