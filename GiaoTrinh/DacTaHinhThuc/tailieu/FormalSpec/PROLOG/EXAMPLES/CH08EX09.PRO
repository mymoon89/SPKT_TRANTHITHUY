/*
   Turbo Prolog 2.0 Chapter 8, Example Program 9
   
   Copyright (c) 1986, 88 by Borland International, Inc
   
*/
   
domains
   llist = l(list); s(symbol); i(integer); c(char); t(string)
   list = llist*

predicates
   append(list, list, list)

goal
   makewindow(1, 7, 7, "answer", 15, 0, 8, 80),

/* * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 * Note how you can use the same code but need functors  *
 * append([ likes, [bill, mary] ], [ bill, sue ], Ans)   *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

   append([s(likes), l([s(bill), s(mary)])], [s(bill), s(sue)],
Ans),
   write("FIRST  LIST: ", Ans), nl, nl,

/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 * The trick is to write the list first, then add the functors *
 *   append([apple, [ [ [47], '\1'] ],                       *
 *   [ [ [ "This is a string", b, 7, 'W'] ], bee],           *
 *   [ 'c' ], Ans2)                                          *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
      append([l([s("This"),s("is"),s("a"),s("list")]), s(bee)], [c('c')], Ans2),
      write("SECOND LIST: ", Ans2), nl.

clauses
   /* Concatenate two lists */
   append([], L, L).
   append([X|L1], L2, [X|L3]) :- append(L1, L2, L3).
