/*
   Turbo Prolog 2.0, Answer to Exercise on page 155.
   
   Copyright (c) 1986, 88 by Borland International, Inc
*/
   
% Uses backtracking to print all solutions to a query.

Predicates
   country(symbol,real)
   %      (name  ,population)  
   print_countries

Clauses
   country(england,3e7).
   country(france,2.3e7).
   country(germany,1.6e7).
   country(denmark,2.4e6).
   country(canada,7.3e6).
   country(chile,2.5e).

   print_countries :- 
   	country(X,P),     /* bind country name to X and population to P */
   	P > 1e7,          /* is population greater than 10 million? */
        write(X),         /* write the value of X */
        nl,               /* start a new line */
        fail.             /* force backtracking to find all solutions */
   print_countries.       /* make sure print_countries succeeds */
