using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NegativeNoException
{
    class NegativeNumberException: ApplicationException
    {
        public NegativeNumberException()
            : base("Illegal operation for a negative number")
        {
        }

        // constructor for customizing error message
        public NegativeNumberException(string message)
            : base(message)
        {
        }

        // constructor for customizing error message and 
        // specifying inner exception object
        public NegativeNumberException(string message, Exception inner)
            : base(message, inner)
        {
        }

    }
}
