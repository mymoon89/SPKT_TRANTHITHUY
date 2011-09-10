/*
   Turbo Prolog 2.0 Chapter 12, Example Program 8
      
   Copyright (c) 1986, 88 by Borland International, Inc
   
*/
   
domains
   list = integer*

predicates
   readlist(list)

goal
   makewindow(1, 7, 7, " Integer List ", 5, 5, 15, 70),
   write(" Type in a column of integers, like this:",
         "\n\n  integer (press ENTER)\n  integer (press ENTER)\n",
         "  etc.\n\n Type X (and press ENTER) to end the list.\n\n"),
   readlist(TheList),
   write("\nThe Turbo Prolog list is: ",TheList).
clauses
   readlist([H|T]) :- 
      write("\16 "),                         /* This prints the prompt symbol */
      readint(H), !,
      readlist(T).

   readlist([]).
