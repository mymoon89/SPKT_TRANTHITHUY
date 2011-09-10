/*
   Turbo Prolog 2.0, Answer to third Exercise on page 203.
   
   Copyright (c) 1986, 88 by Borland International, Inc
*/


/*
  The flatten program for complex lists is an
  advanced technique. Please read the "Fascinating
  Worlds of Lists and Recursion " and "Basic Language
  Elements" in your manual.

  Complex lists are handled by the following domain
  declarations. A list must have a functor as shown
  and then must be declared recursively.
*/

Domains
  element = l(list) ; s(symbol) ; i(integer) ; c(char) ; t(string) ; r(real)
  list = element*

Predicates
   append(list,list,list)
   flatten_list(list)
   flatten(list,list)

Goal
 makewindow(1,2,3," Flatten ",0,0,25,80) ,

 List_to_flatten = [l([l([s(a)]) ,
                    l([]) ,
                    l([l([l([t("b")]),c('c')])]) ,
                    l([i(4),r(5.0001)]), s(f)])] ,

 write("Flatten the list:\n\n",List_to_flatten,"\n\n") ,                    
 flatten_list( List_to_flatten ) ,
 write("\n\nPress any key...") ,
 readchar(_).
               
/*

  The trick is to write the list first, then add the functors:
    flatten_list( [ [ a ] , [ ] , [ [ [ b ] , c ] ] , [ d , e ] , f ]).
    
  Adding the functors gives the following Turbo Prolog list:
   flatten_list([l([l([s(a)]) ,
                l([]) ,
                l([l([l([s(b)]),s(c)])]) ,
                l([s(d),s(e)]) ,
                s(f)])]).
  
*/
Clauses
    flatten_list(List) :- 
                 flatten(List, Flat_List), nl ,
                 write("The list flattened is:\n\n",
                       Flat_List,"\n\n"), fail;true.
   
    flatten([],[]).                  /* terminating clause */
    
    flatten([l(X)|X1], Y) :-       /* if the head of the list is a list */
           flatten(X,Y1) ,           /* flatten the head of the list      */
           flatten(X1,Y2) ,          /* then flatten the tail             */
           append(Y1, Y2, Y).        /* append the flat head to the tail  */

    flatten([X|X1],[X|Y]) :-         /* if the head is not a list, move   */
           not( X=l(_) ),
           flatten(X1,Y) .           /* it to the tail; flatten the tail  */
           
    append([],L,L).
    append([X|L1],L2,[X|L3]):-append(L1,L2,L3).
