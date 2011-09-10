using System;
using System.Collections.Generic;
using System.Text;

namespace PropertiesTest
{
    public class Test
    {
        // bien thanh vien,kieu private
        private int x;
        private int y;
        //ham hanh su
        public  void disPlay()
        {
            Console.WriteLine("x= {0} , y ={1}", x, y);
        }
        // ham constructor
        public Test(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        // properties
        public int X  
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }
        }
        public int Y
        {
            get { return y; }
            set { y = value; }
        }
    }

    public class Program
    {
     public   static void Main(string[] args)
        {
           
            Test t = new Test(3,5);
            t.disPlay();
            
          //  get duoc goi
            int xX = t.X;
            int yY = t.Y;
            Console.WriteLine(" lay gia tri cua X tu get: {0}", xX);
            // set duoc su dung
            xX++;
            t.X = xX;
            Console.WriteLine("cap nhat gia tri x: {0}", xX);
        }
    }
}
