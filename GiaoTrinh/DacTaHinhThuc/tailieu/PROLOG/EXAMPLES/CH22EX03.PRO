/*
   Turbo Prolog 2.0 Chapter 22, Example Program 3
   
   Copyright (c) 1986, 88 by Borland International, Inc
   
*/
   
project "dummy"  /* Use your own project name here */

constants
  % Choose the language calling convention, either C or Pascal
  lang = c

global predicates
  myfail language lang as "fail"
  mymakewindow(integer,integer,integer,string,integer,integer,integer,integer)
     - (i,i,i,i,i,i,i,i) language lang as "makewindow"
  myshiftwindow(integer) - (i) language lang as "shiftwindow"
  myremovewindow language lang as "removewindow"
  write_integer(integer) - (i) language lang as "write_integer"
  write_real(real) - (i) language lang as "write_real"
  write_string(string) - (i) language lang as "write_string"
  myreadchar(char) - (o) language lang as "readchar"
  myreadline(string) - (o) language lang as "readline"

  extprog language lang as "extprog"

clauses
   myfail :- fail.

   mymakewindow(Wno, Wattr, Fattr, Text, Srow, Scol, Rows, Cols):-
      makewindow(Wno, Wattr, Fattr, Text, Srow, Scol, Rows, Cols).

  myshiftwindow(WNO) :- shiftwindow(WNO).

  myremovewindow :- removewindow.

  write_integer(I) :- write(I).

  write_real(R) :- write(R).

  write_string(S) :- write(S).

  myreadchar(CH) :- readchar(CH).

  myreadline(S) :- readln(S).
