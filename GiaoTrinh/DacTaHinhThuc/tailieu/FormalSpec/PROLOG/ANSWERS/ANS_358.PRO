/*
   Turbo Prolog 2.0, Answer to Exercise on page 358.
   
   Copyright (c) 1986, 88 by Borland International, Inc
*/

Predicates
	use_myxor
	use_bitxor
	myxor(integer,integer,integer)

Clauses
	use_myxor:-
		write("Using MYXOR :"),nl,nl,
		write("Operator  p   q    p MYXOR q"),nl,
		write("----------------------------"),nl,
		write(" MYXOR"),
		myxor(0,0,Result00),
		myxor(0,1,Result01),
		myxor(1,0,Result10),
		myxor(1,1,Result11),
		write("    0   0        ",Result00),nl,
		write("          0   1        ",Result01),nl,
		write("          1   0        ",Result10),nl,
		write("          1   1        ",Result11),nl,nl,nl.

	myxor(A,B,Ans):-
		bitnot(B,NotB),bitand(A,NotB,AandNotB),
		bitnot(A,NotA),bitand(NotA,B,NotAandB),
		bitor(AandNotB,NotAandB,Ans).

	use_bitxor:-
		write("Using BITXOR :"),nl,nl,
		write("Operator  p   q   p BITXOR q"),nl,
		write("----------------------------"),nl,
		write(" BITXOR"),
		bitxor(0,0,Result00),
		bitxor(0,1,Result01),
		bitxor(1,0,Result10),
		bitxor(1,1,Result11),
		write("   0   0        ",Result00),nl,
		write("          0   1        ",Result01),nl,
		write("          1   0        ",Result10),nl,
		write("          1   1        ",Result11),nl,nl,nl.

GOAL
	makewindow(1,11,11," MyXor Vs. BitXor ",0,0,25,80,1,-1,"ոԾͳ"),
	use_myxor,
	use_bitxor.
