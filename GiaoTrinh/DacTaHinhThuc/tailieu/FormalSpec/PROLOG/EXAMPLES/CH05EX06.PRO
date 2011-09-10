/*
   Turbo Prolog 2.0 Chapter 5, Example Program 6
   
   Copyright (c) 1986, 88 by Borland International, Inc
   
*/
   
domains
   name = symbol

predicates
   father(name, name)
   everybody

clauses
   father(leonard, katherine).
   father(carl, jason).
   father(carl, marilyn).
   everybody :- 
      father(X, Y),
      write(X, " is ", Y, "'s father\n"),
      fail.
