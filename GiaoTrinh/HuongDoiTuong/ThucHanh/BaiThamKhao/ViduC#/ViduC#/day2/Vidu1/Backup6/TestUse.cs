// cs_using_directive2.cs
// Using directive.
using System;
// Using alias cho A va TestUse
using SinhVien = A.TestUse;

namespace A
{
    public class TestUse
    {
        
        public void  dis()
        {
            Console.WriteLine( "Khu vuc cua A, lop TestUse");
        }
    }
}

namespace B
{
    class TestUse
    {
        public static void dis() 
        { Console.WriteLine("Khu vuc B"); 
        }
    }
}

namespace C
{
    // Using directive:
   // using A;
    using B;

    class MainClass
    {
        static void Main()
        {
            SinhVien timKiem = new SinhVien();
            //Khi co A
            B.TestUse.dis();
     // Khi bo di A
        TestUse.dis();
            timKiem.dis();
        }
    }
}
