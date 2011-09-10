/*
   Turbo Prolog 2.0 Chapter 4, Example Program 1
   
   Copyright (c) 1986, 88 by Borland International, Inc
   
*/

domains
   product, sum = integer

predicates
   add_em_up(sum, sum, sum)
   multiply_em(product, product, product)

clauses
   add_em_up(X, Y, Sum) :- Sum = X + Y.
   multiply_em(X, Y, Product) :- Product = X * Y.