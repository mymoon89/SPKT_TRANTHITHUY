using System;
using System.Collections.Generic;
using System.Text;

namespace Employ
{
    public interface IEmployee
    {
        string Name // luu tru ten 
        {
            get;
            set;
        }

        int Counter// dem ten nen chi la ReadOnly
        {
            get;
           
        }
    }
}
