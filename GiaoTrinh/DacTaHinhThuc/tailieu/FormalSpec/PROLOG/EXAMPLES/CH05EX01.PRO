/*
   Turbo Prolog 2.0 Chapter 5, Example Program 1
   
   Copyright (c) 1986, 88 by Borland International, Inc
   
*/
   
domains
   title, author = symbol
   pages         = integer

predicates
   book(title, pages)
   written_by(author, title)
   long_novel(title)

clauses
   written_by(fleming, "DR NO").
   written_by(melville, "MOBY DICK").
   book("MOBY DICK", 250).
   book("DR NO", 310).
   long_novel(Title) :- 
      written_by(_, Title),
      book(Title, Length),
      Length > 300.
