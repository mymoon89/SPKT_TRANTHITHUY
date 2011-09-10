using System;
using System.Collections.Generic;
using System.Text;

namespace viduP254
{
    public class Button : Window
    {
        public Button(int top, int left):base(top,left )
        {
             
      }

        public override  void DrawWindow()
        {
            Console.WriteLine(" Drawing a button at {0}: {1}", top, left);
        }
    }
}
