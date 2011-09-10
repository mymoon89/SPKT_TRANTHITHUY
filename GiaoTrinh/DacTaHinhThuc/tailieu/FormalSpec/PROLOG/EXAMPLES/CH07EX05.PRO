/*
   Turbo Prolog 2.0 Chapter 7, Example Program 5
   
   Copyright (c) 1986, 88 by Borland International, Inc
   
*/
   
/* Three procedures that are like CH07EX04.PRO but not tail recursive; 
   they run out of memory after a few hundred iterations. */

predicates
   badcount1(real)
   badcount2(real)
   badcount3(real)
   check(real)

clauses
/* badcount1:
   The recursive call is not the last step. */

   badcount1(X) :- 
      write(X), nl,
      NewX = X+1,
      badcount1(NewX),
      nl.

/* badcount2:
   There is a clause that has not been tried
   at the time the recursive call is made. */

   badcount2(X) :- 
      write(X), nl,
      NewX = X+1,
      badcount2(NewX).

   badcount2(X) :- 
      X < 0,
      write("X is negative.").

/* badcount3:
   There is an untried alternative in a
   procedure called before the recursive call. */

   badcount3(X) :- 
      write(X), nl,
      NewX = X+1,
      check(NewX),
      badcount3(NewX).

   check(Z) :- Z >= 0.
   check(Z) :- Z < 0.
