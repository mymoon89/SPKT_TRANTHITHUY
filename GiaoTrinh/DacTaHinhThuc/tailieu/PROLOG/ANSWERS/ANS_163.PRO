/*
   Turbo Prolog 2.0, Answer to Exercise on page 163.
   
   Copyright (c) 1986, 88 by Borland International, Inc
*/

Predicates
  count ( real )  	% reals can be larger than integers
Clauses
  count(Number) :-
  	write(Number), nl ,
  	New_number = Number + 1 ,
  	count(New_number) ,
  	write("This added call makes this clause non-tail recursive!").
Goal
  count(1).  	