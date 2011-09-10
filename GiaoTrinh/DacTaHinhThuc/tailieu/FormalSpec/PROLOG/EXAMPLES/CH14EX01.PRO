/*
   Turbo Prolog 2.0 Chapter 14, Example Program 1
   
   Copyright (c) 1986, 88 by Borland International, Inc
   
*/
   
predicates
   run

clauses
   run :-
      makewindow(1, 20, 7, "A blue window", 2, 5, 10, 50),
      write("The characters are red"), nl,
      makewindow(2, 176, 7, "A light cyan window", 14, 25, 10, 40),
      write("This window is light cyan and the "),
      write("letters are black and blink."), nl,
      write("Please type an integer to exit."), nl,
      readint(_),
      removewindow,
      write("Please type an integer to exit."), nl,
      readint(_),
      removewindow.
