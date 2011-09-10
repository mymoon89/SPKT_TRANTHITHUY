/*
   Turbo Prolog 2.0 Chapter 6, Example Program 1
   
   Copyright (c) 1986, 88 by Borland International, Inc
   
*/
   
domains 
   person                 = person(name,address)
   name                   = name(first,last)
   address                = addr(street,city,state)
   street                 = street(number,street_name)
   city,state,street_name = string
   first,last             = string
   number                 = integer

goal  
   P1 = person(name(jim,mos),addr(street(5,"1st st"),igo,"CA")),
   P1 = person(name(_,mos),Address),
   P2 = person(name(jane,mos),Address),
   write(P2).
