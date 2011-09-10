/*
   Turbo Prolog 2.0 Chapter 7, Example Program 10
   
   Copyright (c) 1986, 88 by Borland International, Inc
   
   
   Fast tree-based sort program.
   Reads lines from a file, sorts them in alphabetical
   order, and writes them on another file.

*/

domains
   treetype = tree(string, treetype, treetype) ; empty
   file     = infile ; outfile                        /* covered in Chapter 9 */

predicates
   main
   read_input(treetype)
   read_input_aux(treetype, treetype)
   insert(string, treetype, treetype)
   write_output(treetype)

clauses

main :-
   clearwindow,                            /* Main procedure, invoked by goal */
   write("Turbo Prolog Treesort"),nl,
   write("File to read:  "),
   readln(In),
   openread(infile, In),               /* open the specified file for reading */
   write("File to write: "),
   readln(Out),
   openwrite(outfile, Out),
   readdevice(infile),     /* redirect all read operations to the opened file */
   read_input(Tree),
   writedevice(outfile),   /* redirect all write operations to the opened file */
   write_output(Tree),
   closefile(infile),                    /* close the file opened for reading */
   closefile(outfile).

main :-
   /* Execution drops to this clause if   */
   /* anything in the preceding one fails */
   closefile(outfile),
   writedevice(screen),
   write("Unable to perform sort.\n"),
   write("Probable cause: can't open file.\n").

/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 * read_input(Tree)                                            *
 *   reads lines from the current input device until EOF, then *
 *   instantiates Tree to the binary search tree built         *
 *   therefrom                                                 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

read_input(Tree) :-
   read_input_aux(empty,Tree).

/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 * read_input_aux(Tree, NewTree)                                *
 *  reads a line, inserts it into Tree giving NewTree,         *
 *  and calls itself recursively unless at EOF.                *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

read_input_aux(Tree, NewTree) :-
   readln(S),
   !,
   insert(S, Tree, Tree1),
   read_input_aux(Tree1, NewTree).

read_input_aux(Tree, Tree). /* If the first clause failed, this
is EOF.
 So the second clause succeeds with no further action. */

/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 *  insert(Element, Tree, NewTree)                             *
 *     inserts Element into Tree giving NewTree.               *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

insert(NewItem, empty, tree(NewItem, empty, empty)) :- !.

insert(NewItem, tree(Element, Left, Right), tree(Element,
NewLeft, Right)) :-
      NewItem < Element,
      !,
      insert(NewItem, Left, NewLeft).

insert(NewItem, tree(Element, Left, Right), tree(Element, Left,
NewRight)) :-
      insert(NewItem, Right, NewRight).

/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 * write_output(Tree)                                          *
 *    writes out the elements of Tree in alphabetical order.   *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

write_output(empty). /* Do nothing */

write_output(tree(Item, Left, Right)) :-
     write_output(Left),
     write(Item), nl,
     write_output(Right).


goal
   main.
