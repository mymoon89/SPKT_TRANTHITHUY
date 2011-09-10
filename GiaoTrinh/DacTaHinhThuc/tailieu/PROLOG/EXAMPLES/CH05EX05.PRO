/*
   Turbo Prolog 2.0 Chapter 5, Example Program 5
   
   Copyright (c) 1986, 88 by Borland International, Inc
   
*/
   
predicates
   type(symbol, symbol)
   is_a(symbol, symbol)
   lives(symbol, symbol)
   can_swim(symbol)

goal
   can_swim(What) ,
   write("A ", What, " can swim.").

clauses
   type(ungulate, animal).
   type(fish, animal).

   is_a(zebra, ungulate).
   is_a(herring, fish).
   is_a(shark, fish).

   lives(zebra, on_land).
   lives(frog, on_land).
   lives(frog, in_water).
   lives(shark, in_water).

   can_swim(Y) :- 
    type(X, animal) ,
    is_a(Y, X) ,
    lives(Y, in_water). 
