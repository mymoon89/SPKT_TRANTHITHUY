/*
   Turbo Prolog 2.0, Answer to second Exercise on page 196.
   
   Copyright (c) 1986, 88 by Borland International, Inc
*/
   
/*   
 *  This is an example of multiple predicate declarations.
 */

Domains
  name        = symbol

  namelist    = name* 
  integerlist = integer*	
  reallist    = real*
  stringlist  = string*
  charlist    = char*
  
Predicates
  member ( name, namelist )
  member ( real, reallist )
  member ( integer, integerlist )
  member ( string, stringlist )
  member ( char, charlist )
  
Clauses
  member(Head, [Head|_]).
  member(Element, [_|Tail]) :-
  	member(Element, Tail).  
