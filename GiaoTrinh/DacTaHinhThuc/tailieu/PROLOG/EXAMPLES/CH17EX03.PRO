/*
   Turbo Prolog 2.0 Chapter 17, Example Program 3
   
   Copyright (c) 1986, 88 by Borland International, Inc
   
*/


constants
% To access your BGI drivers and fonts bgi_path may need to equal "..\\BGI".
   bgi_path = ""

% To access the GRAPDECL.PRO file you may need to add a path: 
% include "..\\programs\\GRAPDECL.PRO" 
include "GRAPDECL.PRO" 

goal
   initgraph(detect, 0, GraphDriver, GraphMode, bgi_path),
   rectangle(0, 0, 100, 100),
   bar3d(100, 10, 200, 100, 5, 1),
   bar(30, 30, 80, 80),
   drawpoly([50, 100, 100, 100, 150, 150, 50, 100]),
   fillpoly([50, 10, 90, 50, 50, 90, 10, 50]),
   readchar(_),
   closegraph.
