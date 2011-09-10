/*
   Turbo Prolog 2.0, Answer to second Exercise on page 203.
   
   Copyright (c) 1986, 88 by Borland International, Inc
*/

Domains
  reallist = real*
  
Predicates
  real_average ( reallist, real )
  list_length ( reallist, real, real )
  list_sum (reallist, real, real )
  get_list ( reallist ) 
  
Clauses
  real_average(List, Average) :-
  	list_length(List, 0, Length) ,
  	list_sum(List, 0, Sum) ,
  	Average = Sum / Length.
  	
  list_length([], L, L) :- !.
  list_length([_|T], Temp_length, Length) :-
  	New_temp = Temp_length + 1 ,
  	list_length(T, New_temp, Length).
  	
  list_sum([], S, S) :- !.
  list_sum([Num|T], Temp_sum, Sum) :-
    	New_temp = Num + Temp_sum ,
    	list_sum(T, New_temp, Sum).
    	
  get_list([H|T]) :-
    	write("Enter a real number: ") ,
    	readreal(H) ,
    	!, get_list(T).
  get_list([]).    	
  
Goal
  makewindow(1,2,3," Real List Sum ",0,0,25,80) ,
  write("Please enter a list of real numbers" ,
        " (enter a non-integer to stop):\n\n") ,
  get_list(List), nl, nl ,  
  real_average(List, Average) ,
  write("The list is:\n", List) ,
  writef("\n\nThe average is: %.\n", Average).
  
  