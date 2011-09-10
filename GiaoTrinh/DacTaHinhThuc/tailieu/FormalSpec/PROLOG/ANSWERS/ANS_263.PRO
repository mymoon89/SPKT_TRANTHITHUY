/*
   Turbo Prolog 2.0, Answer to Exercise on page 263.
   
   Copyright (c) 1986, 88 by Borland International, Inc
*/

Domains
	sign = neg ; pos

Predicates
	check_binary ( integer, integer )
	write_answer ( sign, real )
	get_num ( real, real )	
	get_sign ( sign )
	power ( real, real, real )
	read_an_int ( integer )
	readbin
	repeat
	x_it

Clauses
	readbin:-
		write("Please enter a 16 bit binary number.\n\n"),
		write("Example :\n\n"),
		write("   BIT: 15 ------------ 0\n"),
		write("         1101001010011010\n\n"),
		write("BINARY : "),

		get_sign(Sign),

		get_num(Answer,15),  /* 15 is the current power of 2 */

		write_answer(Sign, Answer).

	get_sign(Sign):-
		read_an_int(Bin),
		Bin = 0, !,
		Sign = pos;
		Sign = neg.

	get_num(1,0):-!.
	get_num(Answer,Power):-
		read_an_int(Bin),
		NewPower = Power - 1,
		power(2,NewPower,Result),
		get_num(NewAnswer,Newpower),
		Answer = (Bin * Result) + NewAnswer.

	power(Num,Power,Ans):-
		Ans = exp( Power * ln(Num) ).

	write_answer(Sign, Answer):-
		Sign = neg, !,
		Signed = Answer * -1 + 1,
		Unsigned = Answer + 32767 ,
		write("\n\nINTEGER SIGNED   : ",Signed),
		write("\n\nINTEGER UNSIGNED : ",Unsigned),
		nl,nl;
		NewAnswer = Answer - 1,
		write("\n\nDECIMAL : ",NewAnswer),nl,nl.

	read_an_int(Bin):-
		readchar(Num) ,
		write(Num),
		check_binary(Num, Bin).
		
	check_binary(48,0) :- !.
	check_binary(49,1) :- !.
	check_binary(_,Bin) :- 
		beep,
		cursor(R,C) ,
		C1 = C - 1 ,
		cursor(R,C1),
		read_an_int(Bin).
		
	x_it :-
		write("Press X to exit...") ,
		repeat ,
		  readchar(X) ,
		upper_lower(X,'x').
		
	repeat :- true;repeat.		

GOAL
	makewindow(1,11,11," Binary - Decimal ",0,0,25,80,1,-1,"ոԾͳ"),
	readbin ,
	x_it
