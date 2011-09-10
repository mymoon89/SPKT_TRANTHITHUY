using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {

            Employee emp = new Employee( "Vasya","Pupkin" );
emp.ssn = 1234567890;
Console.WriteLine( "{0} {1}",emp.firstName,emp.lastName );
if( emp.terminationDate.HasValue ) {
Console.WriteLine( "Start Date: {0}",
emp.terminationDate );
}
long tempSSN = emp.ssn ?? -1;
Console.WriteLine( "SSN: {0}", tempSSN );


        }
    }
}