using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace test11234
{
    class Box
    {
         
            private string[] names = { "length", "width", "height" };
            private double[] dimensions = new double[3];

            // constructor
            public Box(double length, double width, double height)
            {
                dimensions[0] = length;
                dimensions[1] = width;
                dimensions[2] = height;
            }

            // access dimensions by index number
            public double this[int index]
            {
                get
                {
                    return (index < 0 || index > dimensions.Length) ? -1 : dimensions[index];
                }
                set
                {
                    if (index >= 0 && index < dimensions.Length)
                        dimensions[index] = value;
                }

            } // end numeric indexer

            // access dimensions by their names
            public double this[string name]
            {
                get
                {
                    // locate element to get
                    int i = 0;

                    while (i < names.Length &&
                           name.ToLower() != names[i])
                        i++;

                    return (i == names.Length) ? -1 : dimensions[i];
                }

                set
                {
                    // locate element to set
                    int i = 0;

                    while (i < names.Length &&
                           name.ToLower() != names[i])
                        i++;
                    if (i != names.Length)
                        dimensions[i] = value;
                }

            }

        }
     
}
