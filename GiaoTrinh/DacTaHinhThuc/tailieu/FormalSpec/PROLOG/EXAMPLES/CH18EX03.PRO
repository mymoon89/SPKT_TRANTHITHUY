/*
   Turbo Prolog 2.0 Chapter 18, Example Program 3
   
   Copyright (c) 1986, 88 by Borland International, Inc
   
*/
   
domains
   room     =  symbol
   roomlist = room*

predicates
   gallery(room, room)                /* There is a gallery between two rooms */
   neighborroom(room, room)           /* Necessary because it does not matter */
				    /* which direction you go along a gallery */
   avoid(roomlist)
   go(room, room)
   route(room, room, roomlist)           /* This is the route to be followed. */
                     /* roomlist consists of a list of rooms already visited. */
   member(room, roomlist)

clauses
   gallery(entry, monsters).            gallery(entry,fountain).
   gallery(fountain, hell).         	gallery(fountain, food).
   gallery(exit, gold_treasure).    	gallery(fountain, mermaid).
   gallery(robbers, gold_treasure). 	gallery(fountain, robbers).
   gallery(food, gold_treasure).    	gallery(mermaid, exit).
   gallery(monsters, gold_treasure).	gallery(gold_treasure,exit).

   neighborroom(X, Y) :- gallery(X, Y).
   neighborroom(X, Y) :- gallery(Y, X).

   avoid([monsters, robbers]).

   go(Here, There) :- route(Here, There, [Here]).
   go(_, _).

   route(Room, Room, VisitedRooms) :-
      member(gold_treasure, VisitedRooms),  write(VisitedRooms), nl.
   route(Room, Way_out, VisitedRooms) :-
      neighborroom(Room, Nextroom),
      avoid(DangerousRooms),
      not(member(NextRoom, DangerousRooms)),
      not(member(NextRoom, VisitedRooms)),
      route(NextRoom, Way_out, [NextRoom|VisitedRooms]).

   member(X, [X|_]).
   member(X, [_|H]) :- member (X, H).
