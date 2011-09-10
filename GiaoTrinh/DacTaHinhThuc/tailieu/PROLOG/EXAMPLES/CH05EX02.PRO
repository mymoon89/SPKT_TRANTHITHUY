/*
   Turbo Prolog 2.0 Chapter 5, Example Program 02
   
   Copyright (c) 1986, 88 by Borland International, Inc
   
*/
   
predicates
   likes(symbol,symbol)
   tastes(symbol,symbol)
   food(symbol)
   
clauses
   likes(bill, X) :-
      food(X), tastes(X, good).

   tastes(pizza, good).
   tastes(brussels_sprouts, bad).

   food(brussels_sprouts).
   food(pizza).