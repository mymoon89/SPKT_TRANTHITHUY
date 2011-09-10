using System;
using System.Collections.Generic;
using System.Text;

namespace FancyComboBox2
{
    public class FancyComboBox : ComboBox, IUIControl
    {
         public  override  void Paint()
        {
            Console.WriteLine("FancyComboBox.Paint()");
        }  

    }
}
