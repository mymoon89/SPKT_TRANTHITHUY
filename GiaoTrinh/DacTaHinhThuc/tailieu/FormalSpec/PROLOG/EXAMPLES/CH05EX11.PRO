/*
   Turbo Prolog 2.0 Chapter 5, Example Program 11
   
   Copyright (c) 1986, 88 by Borland International, Inc
   
*/
   
predicates
   likes_shopping(symbol)
   has_credit_card(symbol, symbol)
   bottomed_out(symbol, symbol)

clauses
   likes_shopping(Who) :- 
      has_credit_card(Who, Card),
      not (bottomed_out(Who, Card) ) ,
      write(Who, " can shop with the ",Card, " credit card.\n").

   has_credit_card(chris, visa).
   has_credit_card(chris, diners).
   has_credit_card(joe, shell).
   has_credit_card(sam, mastercard).
   has_credit_card(sam, citibank).

   bottomed_out(chris, diners).
   bottomed_out(sam, mastercard).
   bottomed_out(chris, visa).
