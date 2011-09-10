using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace car
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Delegates as event enablers *****\n");
            // Make a car as usual.
            Car c1 = new Car("SlugBug", 100, 10);
            // Register event handlers with Car type.
            c1.OnAboutToBlow(new Car.AboutToBlow(CarAboutToBlow));
            c1.OnExploded(new Car.Exploded(CarExploded));
            
            //update Multicasting
           c1.OnAboutToBlow(new Car.AboutToBlow(CarIsAlmostDoomed));

            // Speed up (this will trigger the events).
            Console.WriteLine("***** Speeding up *****");
            for (int i = 0; i < 6; i++)
                c1.Accelerate(20);
            Console.ReadLine();
        }
        // The Car will call these methods.
   /*     
public static void CarAboutToBlow(string msg)
{ Console.WriteLine(msg); }

public static void CarExploded(string msg)
{ Console.WriteLine(msg); }
 */
        //update MultiCasting
        
         public static void CarAboutToBlow(string msg)
      { Console.WriteLine(msg); }  
        public static void CarIsAlmostDoomed(string msg)
        { Console.WriteLine("Critical Message from Car: {0}", msg); }
        public static void CarExploded(string msg)
      { Console.WriteLine(msg); } 
         

    }
}