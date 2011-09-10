/*
   Turbo Prolog 2.0 Chapter 10, Example Program 3
   
   Copyright (c) 1986, 88 by Borland International, Inc
   
*/
   
shorttrace write_list, assert_facts
domains
   list = symbol*

database
   owns(symbol,symbol)

predicates
   assert_facts
   gather_goods(symbol)
   write_list(list)

clauses
   assert_facts :- 
         assertz( owns(micki, dog) ) ,
         assertz( owns(micki, car) ) ,
         assertz( owns(micki, dress) ) ,
         assertz( owns(eloise, car) ) ,
         assertz( owns(claudio, tennis_racket) ) ,
         assertz( owns(claudio, sneakers) ) ,
         assertz( owns(kenny, boots) ).

   gather_goods(Who) :-  
         findall(Goods, owns(Who,Goods), Goods_list) ,
         write(Who, " owns:\n") ,
         write_list(Goods_list).

   write_list([]):- !.
   write_list([H|T]) :-  write(H,"\n"), write_list(T).

goal
   assert_facts ,
   gather_goods(micki) ,
   write("That's all!\n").
