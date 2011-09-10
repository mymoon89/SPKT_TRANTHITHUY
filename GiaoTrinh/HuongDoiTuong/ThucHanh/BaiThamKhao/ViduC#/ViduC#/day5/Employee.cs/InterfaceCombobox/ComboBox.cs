using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceCombobox
{
    public class ComboBox : IDropList, IEditBox
    {
         public  void Paint()
        {
            Console.WriteLine("ComboBox.IEditBox.Paint()");

        }
    }
}
