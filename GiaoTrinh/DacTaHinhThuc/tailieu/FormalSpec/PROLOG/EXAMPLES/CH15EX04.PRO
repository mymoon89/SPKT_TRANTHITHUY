/*
   Turbo Prolog 2.0 Chapter 15, Example Program 4
   
   Copyright (c) 1986, 88 by Borland International, Inc
   
*/
constants
% register.bin may be in the programs directory "..\\programs\\register.bin"   
  filename = "register.bin"
domains
   db_selector = mydba
   mydom = city(zipcode, cityname);
           person(firstname, lastname, street, zipcode, code)
   zipcode, cityname, firstname, lastname, street, code  =  string

predicates
   listdba(db_selector)
   bt_keys(db_selector, bt_selector, string, ref)
   bt_keysloop(db_selector, bt_selector, string, ref)

clauses
   listdba(Db_selector) :-
      write("\n********************************************"),
      write("\n           DATABASE LISTING"),
      write("\n********************************************"),
      db_statistics(Db_selector, NoOfTerms, MemSize, DbaSize, FreeSize),
      write("\n\nTotal number of records in the database: ", NoOfTerms),
      write("\nNumber of bytes used in main memory: ", MemSize),
      write("\nNumber of bytes used by the database: ", DbaSize),
      write("\nNumber of bytes free on disk: ", FreeSize),
      fail.

   listdba(Db_selector) :-
      db_chains(Db_selector, Chain),
      write("\n\n\n\n******* Chain LISTING *************"),
      write("\n\nName=", Chain),
      write("\n\nCONTENT OF: ", Chain),
      write("\n------------------------------\n"),
      chain_terms(Db_selector, Chain, mydom, Term, Ref),
      write("\n", Ref, ": ", Term),
      fail.

   listdba(Db_selector) :-
      db_btrees(Db_selector, Btree),             /* Returns each B+ tree name */
      bt_open(Db_selector, Btree, Bt_selector),
      bt_statistics(Db_selector, Bt_selector, NoOfKeys,
                    NoOfPages, Dept, KeyLen, Order, PageSize),
      write("\n\n\n******** INDEX LISTING **************"),
      write("\n\nName=     ", Btree),
      write("\nNoOfKeys= ", NoOfKeys),
      write("\nNoOfPages=", NoOfPages),
      write("\nDept=     ", Dept),
      write("\nOrder=    ", Order),
      write("\nKeyLen=   ", KeyLen),
      write("\nPageSize= ", PageSize), nl,
      write("\nCONTENT OF: ", Btree),
      write("\n-----------------------------\n"),
      bt_keys(Db_selector, Bt_selector, Key, Ref),
      write("\n", Key, " - ", Ref),
      fail.
   listdba(_).

   bt_keys(Db_selector, Bt_selector, Key, Ref):-
      key_first(Db_selector, Bt_selector, _),
      bt_keysloop(Db_selector, Bt_selector, Key, Ref).

   bt_keysloop(Db_selector, Bt_selector, Key, Ref):-
      key_current(Db_selector, Bt_selector, Key, Ref).

   bt_keysloop(Db_selector, Bt_selector, Key, Ref):-
      key_next(Db_selector, Bt_selector, _),
      bt_keysloop(Db_selector, Bt_selector, Key, Ref).
      
goal
   db_open(mydba, filename , in_file),
   listdba(mydba).
