/*
   Turbo Prolog 2.0 Chapter 19, Example Program 1
   
   Copyright (c) 1986, 88 by Borland International, Inc
   
*/
   
 /* Example: trapping the "file not open" error */ 

domains
   file = dd

predicates
   error(integer)
   process(string)

clauses
   process("a").
   process("b") :- writedevice(dd).

   error(E) :- writef("\nerror(%)", E).

goal
   trap(process(A), E, error(E) ),
   write("\nSuccessful process: A=", A),
   fail.
