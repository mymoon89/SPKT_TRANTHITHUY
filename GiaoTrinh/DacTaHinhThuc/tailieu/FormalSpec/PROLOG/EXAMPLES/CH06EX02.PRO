/*
   Turbo Prolog 2.0 Chapter 6, Example Program 2
   
   Copyright (c) 1986, 88 by Borland International, Inc
   
*/
    
domains
   row, column, step = integer
   movement = up(step); down(step); 
   	      left(step); right(step)

predicates
   move_cursor(row, column, movement)

clauses
   move_cursor(R, C, up(Step)) :-
       cursor(R, C), R1=R-Step, cursor(R1, C).

   move_cursor(R, C, down(Step)) :-
       cursor(R, C), R1=R+Step, cursor(R1, C).

   move_cursor(R, C, left(Step)) :-
       cursor(R, C), C1=C-Step, cursor(R, C1).

   move_cursor(R, C, right(Step)) :-
       cursor(R, C), C1=C+Step, cursor(R, C1).
