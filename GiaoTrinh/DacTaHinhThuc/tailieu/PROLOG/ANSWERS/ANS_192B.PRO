/*
   Turbo Prolog 2.0, Answer to second Exercise on page 192.
   
   Copyright (c) 1986, 88 by Borland International, Inc
*/

Domains
  integerlist = integer*

Predicates
  sum_of ( integerlist, integer )  
  get_integer_list ( integerlist )

Clauses
  sum_of([], 0) :- !.
  sum_of([Num|T], Sum) :-
  	sum_of(T, Sum_of_tail) ,
  	Sum = Num + Sum_of_tail.
  	
  get_integer_list([H|T]) :-
  	write("Enter an integer: ") ,
  	readint(H), ! ,
  	get_integer_list(T).
  get_integer_list([]).

Goal
  makewindow(1,2,3," Sum of an Integerlist ",0,0,25,80) ,
  write("Please enter the integers which you wish to sum.\n" ,
        "  (Enter a non-integer to stop.)\n") ,
  get_integer_list(List) ,
  sum_of(List, Sum) ,
  clearwindow ,
  write("The sum of the list is: ",Sum,"\n").    	