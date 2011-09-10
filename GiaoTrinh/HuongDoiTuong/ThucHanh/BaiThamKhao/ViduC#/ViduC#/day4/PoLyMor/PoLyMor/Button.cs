using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PoLyMor
{
  public  class Button:Window
    {
        //hàm Constructor
        public Button(int top, int left) : base(top,left) 
        { }
        // đa hình 
        public override void DrawWindow()
        {
            base.DrawWindow();
            Console.WriteLine("ve lai button");
        }
        
    }
}
