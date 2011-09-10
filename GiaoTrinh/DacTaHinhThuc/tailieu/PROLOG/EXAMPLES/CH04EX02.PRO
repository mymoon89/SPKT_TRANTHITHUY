/*
   Turbo Prolog 2.0 Chapter 4, Example Program 2
   
   Copyright (c) 1986, 88 by Borland International, Inc
   
*/

domains
   brand, color = symbol
   age, price = integer
   mileage = real

predicates
   car(brand, mileage, age, color, price)

clauses
   car(chrysler, 130000, 3, red, 12000).
   car(ford, 90000, 4, gray, 25000).
   car(datsun, 8000, 1, red, 30000).
