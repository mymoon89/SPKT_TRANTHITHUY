/*
   Turbo Prolog 2.0 Chapter 16, Example Program 1
   
   Copyright (c) 1986, 88 by Borland International, Inc
   
*/
   
goal
   makewindow(1,7,7,"Source",0,0,20,35),
   write("Which file do you want to copy ?"),
   cursor(3,8),readln(X),
   makewindow(2,7,7,"Destination",0,40,20,35),
   write("What is the name of the new copy ?"),
   cursor(3,8),readln(Y),
   concat(X," ",X1),concat(X1,Y,Z),
   concat("copy ",Z,W), /* creates the string W */
   makewindow(3,7,7,"Process",14,15,8,50),
   write(" Copying ",X," to ",Y),cursor(2,3),
   system(W). /* invokes DOS with the string W */
