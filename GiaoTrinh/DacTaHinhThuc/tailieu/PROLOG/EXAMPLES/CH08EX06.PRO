/*
   Turbo Prolog 2.0 Chapter 8, Example Program 6
   
   Copyright (c) 1986, 88 by Borland International, Inc
   
*/
   
domains
   namelist = name*
   name = symbol

predicates
   is_a_member_of(name, namelist)

clauses
   is_a_member_of(Name, [Name|_]).
   is_a_member_of(Name, [_|Tail]) :- is_a_member_of(Name, Tail).
