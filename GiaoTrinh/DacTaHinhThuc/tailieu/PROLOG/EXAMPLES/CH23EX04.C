/*
   Turbo Prolog 2.0 Reference Guide Chapter 3, Example Program 4
   
   Copyright (c) 1986, 88 by Borland International, Inc
   
*/
   
extprog()
{
   char dummychar; 
   char *Name;

   makewindow(1,7,7,"Hello there",5,5,15,60);
   write_string("\n\nIsn't it easy");
   readchar(&dummychar);
   write_string("\nEnter your name: ");
   readline(&Name);
   write_string("\nYour name is: ");
   write_string(Name);
   readchar(&dummychar);
   removewindow();
}
