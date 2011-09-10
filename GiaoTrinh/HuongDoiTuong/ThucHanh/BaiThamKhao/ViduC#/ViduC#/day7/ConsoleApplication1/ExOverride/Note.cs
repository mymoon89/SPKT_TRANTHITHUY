using System;
using System.Collections.Generic;
using System.Text;

namespace ExOverride
{
    public class Note : Document
    {
        public Note(string s): base(s)
        {
            Console.WriteLine("Tao class Note {0}",s);
        }

        public override void Read()
        {
            Console.WriteLine("ham Read bi override cho Note");
        }

        public void Write()
        {
            Console.WriteLine("ham Write cua Note");
        }
    }
}
