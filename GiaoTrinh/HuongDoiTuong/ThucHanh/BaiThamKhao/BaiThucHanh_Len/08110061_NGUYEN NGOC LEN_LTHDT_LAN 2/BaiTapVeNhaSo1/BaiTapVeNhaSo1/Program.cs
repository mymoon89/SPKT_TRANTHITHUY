using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaiTapVeNhaSo1
{
    class Program
    {
        class SoPhuc
        {
            private int _Thuc;
            private int _Ao;
            public int PhanThuc
            {
                get 
                {
                    return _Thuc;
                }
                set 
                {
                    _Thuc = value;
                }
            }
            public int PhanAo
            {
                get
                {
                    return _Ao;
                }
                set
                {
                    _Ao = value;
                }
            }
            public void InSoPhucScreen()
            {
                Console.WriteLine(".:.So phuc can tim  la : {0} + {1}i",PhanThuc,PhanAo);
            }
            public SoPhuc Cong(SoPhuc a, SoPhuc b)
            {
                SoPhuc c = new SoPhuc();
                c._Thuc = a._Thuc + b._Thuc;
                c._Ao = a._Ao + b._Ao;
                return c;
            }
            public  SoPhuc Tru(SoPhuc a, SoPhuc b)
            {
                SoPhuc c = new SoPhuc();
                c._Thuc = a._Thuc - b._Thuc;
                c._Ao = a._Ao - b._Ao;
                return c;
            }
        }
        static void Main(string[] args)
        {
            SoPhuc sp1 = new SoPhuc();
            sp1.PhanThuc = 5;
            sp1.PhanAo   = 10;
            Console.WriteLine(".:.So phuc thu nhat la : {0} + {1}i",sp1.PhanThuc,sp1.PhanAo);
            SoPhuc sp2 = new SoPhuc();
            sp2.PhanThuc = 3;
            sp2.PhanAo = 5;
            Console.WriteLine(".:.So phuc thu hai  la : {0} + {1}i", sp2.PhanThuc, sp2.PhanAo);
            SoPhuc sp3 = new SoPhuc();
            sp3.Cong(sp1, sp2);
            sp3.InSoPhucScreen();
         
            
        }
    }
}
