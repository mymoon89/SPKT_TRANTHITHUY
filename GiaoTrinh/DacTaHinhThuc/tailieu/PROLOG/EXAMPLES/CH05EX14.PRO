/*
   Turbo Prolog 2.0 Chapter 5, Example Program 14
   
   Copyright (c) 1986, 88 by Borland International, Inc
   
*/

predicates
   action(integer)

clauses
   action(1) :- !,
      write("You typed 1.").

   action(2) :- !,
      write("You typed two.").

   action(3) :- !,
      write("Three was what you typed.").

   action(_) :- !,
      write("I don't know that number!").

goal
   write("Type a number from 1 to 3: "),
   readreal(Choice), 
   action(Choice).   
   