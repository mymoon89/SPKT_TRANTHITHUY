/*
   Turbo Prolog 2.0 Chapter 4, Example Program 3
   
   Copyright (c) 1986, 88 by Borland International, Inc
   
*/
   
predicates
   run(char)

goal
   run(X).                                      /* This is a internal goal. */

clauses
   run(X) :-
      makewindow(1, 7, 7, " Hello World Program ", 0, 0, 25, 80),
      write("Hello World (first)"),
      readchar(X),
      removewindow.

   run(X) :-
      write("hello World (second)"),
      readchar(X).
