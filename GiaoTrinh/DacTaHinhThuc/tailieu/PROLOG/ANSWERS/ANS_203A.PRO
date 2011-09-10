/*
   Turbo Prolog 2.0, Answer to first Exercise on page 203.
   
   Copyright (c) 1986, 88 by Borland International, Inc
*/

Domains
  integerlist = integer*

Predicates
  get_integer_list ( integerlist )
  odd_list ( integerlist, integerlist )  

Clauses

  odd_list([], []) :- !.      % If the input list is empty, 
                              % the output must be empty.

  odd_list([H|T1], [H|T2]) :-
  	1 = H mod 2, ! ,      % Is the head odd? 
  	odd_list(T1, T2).     % If so, add it to the head 
  	                      % of the output list.

  odd_list([_|T1], T2) :-     % If the head is not odd,
  	odd_list(T1, T2).     % try the rest of the list!
  	
  get_integer_list([Int|T]) :-
  	write("Enter an integer: ") ,
  	readint(Int), ! ,
  	get_integer_list(T).
  get_integer_list([]).
  
Goal
  makewindow(1,2,3," Odd List ",0,0,25,80) ,
  write("Enter the integers to make a list.\n",
        " (Enter a non-integer to end list.)\n\n") ,
  get_integer_list(List),
  odd_list(List, Odds) ,
  write("\nThe whole list is: ",List,"\nThe odd list is  : ",Odds) ,
  write("\n\nPress any key...") ,
  readchar(_).