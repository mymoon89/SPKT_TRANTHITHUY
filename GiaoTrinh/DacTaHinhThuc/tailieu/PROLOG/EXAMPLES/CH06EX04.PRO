/*
   Turbo Prolog 2.0 Chapter 6, Example Program 4
   
   Copyright (c) 1986, 88 by Borland International, Inc
   
*/
   
domains
   articles            = book(title, author) ; 
                         horse(name) ; boat ; 
                         bankbook(balance)
   title, author, name = symbol
   balance             = real

predicates
   owns(name,articles)

clauses
   owns(john, book("A friend of the family", "Irwin Shaw")).
   owns(john, horse(blacky)).
   owns(john, boat).
   owns(john, bankbook(1000)).
