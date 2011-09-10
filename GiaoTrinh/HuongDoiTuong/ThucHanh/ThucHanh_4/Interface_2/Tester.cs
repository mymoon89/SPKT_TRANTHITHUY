using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interface2_08110121
{    
    public class Tester
    {
        static void Main()
        {
            // tạo đối tượng Document
            Document theDoc = new Document("Test Document");
            IStorable isDoc = theDoc as IStorable;
            if (isDoc != null)
            {
                isDoc.Read();
            }
            ITalk itDoc = theDoc as ITalk;
            if (itDoc != null)
            {
                itDoc.Read();
            }
            theDoc.Read();
            theDoc.Talk();
        }
    }

}
