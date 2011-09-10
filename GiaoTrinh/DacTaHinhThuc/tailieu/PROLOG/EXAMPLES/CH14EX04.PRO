/*
   Turbo Prolog 2.0 Chapter 14, Example Program 4
   
   Copyright (c) 1986, 88 by Borland International, Inc
   
*/
   
predicates
   exp_window(integer)

clauses
   exp_window(0) :- !.
   exp_window(N) :-
      makewindow(_, _, _, _, A, B, C, D),
      A1 = A-1, B1 = B-2, C1 = C+2, D1 = D+4,
      resizewindow(A1,B1,C1,D1),
      N1 = N-1, exp_window(N1).

goal
   makewindow(1, 7, 7, "TEST 1", 10, 20, 3, 10),
   exp_window(9),
   makewindow(2, 7, 7, "TEST 2", 12, 50, 3, 10),
   exp_window(9),
   makewindow(3, 7, 7, "TEST 3", 14, 16, 3, 10),
   exp_window(8).
