/*
   Turbo Prolog 2.0 Chapter 12, Example Program 11
      
   Copyright (c) 1986, 88 by Borland International, Inc
   
*/
   
domains
   file = input; output

predicates
   convert_file
   repfile(FILE)

goal
   write("Which file do you want convert ?"),
   readln(InputFileName),
   write("What is the name of the output file ?"),
   readln(OutputFileName),
   openread(input, InputFileName),
   readdevice(input), 
   openwrite(output, OutputFileName),
   writedevice(output), 
   convert_file,
   closefile(input),
   closefile(output).

clauses
   convert_file :-
      repfile(input),
      readln(Ln),
      upper_lower(LnInUpper,Ln),          /* converts the string to upprecase */
      write(LnInUpper),nl,
      fail.
   convert_file.

   repfile(_).
   repfile(F):- not(eof(F)),repfile(F).
