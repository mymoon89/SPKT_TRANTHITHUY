using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace lab2Circle
{
    class CircleTest
   {
      // main entry point for application.
      static void Main( string[] args )
      {
         // instantiate Circle
         Circle circle = new Circle( 37, 43, 2.5 );
   
         // get Circle's initial x-y coordinates and radius
         string output = "X coordinate is " + circle.X + 
            "\nY coordinate is " + circle.Y + "\nRadius is " +
            circle.Radius;
   
         // set Circle's x-y coordinates and radius to new values
         circle.X = 2;
         circle.Y = 2;
         circle.Radius = 4.25;
   
         // display Circle's string representation
         output += "\n\nThe new location and radius of " +
            "circle are \n" + circle + "\n";
   
         // display Circle's diameter
         output += "Diameter is " +
            String.Format( "{0:F}", circle.Diameter() ) + "\n";
                   // display Circle's circumference
         output += "Circumference is " +
            String.Format( "{0:F}", circle.Circumference() ) + "\n";
   
         // display Circle's area
         output += "Area is " + 
            String.Format( "{0:F}", circle.Area() );
   
         MessageBox.Show( output, "Demonstrating Class Circle" );
   
      } // end method Main
   
   } // end class CircleTest

}
