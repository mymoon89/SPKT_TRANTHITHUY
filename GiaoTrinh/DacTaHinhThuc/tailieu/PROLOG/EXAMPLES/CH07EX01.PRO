/*
   Turbo Prolog 2.0 Chapter 7, Example Program 1
   
   Copyright (c) 1986, 88 by Borland International, Inc
   
*/
   
predicates
   country(symbol)
   print_countries

clauses
   country(england).
   country(france).
   country(germany).
   country(denmark).

   print_countries :- country(X),
                     write(X),                        /* write the value of X */
                     nl,                                  /* start a new line */
                     fail.

   print_countries.
