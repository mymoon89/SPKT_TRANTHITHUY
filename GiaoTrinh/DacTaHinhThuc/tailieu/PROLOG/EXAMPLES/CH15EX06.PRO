/*
   Turbo Prolog 2.0 Chapter 15, Example Program 6
   
   Copyright (c) 1986, 88 by Borland International, Inc
   
*/

constants
% register.bin may be in the programs directory "..\\programs\\register.bin"   
  filename = "register.bin"
   
domains
   Db_selector = myDba
   chainterm  = chain(string, mydom)
   file = outfile
   mydom = city(zipcode, cityname);
   person(firstname, lastname, street, zipcode, code)
   zipcode, cityname, firstname, lastname = string
   street, code = string

predicates
   wr(chainterm)
   dumpDba(string, string)

clauses
   wr(X) :- write(X), nl.

   dumpDba(Db_selector, OutFile) :-
      db_open(myDba, Db_selector, in_file),
      openwrite(outfile, OutFile),
      writedevice(outfile), 
      db_chains(myDba, Chain),
      chain_terms(myDba, Chain, mydom, Term, _),
      wr(chain(Chain, Term)),
      fail.

   dumpDba(_, _) :-
      closefile(outfile),
      db_close(myDba).

goal
   dumpDba(filename, "register.txt").
