/*
   Turbo Prolog 2.0 Chapter 3, Example Program 1
   
   Copyright (c) 1986, 88 by Borland International, Inc
  
*/   


predicates
   likes(symbol,symbol)

clauses
   likes(ellen, tennis).
   likes(john, football).
   likes(tom, baseball).
   likes(eric, swimming).
   likes(mark, tennis).
   likes(bill, Activity) if likes(tom, Activity).
