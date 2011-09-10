/*
   Turbo Prolog 2.0 Chapter 17, Example Program 5
   
   Copyright (c) 1986, 88 by Borland International, Inc
   
*/
constants
% To access your BGI drivers and fonts bgi_path may need to equal "..\\BGI".
   bgi_path = ""

% To access the GRAPDECL.PRO file you may need to add a path: 
% include "..\\programs\\GRAPDECL.PRO" 
include "GRAPDECL.PRO" 

goal
   initgraph(detect,0,GraphDriver,GraphMode,bgi_path),
   Title = "Font Example",
   setTextJustify(center_Text,center_Text),
   setUserCharSize(1,1,1,1),
   setTextStyle(triplex_Font,horiz_Dir, user_Char_Size),
   textWidth(Title,Width), textHeight(Title,Hight),
   setUserCharSize(200,Width,100,Hight),
   setTextStyle(triplex_Font,horiz_Dir, user_Char_Size),
   rectangle(0,0,200,100),
   outtextxy(100,48,Title),

   setUserCharSize(300,Width,100,Hight),
   setTextStyle(gothic_Font,horiz_Dir, user_Char_Size),
   rectangle(220,0,520,100),
   outtextxy(370,48,Title),

   /*  Vertical Sans-Serif Font */
   setUserCharSize(200,Width,150,Hight),
   setTextStyle(sans_Serif_Font,vert_Dir, user_Char_Size),
   rectangle(100,110,240,300),
   outtextxy(150,200,Title),

   setTextJustify(left_Text,center_Text),
   setTextStyle(small_Font,horiz_Dir, 1),
   outtextxy(380,200,"Press Key to exit"),

   setTextJustify(right_Text,center_Text),
   setTextStyle(small_Font,horiz_Dir, 4),
   outtextxy(380,208,"Press Key to exit"),

   setTextJustify(left_Text,center_Text),
   setTextStyle(small_Font,horiz_Dir, 6),
   outtextxy(380,220,"Press Key to exit"),

   setTextJustify(center_Text,center_Text),
   setTextStyle(default_Font,horiz_Dir, 2),
   outtextxy(380,240,"Press Key to exit"),

   readchar(_),
   closegraph.
