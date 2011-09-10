/*
   Turbo Prolog 2.0 Reference Guide Chapter 3, Example Program 1
   
   Copyright (c) 1986, 88 by Borland International, Inc
   
*/
   
global predicates
   message(string) - (i) language c
   hello_c - language c

clauses
   message(S) :- 
      makewindow(13,7,7,"",10,10,3,50),
      write(S), readchar(_),
      removewindow.

goal
   message("Hello from Turbo Prolog"),
   hello_c.
