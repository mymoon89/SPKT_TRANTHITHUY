/*
   Turbo Prolog 2.0 Chapter 8, Example Program 3
   
   Copyright (c) 1986, 88 by Borland International, Inc
   
*/
   
domains
   list = integer* /* or whatever type you want to use */

predicates
   length_of(list, integer, integer)

clauses
/* * * * * * * * * * * * * * * * * * * * * * *
 * If the list is empty, bind the second arg *
 *   (the result) to the third (the counter).*
 * * * * * * * * * * * * * * * * * * * * * * */
   length_of([], Result, Result).

/* * * * * * * * * * * * * * * * * * * * * * * * * * *
 * Otherwise, add 1 to counter and recurse, binding  *
 * Result in this invocation to Result in the next.  *
 * * * * * * * * * * * * * * * * * * * * * * * * * * */
   length_of([_|T], Result, Counter) :-
      NewCounter = Counter + 1,
      length_of(T, Result, NewCounter).

goal
   length_of([1, 2, 3], L, 0), /* start with Counter = 0 */
   write(L), nl.
