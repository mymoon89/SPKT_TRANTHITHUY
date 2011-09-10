using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaiTap_9_ArrayList
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create MyArrayList
            MyArrayList myAL = new MyArrayList();            

            //Print array list
            Console.Write("Values of my array list are:\t");
            myAL.Print();

            //Count of array list
            Console.WriteLine("Count of array list is: " + myAL.MyAL.Count);

            //Capacity of array list
            Console.WriteLine("Capacity of array list is: " + myAL.MyAL.Capacity);

            //Answer the question
            Console.WriteLine("Khong the thiet lap gia tri cua Capacity nho hon Count");

            //Stop monitor
            Console.ReadLine();

        }
    }
}
