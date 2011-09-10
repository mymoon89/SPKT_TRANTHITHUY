/*
   Turbo Prolog 2.0 Chapter 12, Example Program 6
      
   Copyright (c) 1986, 88 by Borland International, Inc
   
*/
   
goal
   person(N, A, I),
   /* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
    *  								  *
    *   Name	is left-justified, at least 15 characters wide    *
    *   Age	is right-justified, 2 characters wide             *
    *   Income	is right-justified, 9 characters wide, with 2     *
    *      	decimal places, printed in fixed-decimal          *
    *  		notation					  *
    *								  *
    * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
    
    writef("Name= %-15, Age= %2, Income= $%9.2f \n",N,A,I).