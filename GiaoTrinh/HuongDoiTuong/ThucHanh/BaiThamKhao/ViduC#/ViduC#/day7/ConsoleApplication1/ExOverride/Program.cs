using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExOverride
{
    class Program
    {
        static void Main(string[] args)
        {
            Document note = new Note("Trien khai Note");
            
            IStore isNote = note as IStore;
            isNote.Read();
            isNote.Write();
            Console.WriteLine("\n");
            // goi truc tiep
            note.Read();
            note.Write();
            Console.WriteLine("\n");
            // su dung doi tuong Note
            Note note1 = new Note("Trien khai Note2");
            IStore isNote1 = note1 as IStore;
            isNote1.Read();
            isNote1.Write();
            // goi truc tiep
            note1.Read();
            note1.Write();
        }
    }
}
