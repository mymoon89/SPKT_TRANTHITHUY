using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1
{
    public class Customer
    {
       public   string Name;
        public string City;
       public string name {
            get
            {
                return Name;
            }
            set
            {
                Name = value;
            }
        }
        public override string ToString()
        {
            return Name + "\t" + City;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Customer c = new Customer();
            c.Name = "Maria Anders";
            c.City = "Berlin";
            Console.WriteLine(c);

        }
    }
}
