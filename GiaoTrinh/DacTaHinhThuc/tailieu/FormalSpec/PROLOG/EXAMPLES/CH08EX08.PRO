/*
   Turbo Prolog 2.0 Chapter 8, Example Program 8
   
   Copyright (c) 1986, 88 by Borland International, Inc
   
*/
   
domains
   name, address = string
   age = integer
   list = age*

predicates
   person(name, address, age)
   sumlist(list, age, integer)

goal
   findall(Age, person(_, _, Age), L),
   sumlist(L, Sum, N),
   Ave = Sum/N,
   write("Average =", Ave), nl.

clauses
   sumlist([], 0, 0).
   sumlist([H|T], Sum, N) :- sumlist(T, S1, N1), Sum=H+S1,
N=1+N1.

   person("Sherlock Holmes", "22B Baker Street", 42).
   person("Pete Spiers", "Apt. 22, 21st Street", 36).
   person("Mary Darrow", "Suite 2, Omega Home", 51).
