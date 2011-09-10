/*
   Turbo Prolog 2.0 Chapter 12, Example Program 3
   
   Copyright (c) 1986, 88 by Borland International, Inc
   
*/
   
domains
   expr = number(integer); x; log(expr);
          plus(expr, expr); mult(expr, expr)

predicates
   writeExp(expr)

clauses
   writeExp(x) :- write('x').
   writeExp(number(No)) :- write(No).
   writeExp(log(Expr)) :- write("log("), writeExp(Expr), write(')').
   writeExp(plus(U1, U2)) :- writeExp(U1), write('+'), writeExp(U2).
   writeExp(mult(U1, U2)) :- writeExp(U1), write('*'), writeExp(U2).
