/*
   Turbo Prolog 2.0 Chapter 12, Example Program 9
   
   Copyright (c) 1986, 88 by Borland International, Inc
   
*/
   
domains
   file = myfile

predicates
   readloop

goal
   write("this program reads your input and writes it to TRYFILE.ONE\n"),
   openwrite(myfile, "tryfile.one"),
   writedevice(myfile),
   readloop,
   closefile(myfile),
   writedevice(screen),
   write("Your input has been transferred to the file tryfile.one").

clauses
   readloop:-readchar(X), X<>'#',!, write(X), readloop.
   readloop.
