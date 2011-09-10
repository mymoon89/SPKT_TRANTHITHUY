/*
   Turbo Prolog 2.0 Chapter 7, Example Program 2
   
   Copyright (c) 1986, 88 by Borland International, Inc
   
*/
   
/* Uses repeat to keep accepting characters and printing them
   until the user presses Enter. */

predicates
   repeat
   typewriter

clauses
   repeat.
   repeat :- repeat.

   typewriter :- 
      repeat,
      readchar(C),                               /* Read a char, bind C to it */
      write(C),
      char_int(C,13).                                     /* Is C = ASCII 13? */
