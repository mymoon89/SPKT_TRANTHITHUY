/*
   Turbo Prolog 2.0 Reference Guide Chapter 2,  Example Program 2
   
   Copyright (c) 1986, 88 by Borland International, Inc
   
*/
trace

domains
   list=integer*

predicates
   eq(integer, integer)
   member(integer, list)

clauses
   member(X, [X|_]).
   member(X,[_|L]) :- member(X,L).
   eq(X,X).

goal
   member(X,[1,2]), eq(X,2).