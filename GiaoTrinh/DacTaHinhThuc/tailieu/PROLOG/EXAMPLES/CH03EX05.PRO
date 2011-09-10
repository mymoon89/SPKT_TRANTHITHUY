/*
   Turbo Prolog 2.0 Chapter 3, Example Program 5
   
   Copyright (c) 1986, 88 by Borland International, Inc
   
*/

predicates
   car(symbol,real,integer,symbol,integer)
   truck(symbol,real,integer,symbol,integer)

clauses
   car(chrysler, 130000, 3, red, 12000).
   car(ford, 90000, 4, gray, 25000).
   car(datsun, 8000, 1, red, 30000).
   truck(ford, 80000, 6, blue, 8000).
   truck(datsun, 50000, 5, orange, 20000).
   truck(toyota, 25000, 2, black, 25000).