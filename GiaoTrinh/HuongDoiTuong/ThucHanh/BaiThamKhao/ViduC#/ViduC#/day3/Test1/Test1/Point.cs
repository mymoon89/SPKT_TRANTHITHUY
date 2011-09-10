using System;
namespace Test1
{
    // Point class definition implicitly inherits from Object (System.Object)
    public class Point
    {
        // point coordinates
        private int x, y;

        // default (no-argument) constructor
        public Point()
        {
            // implicit call to Object constructor occurs here
        }

        // constructor
        public Point(int xValue, int yValue)
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