/*
   Turbo Prolog 2.0, Answer to third Exercise on page 193.
   
   Copyright (c) 1986, 88 by Borland International, Inc
*/

Domains
  integerlist = integer*

Predicates
  get_integer_list ( integerlist )
  get_list_sum ( integerlist, integer, integer )
  sum_list ( integerlist, integer )  

Clauses
  sum_list(List, Sum) :-
  	get_list_sum(List, 0, Sum).

  get_list_sum([], X, X) :- !.
  get_list_sum([Num|T], Temp, Sum) :-
	Temp_sum = Temp + Num ,
  	get_list_sum(T, Temp_sum, Sum).
  	
  get_integer_list([H|T]) :-
  	write("Enter an integer: ") ,
  	readint(H), ! ,
  	get_integer_list(T).
  get_integer_list([]).

Goal
  makewindow(1,2,3," Sum of an Integerlist ",0,0,25,80) ,
  write("Please enter the integers which you wish to sum.\n" ,
        "  (Enter a non-integer to stop.)\n\n") ,
  get_integer_list(List) ,
  sum_list(List, Sum) ,
  clearwindow ,
  write("The sum of the list is: ",Sum,"\n").    	