/*
   Turbo Prolog 2.0, Answer to Exercise on page 248.
   
   Copyright (c) 1986, 88 by Borland International, Inc
*/

Constants
  conversion_factor = 180/3.14159265

Predicates
  get_vals ( real )
  list_vals ( real, real, real, real )
  run

Clauses
  run :-
  	makewindow(1,2,3, " Trig Table ", 0,0,25,80) ,
        write("  Angle\t\tSine\t\t Cosine\t\t  Tangent\n"),
        write("  =====\t\t====\t\t ===== \t\t  =======\n"),nl,
        get_vals(0).

  get_vals(Deg):-
        Deg < 361, !,
        Rad = Deg / ( conversion_factor ),
        Sine = sin(Rad),
        Cosine = cos(Rad),
        Tangent = tan(Rad),
        list_vals(Deg,Sine,Cosine,Tangent),
        NewAngle = Deg + 15,
        get_vals(NewAngle).
  get_vals(_).        

  list_vals(A,B,C,D):-
        writef("%4%18.6%18.6%18.6\n",A,B,C,D).

Goal
  run.