/*
   Turbo Prolog 2.0 Chapter 12, Example Program 5
      
   Copyright (c) 1986, 88 by Borland International, Inc
   
*/
   
   /* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
    * writef is similar to formatted-print statements in other    *
    * programming languages. writef accepts an output string      *
    * and a set of bound variables and constants as its arguments *
    *                     	     				  *
    *          writef(FormatString, Arg1, Arg2,...)		  *
    *                            				  *
    * The arguments are inserted into the output string at the    *
    * locations of the format specifiers.			  *
    *								  *
    * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
    
goal
   A = one,
   B = 330.12,
   C = 4.3333375,
   D = "one two three",
   writef("A = '%-7' \nB = '%8.1e'\n",A,B),
   writef("A = '%' \nB = '%8.4e'\n",A,B),nl,
   writef("C = '%-7.7g' \nD = '%7.7e'\n",C,D),
   writef("C = '%-7.0f' \nD = '%0'\n",C,D),
   writef("char: %c, decimal: %d, hex: %x, unsigned: %u", 97,'a',33,-1).