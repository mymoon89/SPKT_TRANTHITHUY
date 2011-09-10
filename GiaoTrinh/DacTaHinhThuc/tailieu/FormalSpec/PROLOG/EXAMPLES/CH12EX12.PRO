/*
   Turbo Prolog 2.0 Chapter 12, Example Program 12
   
   Copyright (c) 1986, 88 by Borland International, Inc
   
*/
   
domains
   file 	 = datafile; indexfile
   name, address = string
   age 		 = integer
   sex 		 = m or f
   interest      = symbol
   interests     = interest*

  /* record        = person(name, address, age, sex, interests) */
   
   filename = string
   filepos = real

database - record
   person(name, address, age, sex, interests)
   
predicates
   dbassert(record) 		% user-defined assert
   dbretract(record)		% user-defined retract
   dbread(record)		% User defined database acces

   dbass(record, filename, filename)
   dbaaccess(record, filepos)
   dbret(record, filename, filename)
   dbret1(record, filepos)
   dbrd(record, filename, filename)

clauses
/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 * Entry routines. These can be changed to fit the actual      *
 * application: for example, extended to a pool of open files  *
 * in order to access several databases at a time, or to allow *
 * more than one data file.                                    *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
   dbassert(Term) :- dbass(Term, "dba.ind", "dba.dat").
   dbretract(Term) :- dbret(Term, "dba.ind", "dba.dat").
   dbread(Term) :- dbrd(Term, "dba.ind", "dba.dat").

   /* dbass appends a term to the data file and updates the index file  */

   dbass(Term, IndexFile, DataFile) :-
      existfile(DataFile), existfile(IndexFile), !,
      openappend(datafile, DataFile),
      writedevice(datafile),
      filepos(datafile, Pos, 0),
      write(Term), nl,
      closefile(datafile),
      openappend(indexfile, IndexFile),
      writedevice(indexfile),
      writef("%7.0\n", Pos),
      closefile(indexfile).

   dbass(Term, IndexFile, DataFile) :-
      openwrite(datafile, DataFile),
      writedevice(datafile),
      filepos(datafile, Pos, 0),
      write(Term), nl,
      closefile(datafile),
      openwrite(indexfile, IndexFile),
      writedevice(indexfile),
      writef("%7.0\n", Pos),
      closefile(indexfile).

  /* * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
   * dbrd returns terms from the database. The files are     *
   * closed after the database has been read.                *
   * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

   dbrd(Term, IndexFile, DataFile) :-
      openread(datafile, DataFile),
      openread(indexfile, IndexFile),
      dbaaccess(Term, -1).
 
   dbrd(_, _, _) :-
      closefile(datafile), closefile(indexfile), fail.
 
   dbaaccess(Term, Datpos) :-
      Datpos >= 0,
      filepos(datafile, Datpos, 0),
      readdevice(datafile),
      readterm(record, Term).

   dbaaccess(Term, _) :-
      readdevice(indexfile),
      readreal(Datpos1),
      dbaaccess(Term, Datpos1).

  /* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
   * dbret retracts terms from the database. A term is         *
   * retracted by writing a negative number in the index file. *
   * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

   dbret(Term, Indexfile, Datafile) :- 
      openread(datafile, DataFile),
      openmodify(indexfile, IndexFile),
      dbret1(Term, -1).

   dbret1(Term, Datpos) :- 
      Datpos >= 0,
      filepos(datafile, Datpos, 0),
      readdevice(datafile),
      readterm(record, Term), !,
      filepos(indexfile, -9, 1),
      flush(indexfile),
      writedevice(indexfile),
      writef("%7.0\n", -1),
      writedevice(screen).

   dbret1(Term, _) :-
      readdevice(indexfile),
      readreal(Datpos1),
      dbret1(Term, Datpos1).
