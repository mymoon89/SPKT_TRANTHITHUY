using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Question_1_Triangle
{
    class Triangle
    {
        #region Triangle properties
        private float _SideA;
        private float _SideB;
        private float _SideC;

        public float SideA
        {
            get { return _SideA; }
            set { _SideA = value; }
        }

        public float SideB
        {
            get { return _SideB; }
            set { _SideB = value; }
        }

        public float SideC
        {
            get { return _SideC; }
            set { _SideC = value; }
        }
        #endregion

        #region 1.a.1: Create triangle non parameter
        public Triangle() { }
        #endregion

        #region 1.a.2: Create triangle have 3 parameter
        public Triangle(float a, float b, float c)
        {
            this.SideA = a;
            this.SideB = b;
            this.SideC = c;

        }
        #endregion

        #region 1.b.1: Input triangle from keyboard
        public Triangle InputTriangle()
        {
            try
            {
                Console.WriteLine("Please input triangle: ");
                Console.Write("\tInput side a: ");
                this.SideA = float.Parse(Console.ReadLine());
                Console.Write("\tInput side b: ");
                this.SideB = float.Parse(Console.ReadLine());
                Console.Write("\tInput side c: ");
                this.SideC = float.Parse(Console.ReadLine());

                return this;

            }
            catch (FormatException fEx)
            {
                Console.WriteLine("Error: " + fEx.Message);
            }

            return null;
        }
        #endregion

        #region 1.b.2: Get perimeter of triangle
        public float getPerimeter()
        {
            if (this.checkTriangle())
                return this.SideA + this.SideB + this.SideC;

            return 0;

        }
        #endregion

        #region 1.b.3: Get area of triangle
        public float getArea()
        {
            if (this.checkTriangle())
            {
                double haftPerimeter = (this.getPerimeter()) / 2;
                return float.Parse(Math.Sqrt(haftPerimeter * (haftPerimeter - this.SideA) * (haftPerimeter - this.SideB) * (haftPerimeter - this.SideC)).ToString());
            }
            return 0;

        }
        #endregion

        #region 1.c: Check triangle is exist
        public bool checkTriangle()
        {
            if (((this.SideA + this.SideB) > this.SideC) && ((this.SideA + this.SideC) > this.SideB) && ((this.SideB + this.SideC) > this.SideA))
                return true;
            return false;
        }
        #endregion

        #region 1.d: Get type of triangle
        public string getTypeOfTriangle()
        {
            if (checkTriangle())
            {
                if (checkEquilateral())
                    return "The triangle is euilateral.";
                else if (checkSquareAndIsosceles())
                    return "The triangle is square and isosceles.";                                
                else if (checkSquare())
                    return "The triangle is square.";
                else if (checkIsosceles())
                    return "The triangle is isosceles.";
                else
                    return "The triangle is normal.";

            }
            else
                return "The triangle is non exist";
        }
        #endregion

        #region Check Isosceles triangle
        public bool checkIsosceles()
        {
            if (this.SideA == this.SideB || this.SideA == this.SideC || this.SideB == this.SideC)
                return true;
            return false;
        }
        #endregion

        #region Check square of triangle
        public bool checkSquare()
        {
            if (this.SideA * this.SideA + this.SideB * this.SideB == this.SideC * this.SideC ||
                this.SideA * this.SideA + this.SideC * this.SideC == this.SideB * this.SideB ||
                this.SideB * this.SideB + this.SideC * this.SideC == this.SideA * this.SideA)
                return true;
            return false;

        }
        #endregion

        #region Check square and isosceles of triangle
        public bool checkSquareAndIsosceles()
        {
            if (this.checkIsosceles() && this.checkSquare())
                return true;

            return false;
        }
        #endregion

        #region Check Equilateral of triangle
        public bool checkEquilateral()
        {
            if (this.SideA == this.SideB && this.SideA == this.SideC)
                return true;

            return false;
        }
        #endregion

    }
}
