/*
   Turbo Prolog 2.0 Chapter 16, Example Program 2
   
   Copyright (c) 1986, 88 by Borland International, Inc
   
*/
predicates
   timer

clauses
   timer:-
      time(H1,M1,S1,D1),nl,
      write("Start time is: ",H1,":",M1,":",S1," and ",D1,"/100 sec"),nl,
      /* This is the activity that is being timed */
      system("dir *.*"),
      time(H2,M2,S2,D2),
      Time = (D2-D1) + 100 * ((S2 - S1) + 60 * ((M2 - M1) + 60 * (H2 - H1))),
      write("Elapsed time:  ",Time,"/100 sec"),nl,
      time(H3,M3,S3,D3),
      write("The time now is: ",H3,":",M3,":",S3," and ",D3,"/100 sec"),nl.

goal
   makewindow(1,7,7," Timer ",8,10,12,60),
   write("Press any key to start"),
   readchar(_),
   timer.
      