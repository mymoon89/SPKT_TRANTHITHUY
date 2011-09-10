/*
   Turbo Prolog 2.0 Chapter 8, Example Program 7
   
   Copyright (c) 1986, 88 by Borland International, Inc
   
*/
   
domains
   integerlist = integer*

predicates
   append(integerlist, integerlist, integerlist)

clauses
   append([], List, List).
   append([X|L1], List2, [X|L3]) :-
          append(L1, List2, L3).
