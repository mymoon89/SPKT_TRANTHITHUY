/*
   Turbo Prolog 2.0 Chapter 17, Example Program 6
   
   Copyright (c) 1986, 88 by Borland International, Inc
   
*/
constants
% To access your BGI drivers and fonts bgi_path may need to equal "..\\BGI".
   bgi_path = ""

% To access the GRAPDECL.PRO file you may need to add a path: 
% include "..\\programs\\GRAPDECL.PRO" 
include "GRAPDECL.PRO" 

predicates
   makeViewPort

goal
   initGraph(detect, 0, New_Driver, New_Mode, bgi_path),
   makeViewPort,
   closegraph().

clauses
   makeViewPort:-
      detectGraph(_, G_Mode),
      getMaxX(MaxX),getMaxY(MaxY),
      setViewPort(0,0,MaxX,MaxY,1),
      clearViewPort,
      writef("Default Mode is % , resolution is % by %",
              G_Mode,MaxX,MaxY),nl,
      write("Press key"),readchar(_),nl,fail.

   makeViewPort:-
      detectGraph(G_Driver, _),
      getModeRange(G_Driver,Low,_),
      setGraphMode(Low),
      getMaxX(MaxX),getMaxY(MaxY),
      setViewPort(0,0,MaxX,MaxY,1),
      clearViewPort,
      writef("Default Mode is % , resolution is % by %",
              Low,MaxX,MaxY),nl,
      write("Press key"),readchar(_), nl, fail.
