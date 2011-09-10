/*
   Turbo Prolog 2.0, Answer to Exercise on page 143.
   
   Copyright (c) 1986, 88 by Borland International, Inc
*/
   
Domains
   name = person(symbol, symbol)  
             /* (First,   Last) */
             
   birthday = b_date(symbol, integer, integer)  
                 /* (Month,   Day,     Year) */

Predicates
   check_birthday_month(integer, birthday)
   determ convert_month(symbol, integer)
   get_months_birthdays
   phone_list(name, symbol, birthday)
   write_person(name, symbol, birthday)

Clauses
   phone_list(person(ed, willis), "767-8463", 
              b_date(jan, 3, 1955)).
   phone_list(person(benjamin, thomas), "438-8400", 
              b_date(feb, 5, 1985)).
   phone_list(person(ray, william), "555-5653", 
              b_date(mar, 3, 1935)).
   phone_list(person(thomas, alfred), "767-2223", 
              b_date(apr, 29, 1951)).
   phone_list(person(chris, grahm), "555-1212", 
              b_date(may, 12, 1962)).
   phone_list(person(dustin, robert), "438-8400", 
              b_date(jun, 17, 1980)).
   phone_list(person(anna, friend), "767-8463", 
              b_date(jun, 20, 1986)).
   phone_list(person(brandy, rae), "555-5653", 
              b_date(jul, 16, 1981)).
   phone_list(person(naomi, friend), "767-2223", 
              b_date(aug, 10, 1981)).
   phone_list(person(christina, lynn), "438-8400", 
              b_date(sep, 25, 1981)).
   phone_list(person(kathy, ann), "438-8400", 
              b_date(oct, 20, 1952)).
   phone_list(person(elizabeth, ann), "555-1212", 
              b_date(nov, 9, 1984)).
   phone_list(person(aaron, friend), "767-2223", 
              b_date(nov, 15, 1987)).
   phone_list(person(jennifer, caitlin), "438-8400", 
              b_date(dec, 31, 1981)).

   get_months_birthdays :-
      write(" First name\t Last Name \t Phone  \t Birth Day\n",
            " ==========\t===========\t========\t===========\n\n"),
      date(_, This_month, _),       % Get month from system clock 
      phone_list(Person, Phone, Date),
      check_birthday_month(This_month, Date),
      write_person(Person, Phone, Date) ,
      fail.		            % fail to get all birthdays
   get_months_birthdays.

   write_person( person(First, Last), Phone, b_date(Mon,Day,Year) ) :-
      writef("  %-10\t %-10\t%-7\t%/%/%\n" ,
             First, Last, Phone, Mon, Day, Year).

   check_birthday_month(Mon, b_date(Month, _, _)) :-
      convert_month(Month, Month1),
      Mon = Month1.

   convert_month(jan, 1).
   convert_month(feb, 2).
   convert_month(mar, 3).
   convert_month(apr, 4).
   convert_month(may, 5).
   convert_month(jun, 6).
   convert_month(jul, 7).
   convert_month(aug, 8).
   convert_month(sep, 9).
   convert_month(oct, 10).
   convert_month(nov, 11).
   convert_month(dec, 12).

Goal
  makewindow(1,2,3," This Month's Birthday List ",0,0,25,80),
  get_months_birthdays ,
  nl.
