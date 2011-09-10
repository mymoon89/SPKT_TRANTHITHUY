/*
   Turbo Prolog 2.0 Chapter 13, Example Program 2
   
   Copyright (c) 1986, 88 by Borland International, Inc
   
*/
   
domains
   namelist = name*
   name  = symbol

predicates
   string_namelist(string, namelist)

clauses
   string_namelist(S, [H|T]) :- fronttoken(S, H, S1), !, string_namelist(S1, T).
   string_namelist(_, []).
