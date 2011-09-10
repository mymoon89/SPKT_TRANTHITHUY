/*
   Turbo Prolog 2.0 Chapter 17, Example Program 4
   
   Copyright (c) 1986, 88 by Borland International, Inc
   
*/

constants
% To access your BGI drivers and fonts bgi_path may need to equal "..\\BGI".
   bgi_path = ""
   gray50 = [$aa, $55, $aa, $55, $aa, $55, $aa, $55 ]

% To access the GRAPDECL.PRO file you may need to add a path: 
% include "..\\programs\\GRAPDECL.PRO" 
include "GRAPDECL.PRO" 

goal
   initgraph(0, 0, GraphDriver, GraphMode, bgi_path),

   getfillsettings(SavePat,SaveColor), 		/* retrieve current settings */
   getfillpattern(SavePatternList), 		/* save user fill pattern */
   setfillstyle(slash_FILL, blue), 		/* change fill style */
   bar(0, 0, 100, 100), 			/* draw slash-filled blue bar */
   setfillpattern(gray50, yellow), 		/* custom fill pattern */
   bar(100, 100, 200, 200), 			/* draw customized yellow bar */
   setfillpattern(SavePatternList,SaveColor),	/* restore user fill pattern */
   setfillstyle(SavePat, SaveColor),
   readchar(_),
   closegraph.
