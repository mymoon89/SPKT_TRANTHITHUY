/*
   Turbo Prolog 2.0 Chapter 16, Example Program 3
   
   Copyright (c) 1986, 88 by Borland International, Inc
   
*/
predicates
  extend(string, string) 

clauses
  extend(S,S):-concat(_,".pro",S), !.
  extend(S,S1):-concat(S,".pro",S1).

goal
        comline(X),   /* must be compiled to .exe to function correctly */
	extend(X,X1),
	file_str(X1,S),
	makewindow(1,23,8,"EDITOR",0,0,25,80),
	editmsg(S,S1,"","","",0,"",RET),
	removewindow,
	RET><1,!,
	file_str(X1,S1).
