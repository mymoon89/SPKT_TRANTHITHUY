/*
   Turbo Prolog 2.0 Chapter 11, Example Program 2
   
   Copyright (c) 1986, 88 by Borland International, Inc
   
*/
   
predicates
   person(integer, symbol)
   rand_int_1_5(integer)
   rand_person(integer)

goal
   rand_person(3).

clauses
   person(1, fred).
   person(2, tom).
   person(3, mary).
   person(4, dick).
   person(5, george).

   rand_int_1_5(X) :- random(Y), X=Y*4+1.

   rand_person(0) :- !.

   rand_person(Count) :-
      rand_int_1_5(N), person(N, Name), write(Name), nl,
      NewCount = Count-1, rand_person(NewCount).
