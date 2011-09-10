/*
   Turbo Prolog 2.0 Chapter 22, Example Program 9
   
   Copyright (c) 1986, 88 by Borland International, Inc
   
*/
   
project "dateproj"

global predicates
   mydate(integer,integer,integer) - (i,i,i)(o,o,o) language asm

goal
   mydate(Y,M,D),
   write("\nYear=", Y, ", Month=", M, ", Day=", D),
   mydate(1988, 3, 3),
   mydate(Y1, M1, D1),
   write("\nYear=", Y1, ", Month=", M1, ", Day=", D1).
