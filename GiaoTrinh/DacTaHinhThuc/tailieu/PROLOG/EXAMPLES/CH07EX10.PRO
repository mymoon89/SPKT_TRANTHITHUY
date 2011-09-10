/*
   Turbo Prolog 2.0 Chapter 7, Example Program 9
   
   Copyright (c) 1986, 88 by Borland International, Inc
   
*/
   
/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 * Simple tree-building procedures                                         *
 * create_tree(A, B) puts A in the data field of a one-cell tree giving B  *
 * insert_left(A, B, C) inserts A as left subtree of B giving C            *
 * insert_right(A, B, C) inserts A as right subtree of B giving C          *
 *									   *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

domains
   treetype = tree(string, treetype, treetype) ; empty()

predicates
   create_tree(string, treetype)
   insert_left(treetype, treetype, treetype)
   insert_right(treetype, treetype, treetype)

clauses
   create_tree(A, tree(A, empty, empty)).
   insert_left(X, tree(A, _, B), tree(A, X, B)).
   insert_right(X, tree(A, B, _), tree(A, B, X)).

goal

   /* First create some one-cell trees... */

   create_tree("Charles", Ch),
   create_tree("Hazel", H),
   create_tree("Michael", Mi),
   create_tree("Jim", J),
   create_tree("Eleanor", E),
   create_tree("Melody", Me),
   create_tree("Cathy", Ca),

   /* ...then link them up... */

   insert_left(Ch, Mi, Mi2),
   insert_right(H, Mi2, Mi3),
   insert_left(J, Me, Me2),
   insert_right(E, Me2, Me3),
   insert_left(Mi3, Ca, Ca2),
   insert_right(Me3, Ca2, Ca3),

   /* ...and print the result. */

   write(Ca3), nl.
