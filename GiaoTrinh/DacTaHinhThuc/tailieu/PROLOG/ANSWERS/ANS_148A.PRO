/*
   Turbo Prolog 2.0, Answer to first Exercise on page 148.
   
   Copyright (c) 1986, 88 by Borland International, Inc
*/

Domains
    lyrics = lyrics(symbol,symbol)
    music  = music(symbol,symbol)
    name   = string

Predicates
    show ( name, lyrics, music )
    write_shows

Clauses
    show("West Side Story", lyrics(stephen,sondheim),
          music(leonard,bernstein) ).
    show("Repo Man", lyrics(iggy,pop),
          music(iggy,pop) ).
    show("Live and Let Die", lyrics(paul,mc_cartney),
          music("",wings) ).
    show("Two Hundred Motels", lyrics(frank,zappa),
          music(mothers_of,invention) ).
    show("The King and I", lyrics(rogers,hammerstein),
          music("","?") ).
    show("Chess", lyrics("Andersson Rice","& Ulvaeus"),
          music(london,symphony) ).
    show("Stop Making Sense", lyrics(talking,heads),
          music(talking,heads) ).
          
    write_shows :-
    	show(Show, lyrics(First,Last), music(M_first, M_last) ) ,
    	write("The show ",Show," has music written by ",
    	      First," ",Last,".\nThe music is played by ",
    	      M_first," ",M_last,".\n\n") ,
    	fail.
    write_shows.

Goal
  makewindow(1,2,3," Musical Shows ",0,0,25,80) ,
  write_shows ,
  write("Press any key...") ,
  readchar(_).