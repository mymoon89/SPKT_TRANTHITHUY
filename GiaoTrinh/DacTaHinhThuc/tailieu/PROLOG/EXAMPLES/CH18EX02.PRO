/*
   Turbo Prolog 2.0 Chapter 18, Example Program 2
   
   Copyright (c) 1986, 88 by Borland International, Inc
   
*/
   
domains
   town     = symbol
   distance = integer

predicates
   road(town, town, distance)
   route(town, town, distance)

clauses
   road(tampa, houston, 200).
   road(gordon, tampa, 300).
   road(houston, gordon, 100).
   road(houston, kansas_city, 120).
   road(gordon, kansas_city, 130).
   route(Town1, Town2, Distance) :-
      road(Town1, Town2, Distance).
   route(Town1, Town2, Distance) :-
      road(Town1, X, Dist1),
      route(X, Town2, Dist2),
      Distance=Dist1+Dist2, !.
