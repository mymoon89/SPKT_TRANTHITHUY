/*
   Turbo Prolog 2.0 Chapter 8, Example Program 2
   
   Copyright (c) 1986, 88 by Borland International, Inc
   
*/
   
domains
   list = integer* /* or whatever type you want to use */

predicates
   length_of(list, integer)

clauses
   length_of([], 0).
   length_of([_|T], L) :- length_of(T, TailLength),
                         L = TailLength + 1.

