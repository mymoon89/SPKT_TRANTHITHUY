/*
   Turbo Prolog 2.0 Chapter 5, Example Program 10
   
   Copyright (c) 1986, 88 by Borland International, Inc
   
*/
   
domains
   name = symbol
   gpa  = real

predicates
   honor_student(name)
   student(name, gpa)
   probation(name)

clauses
   honor_student(Name):- 
      student(Name, GPA),
      GPA>=3.5,
      not(probation(Name)).

   student("Betty Blue", 3.5).
   student("David Smith", 2.0).
   student("John Johnson", 3.7).
   probation("Betty Blue").
   probation("David Smith").
