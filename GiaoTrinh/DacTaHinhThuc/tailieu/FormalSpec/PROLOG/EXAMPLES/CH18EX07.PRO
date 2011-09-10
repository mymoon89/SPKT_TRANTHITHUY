/*
   Turbo Prolog 2.0 Chapter 18, Example Program 7
   
   Copyright (c) 1986, 88 by Borland International, Inc
   
*/
   
domains
   queen    = q(integer, integer)
   queens   = queen*
   freelist = integer*
   board    = board(queens, freelist, freelist, freelist,
		    freelist)

predicates
   placeN(integer, board, board)
   place_a_queen(integer, board, board)
   nqueens(integer)
   makelist(integer, freelist)
   findandremove(integer, freelist, freelist)
   nextrow(integer, freelist, freelist)

clauses
   nqueens(N) :-
      makelist(N, L), Diagonal=N*2-1, makelist(Diagonal, LL),
      placeN(N, board([], L, L, LL, LL), Final), write(Final).

   placeN(_, board(D, [], [], D1, D2), board(D, [], [], D1, D2)):- !.
   placeN(N, Board1, Result) :-
      place_a_queen(N, Board1, Board2),
      placeN(N, Board2, Result).

   place_a_queen(N, board(Queens, Rows, Columns, Diag1, Diag2),
      board([q(R, C)|Queens], NewR, NewC, NewD1, NewD2)) :-
      nextrow(R, Rows, NewR),
      findandremove(C, Columns, NewC),
      D1 = N+C-R, findandremove(D1, Diag1, NewD1),
      D2 = R+C-1, findandremove(D2, Diag2, NewD2).

   findandremove(X, [X|Rest], Rest).
   findandremove(X, [Y|Rest], [Y|Tail]) :- findandremove(X, Rest,Tail).

   makelist(1, [1]).
   makelist(N, [N|Rest]) :- N1 = N-1, makelist(N1, Rest).
   nextrow(Row, [Row|Rest], Rest).
