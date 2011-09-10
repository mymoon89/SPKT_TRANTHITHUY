/*
   Turbo Prolog 2.0 Chapter 12, Example Program 10
   
   Copyright (c) 1986, 88 by Borland International, Inc
   
*/
   
domains
   file = input

predicates
   inspect_positions

goal
   write("Which file do you want to work with ?"),
   readln(FileName),
   openread(input, FileName),
   inspect_positions.

clauses
   inspect_positions :-
      readdevice(keyboard),
      nl, write("Position No? "),
      readreal(X),
      readdevice(input), filepos(input, X, 0),
      readchar(Y), write("Char is: ",Y),
      inspect_positions.
