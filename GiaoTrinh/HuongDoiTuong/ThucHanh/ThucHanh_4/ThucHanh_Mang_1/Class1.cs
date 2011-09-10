using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Array121
{
    public class Class1
    {
        public int sortint(int i, int j)
        {
            if (i > j)
                return -1;
            else if (i == j)
                return 0;
            return 1;
        }
    }
}
