/*
   Turbo Prolog 2.0, Answer to second Exercise on page 148.
   
   Copyright (c) 1986, 88 by Borland International, Inc
*/

/*
 * This program sets up a database of US Senators.  Compound
 *  objects are used in the Senators record whenever logically 
 *  possible.  Data entry of the records is left to the user.
 *
 *  (Note: This program was apparently written by a student who 
 *         peaked ahead in the manual.  However, the important 
 *         thing to look at is how the user-defined domains 
 *         are used in the predicate declarations.)
 */
 
Domains
  fname, lname, 
  state, bill   =  string
  mon           =  symbol
  day, year     =  integer 
  party         =  r ; d
  vote          =  y ; n ; a 
  name          =  n ( lname, fname )
  affil         =  a ( state, party )
  constituency  =  real
  elec_date     =  d ( mon, day, year )
  record        =  r ( bill, vote )
  vote_record   =  record*	% Vote Record is a list of records
  
Database
  senator ( name, affil, constituency, elec_date, vote_record )  
  
/*
 * Example senator data record:
 *   
 *   senator( n("Hows", "Sammy R.") ,
 *            a( "ca", D ) ,
 *            17484 ,
 *            d( "aug", 10, 1982 ) ,
 *            [ r( "SB 98-103", N) ,
 *              r( "SJ 98-104", N) ,
 *              r( "SB 98-105", A) ,
 *              r( "SB 98-106", Y) ,
 *              r( "SB 98-107", N) ,
 *              r( "SJ 98-108", A) ,
 *              r( "SB 98-109", A) ,
 *              r( "SB 98-110", Y) ,
 *              r( "SB 98-111", N) ,
 *              r( "SB 98-112", N)]).
 */             
  
Predicates
  add_a_senator
  add_a_vote
  append ( vote_record, vote_record, vote_record )
  consult_file
  convert_party ( char, party )
  convert_vote ( char, vote )
  get_con ( constituency )
  get_date ( elec_date )
  get_day ( day )
  get_new_vote ( bill, vote )
  get_party ( party )
  get_senator ( name, affil, constituency, elec_date, vote_record )
  get_vote ( vote )
  get_vote_record ( integer, vote_record )
  get_year ( year )
  list_senators
  menu
  number_of_vote_records ( vote_record, integer )
  process_choice ( char )
  process_vote ( vote_record, integer, vote_record )
  read_file
  repeat
  save_file
  write_votes ( vote_record )
  
Clauses
/*
 *  Main Loop
 */
  menu :- 
	repeat ,
  	  makewindow(2,2,3," Menu ",5,5,12,30), nl ,
  	  write("Add a new senator\n") ,
  	  write("Update a senator's record\n") ,
  	  write("List senators\n") ,
  	  write("Save new database\n") ,
  	  write("Consult senator database\n") ,
  	  write("eXit\n\n") ,
  	  write("Enter a Choice: ") ,
  	  readchar(Choice) ,
  	  upper_lower(Ch, Choice) ,
  	  removewindow , 
  	  process_choice(Ch) ,
  	Ch = 'X'.

  process_choice('A') :- !, add_a_senator.
  process_choice('U') :- !, add_a_vote.
  process_choice('L') :- !, list_senators.
  process_choice('S') :- !, save_file.
  process_choice('C') :- !, consult_file.
  process_choice('X').

