/*
   Turbo Prolog 2.0 Chapter 15, Example Program 5
   
   Copyright (c) 1986, 88 by Borland International, Inc
   
*/
      /* Logging database opertations */
      
domains 
   logdom = insert(relation,dbdom,ref);
   	    replace(relation,dbdom,ref,dbdom);
   	    erase(relation,ref,dbdom)

predicates
   logdbchange(logdom)      	    

clauses
   logdbchange(Logterm):-
      chain_insertz(logdba,logchain,logdom,Logterm,_),
      db_flush(logdba).


                /* ch15ex05.pro */

domains
   dbdom = city(zipcode, cityname);
   person(firstname, lastname, street, zipcode, code)
   zipcode, cityname, firstname, lastname = string
   street, code = string
   indexName = person_name; person_adr; city_no
   relation  = city; person
   db_selector = dba; logdba

database
   indices(IndexName, bt_selector)     /* This takes and index name (a key) that
is a person's name or address or a city number; it also takes a B+ tree selector
									      */
predicates
   xname(FirstName, LastName, string)    /* This predicate creates an index name
            from a last name (20 characters) and a first name (10 characters) */
clauses
   xname(F, L, S) :-
      str_len(L, LEN), LEN>20, !,
      frontstr(20, L, L1, _),
      format(S, "%-20%", L1, F).

   xname(F, L, S) :-
      format(S, "%-20%", L, F).

predicates
   dba_insert(relation, dbdom)
   dba_replace(relation, dbdom, Ref)
   dba_erase(relation, Ref)

clauses
   dba_insert(person, Term) :- !,
      break(OldBreak),
      break(off),
      indices(person_name, I1),
      indices(person_adr, I2), !,
      Term = person(Fname, Lname, Adr, _, _),
      xname(Fname, Lname, Xname),
      chain_insertz(dba, person, dbdom, Term, Ref),
      key_insert(dba, I1, Xname, Ref),
      key_insert(dba, I2, Adr, Ref),
      db_flush(dba),
      logdbchange(insert(person, Term, Ref)),
      break(OldBreak).

   dba_insert(city, Term) :-
      break(OldBreak),
      break(off),
      indices(city_no, I), !,
      Term = city(ZipCode, _),
      chain_insertz(dba, city, dbdom, Term, Ref),
      key_insert(dba, I, ZipCode, Ref),
      db_flush(dba),
      logdbchange(insert(city, Term, Ref)),
      break(OldBreak).

   dba_replace(person, NewTerm, Ref) :- !,
      break(OldBreak),
      break(off),
      indices(person_name, I1),
      indices(person_adr, I2), !,
      ref_term(dba, dbdom, Ref, OldTerm),
      OldTerm = person(OldFname, OldLname, OldAdr, _, _),
      xname(OldFname, OldLname, OldXname),
      key_delete(dba, I1, OldXname, Ref),
      key_delete(dba, I2, Oldadr, Ref),
      NewTerm = person(NewFname, NewLname, NewAdr, _, _),
      xname(NewFname, NewLname, NewXname),
      term_replace(dba, dbdom, Ref, NewTerm),
      key_insert(dba, I1, NewXname, Ref),
      key_insert(dba, I2, NewAdr, Ref),
      db_flush(dba),
      logdbchange(replace(person, NewTerm, Ref, OldTerm)),
      break(OldBreak).

   dba_replace(city, NewTerm, Ref) :- !,
      break(OldBreak),
      break(off),
      indices(city_no, I), !,
      ref_term(dba, dbdom, Ref, OldTerm),
      OldTerm = city(OldZipCode, _),
      key_delete(dba, I, OldZipCode, Ref),
      NewTerm = city(ZipCode, _),
      term_replace(dba, dbdom, Ref, NewTerm),
      key_insert(dba, I, ZipCode, Ref),
      db_flush(dba),
      logdbchange(replace(city, NewTerm, Ref, OldTerm)),
      break(OldBreak).

   dba_erase(person, Ref) :- !,
      break(OldBreak),
      break(off),
      indices(person_name, I1),
      indices(person_adr, I2), !, 
      ref_term(dba, dbdom, Ref, OldTerm),
      OldTerm = person(OldFname, OldLname, OldAdr, _, _),
      xname(OldFname, OldLname, OldXname),
      key_delete(dba, I1, OldXname, Ref),
      key_delete(dba, I2, OldAdr, Ref),
      term_delete(dba, person, Ref),
      db_flush(dba),
      logdbchange(erase(person, Ref, OldTerm)),
      break(OldBreak).

   dba_erase(city, Ref) :-
      break(OldBreak),
      break(off),
      indices(city_no, I), !,
      ref_term(dba, dbdom, Ref, OldTerm),
      OldTerm = city(OldZipCode, _),
      key_delete(dba, I, OldZipCode, Ref),
      term_delete(dba, city, Ref),
      db_flush(dba),
      logdbchange(erase(city, Ref, OldTerm)),
      break(OldBreak).
