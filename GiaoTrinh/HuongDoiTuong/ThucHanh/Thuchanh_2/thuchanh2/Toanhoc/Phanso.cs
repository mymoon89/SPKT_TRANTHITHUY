using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Toanhoc
{
    public class Phanso
    {
        public int tuso;
        public int mauso;
        public void Xuat()
        {
            Console.WriteLine("{0}/{1}", tuso, mauso);
        }
        public Phanso(int tu)
        {
            tuso = tu;
            mauso = 1;
        }
        public Phanso(int t, int m)
        {
            tuso=t;
            mauso=m;
        }

    }
}
