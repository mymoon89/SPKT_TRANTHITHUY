using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Question_1_Triangle
{
    class Test
    {
        static void Main(string[] args)
        {
            //Create triangle
            Triangle triangle = new Triangle();

            //Input triangle
            triangle.InputTriangle();

            //Get perimeter of triangle
            Console.WriteLine("Perimeter of triangle is: " + triangle.getPerimeter());

            //Get area of triangle
            Console.WriteLine("Area of triangle is: " + triangle.getArea());

            //Get type of triangle
            Console.WriteLine(triangle.getTypeOfTriangle());

            //Stop moniter
            Console.ReadLine();

        }
    }
}
