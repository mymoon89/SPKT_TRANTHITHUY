/*
   Turbo Prolog 2.0 Chapter 13, Example Program 1
   
   Copyright (c) 1986, 88 by Borland International, Inc
   
*/
   
domains
   charlist = char*

predicates
   string_chlist(string, charlist)

clauses
   string_chlist("", []).
   string_chlist(S, [H|T]) :- frontchar(S, H, S1), string_chlist(S1, T).
