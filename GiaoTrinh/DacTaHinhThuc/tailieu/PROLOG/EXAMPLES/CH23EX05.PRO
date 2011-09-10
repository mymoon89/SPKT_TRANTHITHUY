/*
   Turbo Prolog 2.0 Reference Guide Chapter 3, Example Program 5
   
   Copyright (c) 1986, 88 by Borland International, Inc
   
*/
   
project "mypack"

global domains
   mydom = f(integer, char, real, string)

global predicates
   pack(integer, char, real, string, mydom) -(i,i,i,i,o) language c

goal
  pack(1, 'a', 99.9, "HELLO", X),
  write(X), nl.
