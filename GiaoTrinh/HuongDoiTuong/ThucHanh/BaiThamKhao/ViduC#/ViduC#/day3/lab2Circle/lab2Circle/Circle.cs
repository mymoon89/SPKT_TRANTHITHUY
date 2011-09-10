using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace lab2Circle
{
    public class Circle
    {
       private int x, y;      // coordinates of Circle's center
      private double radius; // Circle's radius
   
      // default constructor
      public Circle()
      {
         // implicit call to Object constructor occurs here
      }
   
      // constructor
      public Circle( int xValue, int yValue, double radiusValue )
      {
         // implicit call to Object constructor occurs here
         x = xValue;
         y = yValue;
         Radius = radiusValue;
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
            x = value;  // no need for validation
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
            y = value;  // no need for validation
         }
   
      } // end property Y
   
      // property Radius
      public double Radius
      {
         get
         {
            return radius;
         }
   
         set
         {
            if ( value >= 0 )   // validation needed
               radius = value;
         }
               } // end property Radius
   
      // calculate Circle diameter
      public double Diameter()
      {
         return radius * 2;
      }
   
      // calculate Circle circumference
      public double Circumference()
      {
         return Math.PI * Diameter();
      }
   
      // calculate Circle area
      public double Area()
      {
         return Math.PI * Math.Pow( radius, 2 );
      }
   
      // return string representation of Circle
      public override string ToString()
      {
         return "Center = [" + x + ", " + y + "]" +
            "; Radius = " + radius;
      }
      }
}
