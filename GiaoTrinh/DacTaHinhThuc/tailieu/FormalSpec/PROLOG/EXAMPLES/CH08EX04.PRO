/*
   Turbo Prolog 2.0 Chapter 8, Example Program 4
   
   Copyright (c) 1986, 88 by Borland International, Inc
   
*/
    
trace
domains
   list = integer*

predicates
   add1(list, list)

clauses
   add1([], []). /* boundary condition */
   add1([Head|Tail], [Head1|Tail1]) :- /* separate the head */
 /* from the rest of the list */
      Head1= Head+1, /* add 1 to the first element */
      add1(Tail, Tail1). /* call element with the rest of the
list */
