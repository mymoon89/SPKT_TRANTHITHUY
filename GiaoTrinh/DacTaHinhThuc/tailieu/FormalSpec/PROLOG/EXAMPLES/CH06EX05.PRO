/*
   Turbo Prolog 2.0 Chapter 6, Example Program 5
   
   Copyright (c) 1986, 88 by Borland International, Inc
   
*/
   
domains
   d = pair(integer, integer) ; single(integer) ; none

predicates
   are_equal(d, d)

clauses
   are_equal(X, X).
