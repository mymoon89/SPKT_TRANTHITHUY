/*
   Turbo Prolog 2.0 Chapter 5, Example Program 3
   
   Copyright (c) 1986, 88 by Borland International, Inc
   
*/
   
domains
   child = symbol
   age   = integer

predicates
   player(child, age)

clauses
   player(peter, 9).
   player(paul, 10).
   player(chris, 9).
   player(susan, 9).