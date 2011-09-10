/*
   Turbo Prolog 2.0 Chapter 8, Example Program 5
   
   Copyright (c) 1986, 88 by Borland International, Inc
   
*/
   
domains
   list = integer*

predicates
   discard_negatives(list, list)

clauses
   discard_negatives([], []).

   discard_negatives([H|T], ProcessedTail) :- /* If H is
negative, just skip it */
      H < 0,
      !,
      discard_negatives(T, ProcessedTail).

   discard_negatives([H|T], [H|ProcessedTail]) :-
      discard_negatives(T, ProcessedTail).
