/*
   Turbo Prolog 2.0 Chapter 3, Example Program 4
      
   Copyright (c) 1986, 88 by Borland International, Inc
   
*/
   
predicates
   male(symbol)
   female(symbol)
   parent(symbol, symbol)

clauses
   male(bill).
   male(joe).

   female(sue).
   female(tammy).

   parent(bill, joe).
   parent(sue, joe).
   parent(joe, tammy).