/*
 * Add a New Senator 
 */
  add_a_senator :-
  	makewindow(3,3,4,"New Senator",0,0,25,80) ,
  	repeat ,
       	  clearwindow ,
  	  field_str(0,2,14,"First Name   :") ,
  	  field_str(1,2,14,"Last Name    :") ,
  	  field_str(2,2,14,"State        :") ,
  	  field_str(3,2,14,"Party        :") ,
  	  field_str(4,2,14,"Constituency :") ,
  	  field_str(5,2,14,"Date Elected  ") ,
  	  field_str(6,5,11,   "Month     :") ,
  	  field_str(7,5,11,   "Day       :") ,
  	  field_str(8,5,11,   "Year      :") ,
  	  field_str(10,2,35,
  	       "Voting Record (10 bills Maximum):") ,
  	  cursor(0, 17), readln(Fname) ,
  	  cursor(1, 17), readln(Lname) ,
  	  Name = n(Lname, Fname) ,
  	  cursor(2, 17), readln(State) ,
  	  get_party(Party) ,
  	  Afil = a(State, Party) ,
  	  get_con(Con) ,
  	  get_date(Date) ,
  	  cursor(11,4) ,
  	  write("(Maximum number of 10 votes or <RETURN> to stop." , 
  	        "  Vote: Y, N or A)") ,
  	  get_vote_record(10,Record) ,
  	  assertz( senator( Name, Afil, Con, Date, Record) ) ,
	  write("\nDo you wish to add another Senator? (Y/N): ") ,
	  readchar(Ans), write(Ans) ,
	upper_lower(Ans, 'n'), ! ,
	removewindow.

  get_party(Party) :-  
    	repeat ,
  	  cursor(3, 17), readchar(C) ,
  	  upper_lower(C1, C), write(C1) ,
  	convert_party (C1,Party), !.
  	
  convert_party('D', d) :- !.
  convert_party('R', r) :- !.  	
  convert_party(_,_) :- beep, fail.  	

  get_con(Con) :-	
  	cursor(4, 17), 
  	readreal(Con), !.
  get_con(Con) :-
  	beep, get_con(Con).  	
  	
  get_date(Date) :-
        cursor(6,17) ,
  	readln(Month) ,
  	get_day(Day) ,
  	get_year(Year) ,
  	Date = d(Month, Day, Year).
  	
  get_day(D) :-  	
  	cursor(7, 17) , 
  	readint(D), !.
  get_day(D) :-
  	beep, get_day(D).
    	
  get_year(Y) :-	    	
  	cursor(8,17) , 
  	readint(Y), !.
  get_year(Y) :-
  	beep, get_year(Y).  	
  	
  get_vote_record(0,[]) :- !.   
  get_vote_record(Num,[H|T]) :- 
   	Num1 = Num - 1 ,
   	Num_in = abs( Num - 11 ) ,
   	cursor(R,_) ,
   	R1 = R+1 ,
  	cursor(R1,8) ,
   	writef("%)  Bill Number:", Num_in) ,
   	cursor(R1,25) ,
   	readln(Bill) ,
   	Bill <> "", ! ,		% Check for a <CR>
	get_vote(Vote) ,
   	H = r(Bill, Vote) ,
   	get_vote_record(Num1, T).
  get_vote_record(_,[]).   	%  This will succeed when a <CR> is hit

  get_vote(Vote) :-
        cursor(R,_) ,
        R1 = R - 1 ,
        repeat ,
   	cursor(R1,40) ,
   	write("Senator Vote: ") ,
   	readchar(V) ,
   	upper_lower(V1, V) ,
   	write(V1) ,
   	convert_vote(V1, Vote), !.

  convert_vote('Y', y) :- !.
  convert_vote('N', n) :- !.
  convert_vote('A', a) :- !.
  convert_vote(_,_) :- beep, fail.

