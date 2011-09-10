using System;
using System.Collections.Generic;
using System.Text;

namespace ViduSGK
{
    public class ListBox : Window
    {
        private string mListBoxContents;
    
        public ListBox(int top, int left, string  theContents) 
        {
           // this.top = top;
           // this.left = left;
            mListBoxContents = theContents;
        }

        public override void DrawWindow()
        {
             
            Console.WriteLine("ListBox write: {0}", mListBoxContents);
        }
    }
}
