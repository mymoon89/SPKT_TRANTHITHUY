/*
   Turbo Prolog 2.0, Answer to first Exercise on page 159.
   
   Copyright (c) 1986, 88 by Borland International, Inc
*/
   
/* 
 *   Uses repeat to keep accepting characters, printing 
 *   them all in upper case until the user presses Enter. 
 */

Predicates
   nondeterm repeat
   typewriter

Clauses
   repeat.
   repeat :- repeat.

   typewriter :- repeat,
                 readchar(C),        /* Read a char and bind it C */
                 upper_lower(C1,C) , /* Convert C to upper case   */
                 write(C1),
                 char_int(C,13).     /* Is C = ASCII 13? 
                                        This call will fail until a <CR> is
                                        hit.  When the user presses <CR>,
                                        the loop will finally succeed,
                                        ending the repeat/fail process.
                                     */
Goal
   makewindow(1,2,3," Typewriter ",0,0,25,80) ,
   typewriter.
   