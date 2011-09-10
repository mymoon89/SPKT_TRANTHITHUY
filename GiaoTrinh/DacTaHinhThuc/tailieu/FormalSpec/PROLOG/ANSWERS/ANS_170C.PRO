/*
   Turbo Prolog 2.0, Answer to third Exercise on page 170.
   
   Copyright (c) 1986, 88 by Borland International, Inc
*/

Predicates
  power_of_two ( integer )

Clauses

  power_of_two(10) :- !. 	% stop after 2^10 is processed
  power_of_two(Expon) :-
  	Exp1 = Expon + 1 ,
  	Num = exp( Exp1 * ln(2) ) ,
  	write("\t   ",Exp1,"\t\t   ",Num,"\n"),
  	power_of_two(Exp1).
  	
GOAL
  makewindow(1,2,3," Powers of Two ",0,0,25,80) ,
  write("\n\tExponent\tResult\n",
          "\t========\t======\n") ,
  power_of_two(0), nl.
    	  	

/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 
 *  Since Turbo Prolog does not contain a power function,    *
 
 *  one can be modeled with the following equation:          *
 
 *     M^n = exp( n * ln(M) )                                *
 
 *  where ln is the Logarithm to base e.                     *
 
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */  	