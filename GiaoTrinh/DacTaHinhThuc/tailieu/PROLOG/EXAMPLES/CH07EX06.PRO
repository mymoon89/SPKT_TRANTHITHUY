/*
   Turbo Prolog 2.0 Chapter 7, Example Program 6
   
   Copyright (c) 1986, 88 by Borland International, Inc
   
*/
   
/* Shows how badcount2 and badcount3 can be fixed by adding cuts to
   rule out the untried clauses. These versions are tail recursive. */

predicates
   cutcount2(real)
   cutcount3(real)
   check(real)

clauses
/* cutcount2:
   There is a clause that has not been tried
   at the time the recursive call is made. */

   cutcount2(X) :- 
      X>=0, !,
      write(X),
      nl,
      NewX = X + 1,
      cutcount2(NewX).

   cutcount2(_) :- 
      write("X is negative.").

/* cutcount3:
   There is an untried alternative in a
   clause called before the recursive call. */

   cutcount3(X) :- 
      write(X),
      nl,
      NewX = X+1,
      check(NewX),
      !,
      cutcount3(NewX).

   check(Z) :- Z >= 0.
   check(Z) :- Z < 0.
