/*
   Turbo Prolog 2.0 Chapter 14, Example Program 5
   
   Copyright (c) 1986, 88 by Borland International, Inc
   
*/
   
domains
   monsters = integer*

predicates
   delay(integer)
   zapGun(integer, integer)
   delete(integer, monsters, monsters)
   testresult(monsters, integer)
   test(char, integer, integer)
   do_it(integer, monsters, integer)
   showThem(monsters, integer, char)

goal
   makewindow(1, 7, 0, "", 0, 0, 25, 80),
   do_it(56, [42, 45, 50, 55, 56, 59], 0).

clauses
   do_it(Initial, Monsters, Row) :-
      testresult(Monsters, Row),
      showThem(Monsters, Row, '\1'),
      readchar(Ch),
      test(Ch, Initial, Final),
      zapGun(24, Final),
      delete(Final, Monsters, LiveMonsters),
      NewRow = Row+1,
      cursor(24, Final),
      showThem(Monsters, Row, ' '),
      do_it(Final, LiveMonsters, NewRow).
   testresult([], _) :-
      write("\nWell done, Champion Zapper!"),
      delay(32000), exit.
   testresult(_, Row) :- Row<24, !.
   testresult(_, _) :-
      write("\nToo late, YOU have been zapped !"),
      delay(32000), exit.

   showThem([], _, _) :- !.
   showThem([Monster|TheRest], Row, Char) :-
      scr_char(Row, Monster, Char),
      showThem(TheRest, Row, Char).
   zapGun(N, C) :-
      N>0, !, scr_char(N, C, '^'), delay(150),
      scr_char(N, C, ' '), N1 = N-1, zapGun(N1, C).
   zapGun(_, _).

   test('z', 0, 0) :- !.
   test('x', 79, 79) :- !.
   test('z', OldCol, NewCol) :- !, NewCol = OldCol-1.
   test('x', OldCol, NewCol) :- !, NewCol = OldCol+1.
   test(_, C, C).

   delete(_, [], []).
   delete(X, [X|R], R) :- !.
   delete(X, [Y|R], [Y|R2]) :- !, delete(X, R, R2).

   delay(N) :- N>0, !, N1 = N-1, delay(N1).
   delay(0).

