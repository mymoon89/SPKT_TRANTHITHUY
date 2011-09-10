using System;
using System.Collections.Generic;
using System.Text;

namespace StructExample
{
    public struct Location : Coordianate
    {
        public Location(int xCoordinate, int yCoordinate)
        {
            xVal = xCoordinate;
            yVal = yCoordinate;
        }
        public int x
        {
            get
            { return xVal;
            }
            set
            { xVal = value;
            }
        }
        public int y
        {
            get
            {
                return yVal;
            }
            set
            {
                yVal = value;
            }
        }
        public override string ToString()
        {
        return (String.Format("{0}, {1}", xVal, yVal));
        }
// thuộc tính private lưu toạ độ x, y
        private int xVal;
        private int yVal;

        #region Coordianate Members

        public void TraceLocation()
        {
            Console.WriteLine("Inheritance trong Struct");
        }

        #endregion
    }
}
