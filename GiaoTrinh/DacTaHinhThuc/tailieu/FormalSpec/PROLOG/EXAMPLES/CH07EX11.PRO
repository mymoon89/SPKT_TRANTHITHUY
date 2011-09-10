/*
   Turbo Prolog 2.0 Chapter 7, Example Program 11
   
   Copyright (c) 1986, 88 by Borland International, Inc
   
*/

domains
   chartree = tree(char, chartree, chartree); end

predicates
   do(chartree)
   action(integer, chartree, chartree)
   create_tree(chartree, chartree)
   insert(char, chartree, chartree)
   write_tree(chartree)
   repeat

goal
   do(end).

clauses
   do(Tree):-
      makewindow(1, 7, 7, "character tree sort", 0, 0, 20, 60),
      repeat,
      clearwindow,
      write("Enter 1 to create a tree\n"),
      write("Enter 2 to show tree\n"),
      write("Enter 7 to exit\n"),
      readint(X),
      action(X, Tree, NewTree),
      do(NewTree).

   action(1, Tree, NewTree):-
      write("Enter characters or # to end: "),
      create_Tree(Tree, NewTree).
   action(2, Tree, Tree):-
      write_Tree(Tree),
      write("\nPress a key to continue"),
      readchar(_).
   action(7, _, end):- exit.

   create_Tree(Tree, NewTree):-
      readchar(C),
      C<>'#',!,
      write(C, " "),
      insert(C, Tree, TempTree),
      create_Tree(TempTree, NewTree).
   create_Tree(Tree, Tree).

   insert(New, end, tree(New, end, end)):- !.
   insert(New, tree(Element, Left, Right), tree(Element, NewLeft, Right)):-
      New<Element, !,
      insert(New, Left, NewLeft).
   insert(New, tree(Element, Left, Right), tree(Element, Left, NewRight)):-
      insert(New, Right, NewRight).

   write_Tree(end).
   write_Tree(tree(Item, Left, Right)):-
      write_Tree(Left),
      write(Item, " "),
      write_Tree(Right).

   repeat.
   repeat:- repeat.