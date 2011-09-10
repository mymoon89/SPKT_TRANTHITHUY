/*
   Turbo Prolog 2.0 Chapter 19, Example Program 2
   
   Copyright (c) 1986, 88 by Borland International, Inc
   
*/
   
domains
   dom = f(INTEGER)
   list = integer *

database - mydba
   p1(INTEGER, STRING, CHAR, REAL, DOM, LIST)

predicates
   repeat
   handleconsulterr(STRING, INTEGER)

clauses
   repeat.
   repeat:-repeat.

   handleconsulterr(File, Err):-
      Err>1100, Err<1110, !,
      retractall(_, mydba),
      consulterror(_, LinePos, Filepos),
      Pos=LinePos+FilePos,
      % may need a path to "..\\prolog.err"
      errormsg("prolog.err", Err, Msg, _), 
      file_str(File, Str),
      edit(Str, Str1, "Consult error", File, Msg, Pos,"prolog.hlp", 1, 1, 1, 0, _, RetStatus),
      RetStatus=0,
      file_str(File, Str1).
   handleconsulterr(_, Err):-
      exit(Err).

goal
   repeat,
      File="dd.dat",
      trap(consult(File, mydba), Err, handleconsulterr(File,Err)),
      write("\nSUCCESS\n"),
      save(con, mydba).
