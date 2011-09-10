using System;
    using System.Windows.Forms;
namespace Test1
{
    // PointTest class definition
    class PointTest
    {
        // main entry point for application
        static void Main(string[] args)
        {
            // instantiate Point object
            Point point = new Point(72, 115);

            // display point coordinates via X and Y properties
            string output = "X coordinate is " + point.X +
               "\n" + "Y coordinate is " + point.Y;

            point.X = 10; // set x-coordinate via X property
            point.Y = 10; // set y-coordinate via Y property

            // display new point value
            output += "\n\nThe new location of point is " + point;

            MessageBox.Show(output, "Demonstrating Class Point");

        } // end method Main

    } // end class PointTest
}