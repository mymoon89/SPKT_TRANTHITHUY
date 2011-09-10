/*
   Turbo Prolog 2.0 Chapter 4, Example Program 4
   
   Copyright (c) 1986, 88 by Borland International, Inc
   
*/
   
domains
   person = symbol

predicates
   father(person)                                 /* This person is a father */
   father(person, person)    /* One person is the father of the other person */

clauses
   father(Man) :- 
      father(Man,_).
   father(adam, seth).
   father(abraham, isaac).
