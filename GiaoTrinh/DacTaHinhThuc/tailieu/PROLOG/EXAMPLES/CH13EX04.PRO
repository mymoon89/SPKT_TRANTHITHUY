/*
   Turbo Prolog 2.0 Chapter 13, Example Program 4
   
   Copyright (c) 1986, 88 by Borland International, Inc
   
*/
   
domains
   sentence    = s(noun_phrase,verb_phrase)

   noun_phrase = noun(noun) ; noun_phrase(detrm,noun)
   noun        = string

   verb_phrase = verb(verb) ; verb_phrase(verb,noun_phrase)
   verb        = string

   detrm       = string

predicates
    s_sentence(string,sentence)
    s_noun_phrase(string,string,noun_phrase)
    s_verb_phrase(string,verb_phrase)
    d(string)
    n(string)
    v(string)

clauses
   s_sentence(Str, s(N_Phrase,V_Phrase) ):-
      s_noun_phrase(Str, Rest, N_Phrase),
      s_verb_phrase(Rest, V_Phrase).

  s_noun_phrase(Str, Rest, noun_phrase(Detr,Noun)):-
      fronttoken(Str,Detr,Rest1),
      d(Detr),
      fronttoken(Rest1,Noun,Rest),
      n(Noun).

  s_noun_phrase(Str,Rest,noun(Noun)):-
      fronttoken(STR,Noun,Rest),
      n(Noun).

  s_verb_phrase(Str, verb_phrase(Verb,N_Phrase)):-
      fronttoken(Str,Verb,Rest1),
      v(Verb),
      s_noun_phrase(Rest1,"",N_Phrase).

  s_verb_phrase(Str,verb(Verb)):-
      fronttoken(STR,Verb,""),
      v(Verb).

/* determiner */

   d("the").
   d("a").

/* nouns */

   n("bill").
   n("dog").
   n("cat").

/* verbs */

   v("is").
