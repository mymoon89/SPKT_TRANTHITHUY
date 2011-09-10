/*
   Turbo Prolog 2.0 Chapter 5, Example Program 9
   
   Copyright (c) 1986, 88 by Borland International, Inc
   
*/

predicates
   repeat
   action(integer,string)
   test(string)
   
goal
   makewindow(1,7,7,"interaction window",0,2,11,43),
   repeat,
   shiftwindow(1),
   clearwindow,
   write("0. Enter 0 to end\n"),
   write("1. Enter 1 to create a window and input\n   a new string\n"),
   write("2. Enter 2 to remove the window and text\n"),
   write("3. Enter 3 to write to existing window\n\n"),
   write("Selection? "),
   readint(Int),nl,
   action(Int,Text),
   Int = 0,!,               /* this cut will prevent backtracking even if you
                                                    have not created a string */
   test(Text).
        
clauses
   action(0,"EXIT"):-!,              /* this cut prevents Turbo Prolog from looking
                                                            at other options. */
      exit.

   action(1,Str):- 
      existwindow(2),
      write("You have a window that already exists.\n"),
      write("Do you wish to clear it.(y,n) "),
      readchar(Ans),!,
      Ans='y',    /* If you answer yes to the question this cut prevents the 
                                 backtracking to the second action(1) clause. */
      nl,
      shiftwindow(2),
      clearwindow,
      write("Enter your string\n"),
      readln(Str).

   action(1,Str):- !,         /* this cut prevents Turbo Prolog from looking
                                                            at other options. */
      nl,
      makewindow(2,7,7," simple window control ", 12, 3, 12, 40),
      write("Enter your string\n"),
      readln(Str).

   action(2,"window removed"):-
      existwindow(2),
      !,    /* If the window has been input, this cut will prevent the second      
                                              action(2) clause from executing */
      shiftwindow(2),
      removewindow,
      clearwindow.

   action(2,"ERROR"):- 
      clearwindow,
      write("You must first create a window\n"),
      write("Press any key to continue "),
      readchar(_).
      
   action(3,Str):- 
      existwindow(2),!,
      shiftwindow(2),
      clearwindow,
      write("Enter your string\n"),
      readln(Str).

   action(3,Str):- 
      write("There is no window. Do you\n"),
      write("want to create one?(y/n) "),
      readchar(ANS),
      ANS = 'y',nl,
      makewindow(2,7,7," simple window control ",12,3,12,40),
      write("Enter your string\n"),
      readln(Str).

   action(_,"ERROR"):-
      write("not a valid option\n"),
      write("press any key to continue").

   test(Text):-
      write(Text).
      
   repeat.
   repeat:-repeat.
