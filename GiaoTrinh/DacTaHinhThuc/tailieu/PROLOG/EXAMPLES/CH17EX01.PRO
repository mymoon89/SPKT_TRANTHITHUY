/*
   Turbo Prolog 2.0 Chapter 17, Example Program 1
   
   Copyright (c) 1986, 88 by Borland International, Inc
   
*/
constants
% To access your BGI drivers and fonts bgi_path may need to equal "..\\BGI".
   bgi_path = ""


% To access the GRAPDECL.PRO file you may need to add a path: 
% include "..\\programs\\GRAPDECL.PRO" 
include "GRAPDECL.PRO" 

predicates
   toText
   tempTextmode
   toGraphic

goal
   toGraphic,
   tempTextmode,
   toText.

clauses
   toGraphic:-
      % Detect graphics hardware
      detectGraph(G_Driver, G_Mode),
      initGraph(G_Driver,G_Mode, New_Driver,New_Mode, bgi_path),
      write("A look into the BGI"),nl,
      writef("Graph_Driver = %, Graph_Mode = %",G_Driver,G_Mode),nl,
      writef("Newe_Driver = %, New_Mode = %",New_Driver,New_Mode),nl,	
      write("Press key to return:"),
      readchar(_).

  TempTextmode:-
      getGraphMode(GraphMode),
      restoreCRTMode,
      write("\nNow you are in text mode.\n\n"),
      write("\nPress any key to go back to graphics ..."),
      readchar(_),
      setGraphMode(GraphMode).

   ToText:-
      closegraph().
