/*
   Turbo Prolog 2.0 Chapter 17, Example Program 2
   
   Copyright (c) 1986, 88 by Borland International, Inc
   
*/


constants
% To access your BGI drivers and fonts bgi_path may need to equal "..\\BGI".
   bgi_path = ""

% To access the GRAPDECL.PRO file you may need to add a path: 
% include "..\\programs\\GRAPDECL.PRO" 
include "GRAPDECL.PRO" 

goal
   initgraph(detect, 0, GraphDriver,GraphMode, bgi_path),

   /* Draw a 90 degree arc with radius of 50 */
   arc(150, 150, 0, 89, 50),

   /* Get the coordinates of the arc and connect ends */
   getarccoords(X,Y,XStart,YStart,XEnd,YEnd),
   line(XStart, YStart, XEnd, YEnd),

   /* Draw a circle */
   circle(150, 150, 100),

   /* Draw an ellipse inside the circle */
   ellipse(150, 150, 0, 359, 100, 50),

   /* Draw and fill a pieslice */
   pieslice(100, 100, 0, 135, 49),
   pieslice(100, 100, 135, 225, 49),
   pieslice(100, 100, 225, 360, 49),

   closegraph.