/*
 *  Update a Senator's Vote Record
 */
  add_a_vote :-
    	makewindow(3,6,5," Add a Senators Vote ",2,2,21,76) ,
	cursor(2,2) ,
	write("First Name : ") ,
	cursor(3,2) ,
	write("Last Name  : ") ,
	cursor(2,16) ,
	readln(Fname) ,
	cursor(3,16) ,
	readln(Lname) ,
	get_senator(n(Lname, Fname),_,_,_,_) ,	% see if name exists
	repeat ,
    	  get_senator(n(Lname, Fname),_,_,_,Votes) ,
	  number_of_vote_records(Votes, Num) ,
	  process_vote(Votes, Num, New_votes) ,
	  retract( senator(n(Lname, Fname),A,B,C,Votes) ) ,
	  assertz( senator(n(Lname, Fname),A,B,C,New_votes) ) ,
	  write("\n\nWould you like to add another " ,
	        "vote to this Senator? (Y/N): ") ,
	  readchar(Ans), write(Ans), nl ,
	  clearwindow ,
	upper_lower('N', Ans) ,
	removewindow, !.
  add_a_vote :- removewindow.	
	
  process_vote([_|T], 10, New_votes) :-
	!, get_new_vote(Bill, Vote) ,
	append(T, [r(Bill,Vote)], New_votes).
  process_vote(Votes, _, New_votes) :-
  	get_new_vote(Bill, Vote) ,	
	append(Votes, [r(Bill,Vote)], New_votes).

  get_new_vote(Bill, Vote) :-
  	cursor(R,_) ,
  	R1 = R + 1 ,
  	cursor(R1,2) ,
  	write("Bill Number: ") ,
  	readln(Bill) ,
  	R2 = R1 + 1 ,
  	repeat ,
  	  cursor(R2,2) ,
  	  write("Senator's Vote: ") ,
  	  readchar(V) ,
  	  upper_lower(V1, V) ,
  	  write(V1) ,
  	convert_vote(V1, Vote), !.

  get_senator(Name, Affil, Constituency, Elec_date, Vote_record) :-
	senator(Name, Affil, Constituency, Elec_date, Vote_record) ,
	! ; write("Senator Name not found!\n" ,
	          "Press a key to continue...") ,
	readchar(_), clearwindow, fail.

/*
 *  List Senators
 */
  list_senators :-
  	write("Senators Name\tState  Party  Constituency  Date Elected  Voting Record\n" ,
  	      "=============\t=====  =====  ============  ============  =============\n") ,
        senator(n(L,F), a(S,P), C, d(M,D,Y), R ) ,
        convert_party(P1,P) ,
        str_int(Day, D) ,
        str_int(Year, Y) ,
        concat(M,"/",D1) ,
        concat(D1,Day,D2) ,
        concat(D2,"/",D3) ,
        concat(D3,Year,Date) ,
        concat(F," ",F1),
        concat(F1,L,FL),
  	writef("\n%-10 \t %-2      %-1       %-9.0     %-8    ", 
  	        FL,S,P1,C,Date),
  	write_votes(R) ,
  	fail.
  list_senators :-  	
  	write("\nPRESS a key...") ,
  	readchar(_) ,
  	clearwindow.

  write_votes([]) :- !.
  write_votes([r(Bill, Vote)|T]) :-
	convert_vote(V, Vote) ,
  	writef("%s-%\n", Bill, V) ,
  	cursor(Row,_),
  	cursor(Row,59),
  	write_votes(T).
/*
 *  Save Senator's Database to Disk
 */
  save_file :-
  	write("\nSaving Database...\n") ,
  	save("SENATORS.dba"), clearwindow.

/*
 * Consult Senator's Databse File
 */
  consult_file :-
  	senator(_,_,_,_,_), ! ,
  	write("Database already in memory.\n" ,
  	      " Press any key to continue...") ,
  	readchar(_), clearwindow.
  consult_file :-
  	existfile("SENATORS.dba"), ! ,
  	read_file.
  consult_file :-
  	write("Senators Database file not found!\n" ,
  	      " (You must create and save a database\n" ,
  	      "   before one can be consulted.)\n\n" ,
  	      "Press any key to continue...") ,
  	readchar(_) ,
  	clearwindow.
  	
  read_file :-  	         
	write("\nConsulting Database...\n") ,
  	consult("SENATORS.dba"), ! ,
  	clearwindow ; beep ,
        write("ERROR in database!\n" ,
              "Press any key to continue...") ,
        readchar(_), clearwindow.


/*
 *  System Predicates
 */
  repeat :- true;repeat.	
  
  append([],L,L).
  append([H|L1],L2,[H|L3]) :- append(L1,L2,L3).
  
  number_of_vote_records([],0) :- !.
  number_of_vote_records([_|T],N) :-
  	number_of_vote_records(T, N1) ,
  	N = N1 + 1.
    
GOAL
  makewindow(1,2,3," Senators Database ",0,0,25,80) ,
  menu.  
  