using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReWritePoint
{
    // Circle2 class definition inherits from Point
    class Circle2 : Point
    {
      private double radius; // Circle2's radius
      // constructor
      public Circle2(int xValue, int yValue, double radiusValue)
      {
         x = xValue;
         y = yValue;
         Radius = radiusValue;
      }
    // property Radius
      public double Radius
      {
         get
         {
            return radius;
         }

                  set
         {
            if ( value >= 0 )
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
      public virtual double area()
      {
         return Math.PI * Math.Pow( radius, 2 );
      }
   
      // return string representation Circle
      public override string ToString()
      {
         return "Center = [" + x + ", " + y + "]" +
            "; Radius = " + radius;
      }
   
   }
}
