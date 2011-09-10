using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace lab1Point
{
    public  class Point
    { 
             private   int x, y;
   
      // default (no-argument) constructor

              public Point() { }
      // constructor
      public Point( int xValue, int yValue )
      {
         // implicit call to Object constructor occurs here
         X = xValue;
         Y = yValue;
      }
   
      // property X
      public int X
      {
         get
         {
            return x;
         }
            set
         {
            x = value; // no need for validation
         }
   
      } // end property X
   
      // property Y
      public int Y
      {
         get
         {
            return y;
         }
         
         set
         {
            y = value; // no need for validation
         }
   
      } // end property Y
   
      // return string representation of Point
      public override string ToString()
      {
         return "[" + x + ", " + y + "]";
      }
   
   } // end class Point

      }

    
