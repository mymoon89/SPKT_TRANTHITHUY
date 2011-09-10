/*
   Turbo Prolog 2.0 Chapter 9, Example Program 2
   
   Copyright (c) 1986, 88 by Borland International, Inc
   
*/

domains 
   screen_name   = symbol                           /* Each screen has a name */
   field_name    = symbol                                      /* Handy types */
   row, col, len = integer                                    /* for defining */
   type          = int(); str(); real()                           /* a screen */
   
database - screen      /* This database section stores the actual screen form */

   field(field_name, type, row, col, len)
   textfield(row, col, len, string)

database - screens                            /* Stores all the known screens */
   screen(screen_name, screen)

predicates                          /* Performs shifting of the actual screen */
   shiftscreen(screen_name)

clauses
   shiftscreen(Screen):-
      retractall(_, Screen),
      screen(Screen, ScreenFact),
      assert(ScreenFact),
      fail.
   shiftscreen(_).

/* Screen layout for a person record */
  screen(person,field("fname",str,6,16,36)).
  screen(person,field("lname",str,8,15,37)).
  screen(person,field("street",str,10,12,40)).
  screen(person,field("zipcode",str,12,14,7)).
  screen(person,field("cityname",str,12,33,19)).
  screen(person,field("code",str,15,17,35)).
  screen(person,textfield(15,4,12,"Person Code:")).
  screen(person,textfield(12,22,10,"City Name:")).
  screen(person,textfield(12,4,8,"Zip code:")).
  screen(person,textfield(10,4,7,"Street")).
  screen(person,textfield(6,4,11,"First Name:")).
  screen(person,textfield(8,4,10,"Last Name:")).

/* Screen layout for a city record */
  screen(city,field("zipcode",str,8,16,7)).
  screen(city,field("cityname",str,11,18,43)).
  screen(city,textfield(8,7,9,"Zip Code:")).
  screen(city,textfield(11,7,10,"City Name:")).
  