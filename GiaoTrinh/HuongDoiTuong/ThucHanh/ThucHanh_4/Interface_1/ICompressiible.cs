using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interface_08110121
{
    interface ICompressiible
    {
        void Compress();
        void DeCompress();
    }

    interface ILoggedCompressible:ICompressiible
    {
        void LogSavedBytes();
    }

    interface IStorableCompressible : IStoreable, ILoggedCompressible
    {
        void LogOriginalSize();
    }

    interface IEncryptable
    {
        void Encrypt();
        void Decrypt();
    }



}
