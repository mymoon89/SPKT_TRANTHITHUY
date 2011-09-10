using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ReWritePoint
{      // PointTest class definition
    class PointTest
    {
        // main entry point for application
        static void Main(string[] args)
        {
            // instantiate Point object
            Point point = new Point(72, 115);
            Circle2 cicle = new Circle2(10, 20, 30);
          

            // display point coordinates via X and Y properties
            string output = "X coordinate is " + point.X +
               "\n" + "Y coordinate is " + point.Y;
            

            point.X = 10; // set x-coordinate via X property
            point.Y = 10; // set y-coordinate via Y property
           
            // display new point value
            output += "\n\nThe new location of point is " + point;
            output += "\n\nThe new location of point is " + cicle;
            MessageBox.Show(output, "Demonstrating Class Point");

        } // end method Main

    } // end class PointTest
}

