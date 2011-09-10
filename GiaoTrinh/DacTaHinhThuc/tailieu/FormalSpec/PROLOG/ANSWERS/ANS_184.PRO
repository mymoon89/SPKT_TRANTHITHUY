/*
   Turbo Prolog 2.0, Answer to Third Exercise on page 184.
   
   Copyright (c) 1986, 88 by Borland International, Inc

   Please note, we have added a KEY associated with each text string
   to make this example a bit more realistic.
*/
domains
  text = string
  KEY = string
  
database - textlink
   link(key,text)
  
predicates
  w_str(string)
  options  
  showtext
  showkey(KEY)
  do_choice(char)
  repeat

goal
    makewindow(1,11,14," HYPER TEXT ",0,0,25,80,1,-1,"ոԾͳ"),
    repeat,
    clearwindow,
    makewindow(3,10,0,"",23,1,1,78),
    write(" Select your option by selecting first letter"),
    makewindow(2,10,12," Main Menu ",10,30,6,17,1,-1,"ڿ��ĳ"),
    write("Add a new text\n"),
    write("Show all text\n"),
    write("Key text\n"),
    write("Exit program"),
    cursor(0,0),
    readchar(Choice),
    removewindow,
    removewindow,
    do_choice(Choice),
    fail.
    
clauses
  do_choice('a'):-
    not(link(_,_)),!,
    write("Please enter a key for text :"),nl,
    % Your options
    readln(KEY),KEY<>"",nl,nl,
    write("Please enter a line of text :"),nl,
    readln(Text),
    asserta(link(Key,Text)).

  do_choice('a'):-
    write("Please enter a key for text :"),
    write("\nOptions are:\n"),
    options,
    readln(KEY),KEY<>"",
    write("\n\nPlease enter a line of text :"),nl,
    readln(Text),
    assertz(link(KEY,Text)).

  do_choice('s'):-
    showtext,
    readchar(_).

  do_choice('k'):-
    write("enter key:"),nl,
    readln(Key),
    showkey(Key),
    readchar(_).

  do_choice('e'):-
    exit.

  showtext:-
    link(Key,Text),
    write(KEY,"\n",Text),nl,nl,
    fail.
  showtext.

  showkey(KEY):-
    link(Key,Text),!,
    write("\n",Text).
  showkey(Key):-
    write(KEY," is an invalid key."),
    readchar(_).  

  Options:-
    link(_,Str),
    w_str(Str),fail.   
  Options.  

  w_str(""):-!.
  w_str(Str):-
     fronttoken(Str,Sym,Rest),
     write(Sym),nl,
     w_str(Rest).
   
  repeat.
  repeat:-repeat.
   
 