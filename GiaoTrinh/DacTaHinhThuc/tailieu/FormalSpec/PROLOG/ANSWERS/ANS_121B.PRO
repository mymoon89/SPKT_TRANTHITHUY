/*
   Turbo Prolog 2.0, Answer to second Exercise on page 121.
   
   Copyright (c) 1986, 88 by Borland International, Inc
*/

Domains
  name = string
  league = integer

Predicates
  run
  matches( name, league )
  challenges( name, league, league )
  show( name, league, name, league )
  player( name, league )

Clauses

/* 
 * List the matches for each player in the Club. 
 */

  run :-
    player( P, L ) ,
    matches( P, L ) ,
    fail ; true.

/* 
 * Each player can challenge a player in 
 *   the same league or in the league above,
 *   league 1 being the highest league.
 */

  matches( P, L ) :-
    challenges( P, L, L ) ,
    L1 = L-1 ,
    challenges( P, L, L1 ).

/* 
 * Find all challenge pairs. 
 */

  challenges( P1, L1, L2 ) :-  
    player( P2, L2 ) ,
    show( P1, L1, P2, L2 ) ,	% show() succeeds after all matches are found
    !. 				% Cut when show() succeeds.

/* 
 * Write out the possible challenges, until 
 *   the two players to write are the same.
 */

  show( P, _, P, _ ) :- !.	% show() succeeds when players are same
  show( P1, L, P2, L ) :-
    writef("% (%) can challenge (or can be challenged by) % (%).\n", 
           P1, L, P2, L ) ,
    !, fail.
  show( P1, L1, P2, L2 ) :-
    writef("% (%) can challenge % (%).\n", P1, L1, P2, L2 ) ,
    fail.

/* 
 * List of players and their leagues. 
 */

  player( tom, 2 ).
  player( liz, 1 ).
  player( ann, 3 ).
  player( sam, 1 ).
  player( jim, 2 ).
  player( ron, 1 ).
  player( pat, 3 ).

GOAL
  makewindow(1,2,3," Squash Club ",0,0,25,60) ,
  run.
  