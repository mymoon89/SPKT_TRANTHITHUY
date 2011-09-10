using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab53
{
    class Client
    {
        static void Main(string[] args)
        {
            IEHuman h,h1;
            Theodore t;
            
            h1 = new Kirsd();
            h1.Name = "Kirst";
            h1.Speak(h1.Name);
          
            h = new Theodore();
            //cast for assignement 
            t = (Theodore)h;
            //use class based reference 
            t.Name = "Fred";
            t.Speak("I like public implementations!");
            //use interface reference 
            h.Name = "Teddy";
            h.Speak("I like VB!"); 

        }
    }
}
