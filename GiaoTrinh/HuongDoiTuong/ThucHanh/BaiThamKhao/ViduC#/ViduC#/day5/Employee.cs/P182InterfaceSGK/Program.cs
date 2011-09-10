using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P182InterfaceSGK
{
    class Program
    {
        static void Main(string[] args)
        {
            Document doc = new Document("Test Document");
             
// gán đối tượng cho giao diện
I1 isDoc = doc as I1;
if ( isDoc != null)
{
isDoc.Read();
}
else
{
Console.WriteLine("IStorable not supported");
}
I2 icDoc = doc as I2;
if ( icDoc != null )
{
icDoc.Compress();
    }
else
{
Console.WriteLine("Compressible not supported");
}
I32  ilcDoc = doc as I32;
//I32 ilcDoc = (I32)doc; 
if ( ilcDoc != null )
{
ilcDoc.LogSavedBytes();
ilcDoc.Compress();
// ilcDoc.Read(); // không thể gọi được
}
            else
{
Console.WriteLine("LoggedCompressible not supported");
}
I413 isc = doc as I413; // su dung duoc cua tat ca I1, I2,I32
if ( isc != null )
{
isc.LogOriginalSize(); // IStorableCompressible
isc.LogSavedBytes(); // ILoggedCompressible
isc.Compress(); // ICompress
isc.Read(); // IStorable
}
            else
{
Console.WriteLine("StorableCompressible not supported");
}
I5 ie = doc as I5;
if ( ie != null )
{
ie.Encrypt();
}
            else
{
Console.WriteLine("Encryptable not supported");
}
        }

}
        }
    


