/*
   Turbo Prolog 2.0 Chapter 5, Example Program 8
   
   Copyright (c) 1986, 88 by Borland International, Inc
   
*/
   
predicates
   friend(symbol, symbol)
   girl(symbol)
   likes(symbol, symbol)

clauses
   friend(bill, jane) :- 
      girl(jane),  likes(bill, jane), !.
   friend(bill, jim)  :- 
      likes(jim, baseball), !.
   friend(bill, sue)  :- 
      girl(sue).
   girl(mary).
   girl(jane).
   girl(sue).
   likes(jim, baseball).
   likes(bill, sue).
