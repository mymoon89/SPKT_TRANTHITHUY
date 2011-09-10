using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StructExample
{
    class Program
    {
         
             public void myFunc( Location loc)
        {
        loc.x = 50;
        loc.y = 100;
        Console.WriteLine("Loc1 location: {0}", loc);
        } 
            static void Main()
{
            Location loc1 = new Location( 200, 300);
            Console.WriteLine("Loc1 location: {0}", loc1);
            Program  t = new Program ();
            t.myFunc( loc1 );
            Console.WriteLine("Loc1 location: {0}", loc1);  
               
               
}
        }
    }
 
