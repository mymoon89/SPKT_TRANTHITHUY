using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ListBoxCollection911
{
    class Program
    {
        static void Main(string[] args)
        {
            ListBoxTest lbt = new ListBoxTest("Hello", "World");
lbt.Add("A");
lbt.Add("B");
lbt.Add("C");
lbt.Add("D");
lbt.Add("E");
string subst = "Them 1 thanh phan vao";
lbt[1] = subst;
// truy cập tất cả các chuỗi
int count =1;
            // foreach tu dong duyệt Đối tượng s trong collector
foreach (string s in lbt)
{
    Console.WriteLine("Value {0}: {1}", count, s);
    count++;
}
        }
    }
}
