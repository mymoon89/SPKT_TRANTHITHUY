/*
   Turbo Prolog 2.0, Answer to fourth Exercise on page 170.
   
   Copyright (c) 1986, 88 by Borland International, Inc
*/

Predicates
  mult_x_itself ( real )

Clauses

  mult_x_itself(X) :-
  	X <= 1 ,
  	!, write("no\n").

  mult_x_itself(81) :- 
  	write("yes\n"), !.

  mult_x_itself(Num) :-
  	Num > 81 ,
  	!, write("no\n").

  mult_x_itself(Num) :-
  	Num1 = Num * Num ,
  	mult_x_itself(Num1).
Goal
  makewindow(1,2,3,"",0,0,25,80) ,
  write("\nEnter a number: ") ,
  readreal(Number) ,
  nl,
  mult_x_itself(Number), nl.  	  