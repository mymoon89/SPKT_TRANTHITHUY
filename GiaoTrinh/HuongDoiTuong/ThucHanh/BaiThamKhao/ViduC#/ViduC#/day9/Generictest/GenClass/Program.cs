using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenClass
{
public class Couple<T, E>
    {
        public T elementA;
        public E elementB;
        public Couple(T inA, E inB)
        {
            elementA = inA;
            elementB = inB;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Couple<string, int> couple = new Couple<string, int>("ID number ", 01121);
            Couple<int, int> address = new Couple<int, int>(123,42323);
            Couple<int ,string > name = new Couple<int , string >(232, "Victor");
        }
    }
}
