/*
   Turbo Prolog 2.0 Chapter 4, Example Program 5
   
   Copyright (c) 1986, 88 by Borland International, Inc
   
*/
   
predicates
  isletter(char)

clauses
/* When applied to characters, '<=' means */
/* "alphabetically precedes or is the same as" */
  isletter(Ch) :- 'a' <= Ch, Ch <= 'z'.
  isletter(Ch) :- 'A' <= Ch, Ch <= 'Z'.

