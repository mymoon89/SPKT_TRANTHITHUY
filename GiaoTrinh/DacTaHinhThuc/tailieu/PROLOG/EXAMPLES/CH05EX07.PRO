/*
   Turbo Prolog 2.0 Chapter 5, Example Program 7
   
   Copyright (c) 1986, 88 by Borland International, Inc
   
*/
    

predicates
   buy_car(symbol, symbol)
   car(symbol, symbol, integer)
   colors(symbol, symbol)

clauses
   buy_car(Model, Color) :- 
      car(Model, Color, Price),
      colors(Color, sexy),!,
      Price < 25000.

   car(maserati, green, 25000).
   car(corvette, black, 24000).
   car(corvette, red, 26000).
   car(porsche, red, 24000).
   colors(red, sexy).
   colors(black, mean).
   colors(green, preppy).
