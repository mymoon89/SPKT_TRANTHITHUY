using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ViduSGK
{
    class Program
    {
        static void Main(string[] args)
        { 
           // Window win = new Window(1,2);
            ListBox lb = new ListBox( 3, 4, "Stand alone list box");
            Button b = new Button( 5, 6 );
           // win.DrawWindow();
            lb.DrawWindow();
           b.DrawWindow();
            
        }
    }
}
