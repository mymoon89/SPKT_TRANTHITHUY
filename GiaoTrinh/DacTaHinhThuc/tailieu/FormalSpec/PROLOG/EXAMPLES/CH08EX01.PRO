/*
   Turbo Prolog 2.0 Chapter 8, Example Program 1
   
   Copyright (c) 1986, 88 by Borland International, Inc
   
*/
   
domains
   list = integer* /* or whatever type you wish to use */

predicates
   write_a_list(list)

clauses
   write_a_list([]). /* If the list is empty, do nothing more. */

   write_a_list([H|T]) :- /* Match the head to H and the tail to
T, then... */
      write(H), nl,
      write_a_list(T).

goal
   write_a_list([1, 2, 3]).
