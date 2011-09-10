/*
   Turbo Prolog 2.0 Chapter 12, Example Program 4
   
   Copyright (c) 1986, 88 by Borland International, Inc
   
*/
   
domains
   sentence   = sentence(nounphrase, verbphrase)
   nounphrase = nounp(article, noun); name(name)
   verbphrase = verb(verb); verbphrase(verb, nounphrase)
   article, noun, name, verb = symbol

predicates
   write_sentence(sentence)
   write_nounphrase(nounphrase)
   write_verbphrase(verbphrase)

clauses
   write_sentence(sentence(S, V)) :-
      write_nounphrase(S) , write_verbphrase(V).
   write_nounphrase(nounp(A, N)) :- write(A, ' ', N, ' ').
   write_nounphrase(name(N)) :- write(N, ' ').
   write_verbphrase(verb(V)) :- write(V, ' ').
   write_verbphrase(verbphrase(V, N)) :-
      write(V, ' ') , write_nounphrase(N).
