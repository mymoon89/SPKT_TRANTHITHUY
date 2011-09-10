using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IEnumeratorTest
{
    class EntryPoint
    {
        static void Main(string[] args)
        {
            Container con = new Container("Vi du", "cua Enumerator");
            con.Add("them 1");
            con.Add("them 2");
            con.Add("them 3");
            // co the thay doi gia tri chuoi nhu sau
            string change = "vi tri bi thay doi";
            con[1]=change;
            foreach (string s in con)
            {
                Console.WriteLine(" Chuoi :{0}", s);

            }
        }
    }
}
