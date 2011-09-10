using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleExample
{
    public delegate int BinaryOp(int x, int y);
    // This class contains methods BinaryOp //will
    // point to.
    public class SimpleMath
    {
        public  static  int Add(int x, int y)
        { return x + y; }
        public static int Subtract(int x, int y)
        { return x - y; }
        public static int SquareNumber(int a,int b)
        {       return a *b  ; 
        }
}    
class Program
	{
static void Main(string[ ] args)
{
Console.WriteLine("***** Simple Delegate Example *****\n");
// Create a BinaryOp object that
// "points to" SimpleMath.Add().
//SimpleMath s = new SimpleMath();
//BinaryOp b = new BinaryOp(s.Add);
BinaryOp b = new BinaryOp(SimpleMath.Add);
// Invoke Add() method indirectly using //delegate object.
Console.WriteLine("10 + 10 is {0}", b(10, 10));
BinaryOp b2 = new BinaryOp(SimpleMath.SquareNumber);

Console.ReadLine();
}
} 
}
