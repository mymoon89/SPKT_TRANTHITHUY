/*
   Turbo Prolog 2.0, Answer to the Exercise on page 199.
   
   Copyright (c) 1986, 88 by Borland International, Inc
*/

Domains
  integerlist = integer*	
  
Predicates
  even_member ( integer, integerlist )
  get_integer_list ( integerlist )
  write_even_members ( integerlist )
  
Clauses
  even_member(Head, [Head|_]) :- 
  	0 = Head mod 2.
  even_member(Element, [_|Tail]) :-
  	even_member(Element, Tail).  
  	
  get_integer_list([H|T]) :-
  	write("Enter an integer: ") ,
  	readint(H), ! ,
  	get_integer_list(T).
  get_integer_list([]).

  write_even_members(L) :- 
  	even_member(E,L) ,
  	write(E,"\n") ,
  	fail.
  write_even_members(_).  	
    	  	
Goal
  makewindow(1,2,3,"",0,0,25,80) ,
  write("Please enter the integers which ",
        "you wish to include in the list.\n",
        "  (Enter a non-integer to end list.)\n\n") ,
  get_integer_list(List) ,
  write("\nHere are the even numbers in the list:\n\n") ,
  write_even_members(List) ,
  write("\nPress any key...") ,
  readchar(_).