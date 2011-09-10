/*
   Turbo Prolog 2.0, Answer to second Exercise on page 170.
   
   Copyright (c) 1986, 88 by Borland International, Inc
*/

Predicates
   typewriter ( char )

Clauses

  typewriter('\13') :- !.
  typewriter(Char) :-
  	write(Char) ,
  	readchar(C) ,      
  	typewriter(C).
Goal
   makewindow(1,2,3," Typewriter ",0,0,25,80) ,
   readchar(Char) ,
   typewriter(Char).
   