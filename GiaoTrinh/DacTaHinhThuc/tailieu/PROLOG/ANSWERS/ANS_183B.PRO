/*
   Turbo Prolog 2.0, Answer to Second Exercise on page 183.
   
   Copyright (c) 1986, 88 by Borland International, Inc

   Please note, we have added a KEY associated with each text string
   to make this example a bit more realistic.
*/
domains

  textlink = link(KEY,Text,TextLink) ; nil
  text = string
  KEY = string
  
predicates
  w_str(string)
  do(textlink)
  options(textlink)
  insert(KEY,string,textlink,textlink)
  showtext(textlink)
  showkey(KEY,textlink)
  do_choice(char,textlink,textlink)
  repeat

goal

  do(nil).

clauses

  do(Link):-
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
    do_choice(Choice,Link,NewLink),
    do(NewLink).

  do_choice('a',nil,link(KEY,Text,nil)):-
    write("Please enter a key for text :"),nl,
    % Your options
    readln(KEY),KEY<>"",nl,nl,
    write("Please enter a line of text :"),nl,
    readln(Text).

  do_choice('a',Link,NewLink):-
    write("Please enter a key for text :"),nl,
    write("\nOptions are:\n"),
    options(Link),
    readln(KEY),KEY<>"",nl,nl,
    write("Please enter a line of text :"),nl,
    readln(Text),
    insert(KEY,Text,Link,NewLink).

  do_choice('s',Link,Link):-
    showtext(Link),
    readchar(_).

  do_choice('k',Link,Link):-
    write("enter key:"),nl,
    readln(Key),
    showkey(Key,Link),
    readchar(_).

  do_choice('e',_,_):-
    exit.

  insert(KEY,Text,nil,link(KEY,Text,nil)):-!.

  insert(KEY,Text,link(Old_id,OldText,Next),link(Old_id,Oldtext,NewNext)):-
    insert(KEY,Text,Next,NewNext).

  showtext(nil).
  showtext(link(KEY,Text,Next)):-
    write(KEY,"\n",Text),nl,nl,
    showtext(Next).

  showkey(KEY,link(KEY,Text,_)):-!,
    write(KEY,"\n",Text).
  showkey(KEY,link(_,_,Next)):-
    showkey(KEY,Next).
  showkey(KEY,_):-
    write(KEY," is an invalid key."),
    readchar(_).  

  repeat.
  repeat:-repeat.
  
  
w_str(""):-!.
w_str(Str):-
   fronttoken(Str,Sym,Rest),
   write(Sym),nl,
   w_str(Rest).
   
Options(link(_,Str,nil)):-!,
  w_str(Str).   
Options(link(_,Str,Link)):-!,
  w_str(Str),
  Options(Link).   
   
   