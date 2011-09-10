/*
   Turbo Prolog 2.0 Chapter 5, Example Program 12
   
   Copyright (c) 1986, 88 by Borland International, Inc
   
*/
   
trace
domains
   name, sex, occupation, object, vice, substance = symbol
   age=integer

predicates
   person(name, age, sex, occupation)
   had_affair(name, name)
   killed_with(name, object)
   killed(name)
   killer(name)
   motive(vice)
   smeared_in(name, substance)
   owns(name, object)
   operates_identically(object, object)
   owns_probably(name, object)
   suspect(name)

/* * * Facts about the murder * * */
clauses
   person(bert, 55, m, carpenter).
   person(allan, 25, m, football_player).
   person(allan, 25, m, butcher).
   person(john, 25, m, pickpocket).

   had_affair(barbara, john).
   had_affair(barbara, bert).
   had_affair(susan, john).

   killed_with(susan, club).
   killed(susan).

   motive(money).
   motive(jealousy).
   motive(righteousness).

   smeared_in(bert, blood).
   smeared_in(susan, blood).
   smeared_in(allan, mud).
   smeared_in(john, chocolate).
   smeared_in(barbara, chocolate).

   owns(bert, wooden_leg).
   owns(john, pistol).

/* * * Background knowledge * * */

   operates_identically(wooden_leg, club).
   operates_identically(bar, club).
   operates_identically(pair_of_scissors, knife).
   operates_identically(football_boot, club).

   owns_probably(X, football_boot) :-
      person(X, _, _, football_player).
   owns_probably(X, pair_of_scissors) :-
      person(X, _, _, hairdresser).
   owns_probably(X, Object) :-
      owns(X, Object).

/* * * * * * * * * * * * * * * * * * * * * * *
 * Suspect all those who own a weapon with   *
 * which Susan could have been killed.       *
 * * * * * * * * * * * * * * * * * * * * * * */

   suspect(X) :-
      killed_with(susan, Weapon) ,
      operates_identically(Object, Weapon) ,
      owns_probably(X, Object).

/* * * * * * * * * * * * * * * * * * * * * * * * * *
 * Suspect men who have had an affair with Susan.  *
 * * * * * * * * * * * * * * * * * * * * * * * * * */

   suspect(X) :-
      motive(jealousy) ,
      person(X, _, m, _) ,
      had_affair(susan, X).

/* * * * * * * * * * * * * * * * * * * * *
 * Suspect females who have had an       *
 * affair with someone that Susan knew.  *
 * * * * * * * * * * * * * * * * * * * * */

   suspect(X) :-
      motive(jealousy) ,
      person(X, _, f, _) ,
      had_affair(X, Man) ,
      had_affair(susan, Man).

/* * * * * * * * * * * * * * * * * * * * * * * * * * *
 * Suspect pickpockets whose motive could be money.  *
 * * * * * * * * * * * * * * * * * * * * * * * * * * */

   suspect(X) :-
      motive(money) , person(X, _, _, pickpocket).

   killer(Killer) :-
      person(Killer, _, _, _) ,
      killed(Killed) ,
      Killed <> Killer , /* It is not a suicide */
      suspect(Killer) ,
      smeared_in(Killer, Goo) ,
      smeared_in(Killed, Goo).
