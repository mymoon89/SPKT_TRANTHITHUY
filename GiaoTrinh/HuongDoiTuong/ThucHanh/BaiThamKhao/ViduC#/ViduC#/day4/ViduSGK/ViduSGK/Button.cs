using System;
using System.Collections.Generic;
using System.Text;

namespace ViduSGK
{
    public class Button : Window
    {
        
        public Button(int top, int left) 
        {
              
        }

        public override  void DrawWindow()
        {
             Console.WriteLine(" Drawing a button at {0}: {1}", top , left );
        }
    }
}
