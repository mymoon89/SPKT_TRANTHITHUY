/*
   Turbo Prolog 2.0 Chapter 22, Example Program 7
   
   Copyright (c) 1986, 88 by Borland International, Inc
   
*/
   
project "mycnvrt"

global domains
   list = integer*

global predicates
  inclist(list, list) - (i,o) language c

goal
  inclist([1, 2, 3, 4, 5, 6, 7], L), write(L).
