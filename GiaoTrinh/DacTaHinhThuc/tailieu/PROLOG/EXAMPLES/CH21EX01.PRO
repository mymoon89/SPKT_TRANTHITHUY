/*
   Turbo Prolog 2.0 Chapter 21, Example Program 1
   
   Copyright (c) 1986, 88 by Borland International, Inc
   
*/
ifdef menubased

include "\\tools\\status.pro"
include "\\tools\\pulldown.pro"

consts
  menubased = 1   

clauses
  pdwaction(1,0):-
	shiftwindow(OLD),shiftwindow(1),NOHINGE
%     .... etc ....

goal
  makestatus(112," Select with arrows or use first uppercase letter"),
  pulldown(66,
	  [ curtain("Generate C types",[]),
	    curtain("View generated",[]),
	    curtain("Edit",[]),
	    curtain("Files",["Load","Save","Dir"]),
         curtain("Quit"      ,[])
          ],_,_).

elsedef
goal
   comline(L),
   extendFilename(L,"PRO",FILENAME),
   newExt(FILENAME,"C",OUTPUTFILE),
   file_str(FILENAME,SOURCE),
   change(source(SOURCE)),
   process(OUTPUTFILE).

