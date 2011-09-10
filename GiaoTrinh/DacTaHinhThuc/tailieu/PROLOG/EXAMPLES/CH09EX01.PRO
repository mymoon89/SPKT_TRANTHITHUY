/*
   Turbo Prolog 2.0 Chapter 9, Example Program 1
   
   Copyright (c) 1986, 88 by Borland International, Inc
   
*/
   
domains
   thing = string
   conds = cond*
   cond  = string

database
   is_a(thing, thing, conds)
   type_of(thing, thing, conds)
   false(cond)

predicates
   run(thing)
   ask(conds)

clauses
   run(Item):-
      is_a(X, Item, List),
      ask(List),
      type_of(ANS, X, List2),
      ask(List2),
      write("The ", Item," you need is a/an ", Ans),nl.

   run(_):- 
      write("This program does not have enough "),
      write("data to draw any conclusions."),
      nl.

   ask([]).
   ask([H|T]):-
      not(false(H)),
      write("Does this thing help you to "),
      write(H," (enter y/n)"),
      readchar(Ans), nl, Ans='y',
      ask(T).

   ask([H|_]):-
      assertz(false(H)), fail.

   is_a(language, tool, ["communicate"]).
   is_a(hammer, tool, ["build a house", "fix a fender", "crack a nut"]).
   is_a(sewing_machine, tool, ["make clothing", "repair sails"]).
   is_a(plow, tool, ["prepare fields", "farm"]).

   type_of(english, language, ["communicate with people"]).
   type_of(prolog, language, ["communicate with a computer"]).
