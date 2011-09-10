/*
   Turbo Prolog 2.0 Chapter 6, Example Program 3
   
   Copyright (c) 1986, 88 by Borland International, Inc
   
*/
   
domains
   name = person(symbol, symbol)                             /* (First, Last) */
   birthday = b_date(symbol, integer, integer)          /* (Month, Day, Year) */
   ph_num = symbol					      /* Phone_number */

predicates
   phone_list(name, symbol, birthday)
   get_months_birthdays
   convert_month(symbol, integer)
   check_birthday_month(integer, birthday)
   write_person(name)

clauses
   get_months_birthdays :-
      makewindow(1, 7, 7, " This Month's Birthday List ", 0, 0, 25, 80),
      write(" First name\t Last Name\n"),
      date(_, This_month, _),                  /* Get month from system clock */
      phone_list(Person, _, Date),
      check_birthday_month(This_month, Date),
      write_person(Person), fail.

   get_months_birthdays :-
      write("\n\n Press any key to continue: "),
      readchar(_).

   write_person(person(First_name, Last_name)) :-
      write("  ", First_name, "\t\t  ", Last_name), nl.

   check_birthday_month(Mon, b_date(Month, _, _)) :-
      convert_month(Month, Month1),
      Mon = Month1.
   
   phone_list(person(ed, willis), "767-8463", b_date(jan, 3, 1955)).
   phone_list(person(benjamin, thomas), "438-8400", b_date(feb, 5, 1985)).
   phone_list(person(ray, william), "555-5653", b_date(mar, 3, 1935)).
   phone_list(person(thomas, alfred), "767-2223", b_date(apr, 29, 1951)).
   phone_list(person(chris, grahm), "555-1212", b_date(may, 12, 1962)).
   phone_list(person(dustin, robert), "438-8400", b_date(jun, 17, 1980)).
   phone_list(person(anna, friend), "767-8463", b_date(jun, 20, 1986)).
   phone_list(person(brandy, rae), "555-5653", b_date(jul, 16, 1981)).
   phone_list(person(naomi, friend), "767-2223", b_date(aug, 10, 1981)).
   phone_list(person(christina, lynn), "438-8400", b_date(sep, 25, 1981)).
   phone_list(person(kathy, ann), "438-8400", b_date(oct, 20, 1952)).
   phone_list(person(elizabeth, ann), "555-1212", b_date(nov, 9, 1984)).
   phone_list(person(aaron, friend), "767-2223", b_date(nov, 15, 1987)).
   phone_list(person(jennifer, caitlin), "438-8400", b_date(dec, 31, 1981)).

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
