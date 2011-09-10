using System;
using System.Collections.Generic;
using System.Text;

namespace viduP254
{
    public class ListBox : Window
    {
        private string mListBoxContent;

        public ListBox(int top, int left, string theContent):base( top, left)
        {
            mListBoxContent = theContent;
        }

        public override void DrawWindow()
        {
           // base.DrawWindow();
            Console.WriteLine(" ListBox write: {0}", mListBoxContent);
             
        }
    }
}
