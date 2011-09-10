/*
   Turbo Prolog 2.0 Chapter 5, Example Program 4
   
   Copyright (c) 1986, 88 by Borland International, Inc
   
*/
   
domains
   name, thing = symbol

predicates
   likes(name, thing)
   reads(name)
   is_inquisitive(name)

clauses
   likes(john, wine).
   likes(lance, skiing).
   likes(Z, books) :-
      reads(Z), is_inquisitive(Z).
   likes(lance, books).
   likes(lance, films).

   reads(john).
   is_inquisitive(john).