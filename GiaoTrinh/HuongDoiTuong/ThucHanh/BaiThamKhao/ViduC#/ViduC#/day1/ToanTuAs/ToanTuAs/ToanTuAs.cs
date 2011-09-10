
using System;
class Sv
{
}
class ToanTuAs
{
    static void Main()
    {
        object[] SvAr = new object[4];
        SvAr[0] = new Sv();
        SvAr[1] = "la chuoi";
        SvAr[2] = 123;
        SvAr[3] = null;

        for (int i = 0; i < SvAr.Length; ++i)
        {
            string s = SvAr[i] as string;
            Console.Write("{0}:", i);
            if (s != null)
            {
                Console.WriteLine("'" + s + "'");
                
            }
            else
            {
                Console.WriteLine(" khong la string");
            }
            Console.ReadLine();
        }
    }
}
