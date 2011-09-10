/*
   Turbo Prolog 2.0 Chapter 15, Example Program 3
   
   Copyright (c) 1986, 88 by Borland International, Inc
   
*/
   
domains
   db_selector = dba

predicates
   % List all keys in an index
   list_keys(db_selector, bt_selector)

clauses
   list_keys(dba, Bt_selector) :-
      key_current(dba, Bt_selector, Key, _),
      write(Key, ' '),
      fail.
   list_keys(dba, Bt_selector) :-
      key_next(dba, Bt_selector, _), !,
      list_keys(dba, Bt_selector).
   list_keys(_, _).

predicates
   open_dbase(bt_selector)
   main(db_selector, bt_selector)
   ed(db_selector, bt_selector, string)
   ed1(db_selector, bt_selector, string)

clauses
   % Loop until escape is pressed
   main(dba, Bt_select) :-
      write("File Name: "),
      readln(Name),
      ed(dba, Bt_select, Name), !,
      main(dba, Bt_select).
   main(_, _).

   % The ed predicates ensure that the edition will never fail. 
      ed(dba, Bt_select, Name) :-
         ed1(dba, Bt_select, Name), !.
      ed(_, _, _).

   /* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
    * There are three choices:                                  *
    *                                                           *
    * a) The name is an empty string - list all the names       *
    * b) The name already exists - modify the contents of the          file                                                   
    * c) The name is a new name - create a new file             *
    * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

   ed1(dba, Bt_select, "") :- !,
      key_first(dba, Bt_select, _),
      list_keys(dba, Bt_select),
      nl.
   ed1(dba, Bt_select, Name) :-
      key_search(dba, Bt_select, Name, Ref), !,
      ref_term(dba, string, Ref, Str),
      editmsg(Str, Str1, "Edit old", NAME, "", 0, "PROLOG.HLP", RET),
      clearwindow,
      Str><Str1, RET=0,
      term_replace(dba, string, Ref, Str1).
   ed1(dba, Bt_select, Name) :-
      editmsg("", STR1, "Create New", NAME, "", 0, "PROLOG.HLP", RET),
      clearwindow,
      ""><Str1, RET=0,
      chain_insertz(dba, file_chain, string, Str1, Ref),
      key_insert(dba, Bt_select, Name, Ref).
  
  open_dbase(INDEX):-
     existfile("dd1.dat"),!,
     db_open(dba, "dd1.dat", in_file),
     bt_open(dba, "ndx", INDEX).

  open_dbase(INDEX):-
     db_create(dba, "dd1.dat", in_file),
     bt_create(dba, "ndx", INDEX, 20, 4).
     

goal
   open_dbase(INDEX),
   main(dba, INDEX),
   bt_close(dba, INDEX),
   db_close(dba).
