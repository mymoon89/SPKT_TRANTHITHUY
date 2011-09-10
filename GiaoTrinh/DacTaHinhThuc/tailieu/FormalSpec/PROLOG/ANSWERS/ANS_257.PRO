/*
   Turbo Prolog 2.0, Answer to Exercise on page 257.
   
   Copyright (c) 1986, 88 by Borland International, Inc
*/

Domains
  name, address, city ,
  company, mail_stop  = string
  state, zip          = symbol

Database
  address ( name, company, mail_stop, address, city, state, zip )

Predicates
  print_em ( char )
  print_labels
  print_company ( string )
  print_stop ( string )
  nondeterm repeat
  
Clauses
  print_em('s') :- 
  	!, clearwindow ,
  	print_labels.
  print_em('p') :-
  	!, write("\n\n  Printing...") ,
  	writedevice(printer) ,
  	print_labels ,
  	flush(printer), nl ,
  	writedevice(screen), nl, nl.
  print_em(_) :-
  	beep ,
  	write("\n\n  Not a valid resopnse...press a key to continue: ") ,
  	readchar(_), clearwindow ,
  	fail.

  print_labels :-
  	address(Name, Co, Stop, Add, City, State, Zip) ,
  	  print_company(Co) ,
  	  write(Name), nl ,
  	  print_stop(Stop) ,
  	  write(Add), nl ,
  	  writef("%, %  %", City, State, Zip) ,
  	  nl, nl, nl ,		% adjust new lines to fit your lables
  	fail ; true.
  	
  print_company("") :- !.	% if company is blank, do nothing
  print_company(Co) :-
  	write(Co), nl.
  	
  print_stop("") :- !.  	% if stop is blank, do nothing
  print_stop(Stop) :-
  	write(Stop), nl.
  	
  repeat :- true ; repeat.
  	
  address("Alice Brown", "", "", "23 N. Western Ave.", 
          "Calamazo", "TN", "32917-7098").
  address("Charles B. Knorthrop", "Maxin Corp.", "", "2000 Main St." ,
          "San Francisco", "CA", "94928").
  address("Maxine Wilson", "Bendix Ltd.", "Mail Stop 269" ,
          "3100 E Madison Ave.", "New York", "NY", "10001").
          
GOAL
  makewindow(1,2,3," Print Labels ", 0,0,25,80) ,
  repeat ,
    cursor(2,2) ,
    write("Do you want to print to the screen or the printer (S/P): ") ,
    readchar(Where) ,
    upper_lower(Where, There) ,
    print_em(There) ,
    write("  Done.") ,
    readchar(_).
    