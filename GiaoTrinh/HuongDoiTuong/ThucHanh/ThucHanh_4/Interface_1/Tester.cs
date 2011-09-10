using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interface_08110121
{
    public class Tester
    {
        static void Main()
        {
            //Phu quyet

            // tạo một đối tượng Document
            Document theNote = new Note("Test Note");
            IStoreable isNote = theNote as IStoreable;
            if (isNote != null)
            {
                isNote.Read();
                isNote.Write();
            }
            Console.WriteLine("\n");

            // trực tiếp gọi phương thức 
            theNote.Read();
            theNote.Write();
            Console.WriteLine("\n");

            // tạo đối tượng Note
            Note note2 = new Note("Second Test");
            IStoreable isNote2 = note2 as IStoreable;
            if (isNote != null)
            {
                isNote2.Read();
                isNote2.Write();
            }
            Console.WriteLine("\n");

            // trực tiếp gọi phương thức 
            note2.Read();
            note2.Write();

            /*
            // tạo đối tượng document
            Document doc = new Document("Test Document");

            // gán đối tượng cho giao diện 
            IStoreable isDoc = doc as IStoreable; if (isDoc != null)
            {
                isDoc.Read();
            }
            else
            {
                Console.WriteLine("IStorable not supported");
            }

            ICompressiible icDoc = doc as ICompressiible;
            if (icDoc != null)
            {
                icDoc.Compress();
            }
            else
            {
                Console.WriteLine("Compressible not supported");
            }

            ILoggedCompressible ilcDoc = doc as ILoggedCompressible;
            if (ilcDoc != null)
            {
                ilcDoc.LogSavedBytes();
                ilcDoc.Compress();
                // ilcDoc.Read(); // không thể gọi được
            }
            else
            {
                Console.WriteLine("LoggedCompressible not supported");
            }
            IStorableCompressible isc = doc as IStorableCompressible;
            if (isc != null)
            {
                isc.LogOriginalSize();		// IStorableCompressible isc.LogSavedBytes();	// ILoggedCompressible isc.Compress();  // ICompress
                isc.Read();	// IStorable
            }
            else
            {
                Console.WriteLine("StorableCompressible not supported");
            }
            IEncryptable ie = doc as IEncryptable;
            if (ie != null)
            {
                ie.Encrypt();
            }
            else
            {
                Console.WriteLine("Encryptable not supported");
            }
              */

        }
    }
}
