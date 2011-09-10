/*
   Turbo Prolog 2.0 Chapter 10, Example Program 2
   
   Copyright (c) 1986, 88 by Borland International, Inc
   
*/
    
trace
domains
   list = element*
   element = symbol

predicates
   member(element, list)
   go(list)

clauses
   member(X, [X|_]).
   member(X, [_|T]) :- member(X,T).

   go(X) :- member(Y, X) ,
            write(Y,"\n") ,
            fail.
   go(X) :- member(l, X), write("True\n"), ! ;
            write("False\n").

goal
   go( [p,r,o,l,o,g] ).
