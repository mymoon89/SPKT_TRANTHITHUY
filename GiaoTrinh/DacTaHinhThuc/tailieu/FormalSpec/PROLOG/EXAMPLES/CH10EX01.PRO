/*
   Turbo Prolog 2.0 Chapter 10, Example Program 1
   
   Copyright (c) 1986, 88 by Borland International, Inc
   
*/
   
domains
   list = integer*

predicates
   make_list ( integer, list, list )

goal
   make_list (1, [2,3], New_List).

clauses
   make_list (Head, List, [Head,List]).
