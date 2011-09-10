/*
   Turbo Prolog 2.0 Chapter 12, Example Program 1
   
   Copyright (c) 1986, 88 by Borland International, Inc
   
*/
   
domains
   integerlist = integer*
   namelist    = symbol*

predicates
   writelist(integerlist)
   writelist(namelist).

clauses
   writelist([]).
   writelist([H|T]) :- write(H, " "), writelist(T).
