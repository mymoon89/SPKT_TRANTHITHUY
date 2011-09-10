/*
   Turbo Prolog 2.0 Chapter 7, Example Program 9
   
   Copyright (c) 1986, 88 by Borland International, Inc
   
*/
   
/* Traversing a tree by depth-first search
   and printing each element as it is encountered */

domains
  treetype = tree(string, treetype, treetype) ; empty()

predicates
   print_all_elements(treetype)

clauses
   print_all_elements(empty).

   print_all_elements(tree(X, Y, Z)) :-
      write(X), nl, 
      print_all_elements(Y),
      print_all_elements(Z).

goal
   print_all_elements(tree("Cathy",
                           tree("Michael",
                           tree("Charles", empty, empty),
                      tree("Hazel", empty, empty)),
                           tree("Melody",
                           tree("Jim", empty, empty),
                           tree("Eleanor", empty, empty)))).

