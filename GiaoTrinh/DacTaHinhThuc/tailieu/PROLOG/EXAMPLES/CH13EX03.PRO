/*
   Turbo Prolog 2.0 Chapter 13, Example Program 3
   
   Copyright (c) 1986, 88 by Borland International, Inc
   
*/
   
domains
   tok  = numb(integer); name(string); char(char)
   toklist = tok*

predicates
   scanner(string, toklist)
   maketok(string, tok)

clauses
   scanner("", []).
   scanner(Str, [Tok|Rest]) :-
      fronttoken(Str, Sym, Str1), maketok(Sym, Tok), scanner(Str1, Rest).
      maketok(S, name(S)) :- isname(S).
      maketok(S, numb(N)) :- str_int(S, N).
      maketok(S, char(C)) :- str_char(S, C).
goal
   write("Enter some text:"),nl,
   readln(Text),nl,
   scanner(Text,T_List),
   write(T_List).
   