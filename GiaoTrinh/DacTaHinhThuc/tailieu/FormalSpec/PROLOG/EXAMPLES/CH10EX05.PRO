/*
   Turbo Prolog 2.0 Chapter 10, Example Program 5
   
   Copyright (c) 1986, 88 by Borland International, Inc
   
*/
   
diagnostics
check_determ
database
   counter( integer )

predicates
   nondeterm repeat
   my_retract(dbasedom)
   count

goal
   count.

clauses
   repeat.  repeat :-  repeat.

   my_retract(X) :-  retract(X). % needs to be deterministic

   count :- assert( counter(0) ) , fail.
   count :- repeat ,
            counter(X),
            Y = X + 1 ,
            my_retract( counter(X) ) ,
            asserta( counter(Y) ) ,
            write(Y,"\n") ,
            Y = 100.
            
