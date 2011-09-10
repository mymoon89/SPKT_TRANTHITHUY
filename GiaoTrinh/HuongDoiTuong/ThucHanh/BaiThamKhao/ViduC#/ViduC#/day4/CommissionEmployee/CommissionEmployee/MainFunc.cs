using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommissionEmployee
{
    class MainFunc
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Vi du 1");
            // instantiate CommissionEmployee object
            CommissionEmployee employee = new CommissionEmployee("Sue",
               "Jones", "222-22-2222", 10000.00M, .06M);

            // display commission employee data
            Console.WriteLine(
               "Employee information obtained by properties and methods:\n");
            Console.WriteLine("{0} {1}", "First name is",
               employee.FirstName);
            Console.WriteLine("{0} {1}", "Last name is",
               employee.LastName);
            Console.WriteLine("{0} {1}", "Social security number is",
               employee.SocialSecurityNumber);
            Console.WriteLine("{0} {1:C}", "Gross sales are",
               employee.GrossSales);
            Console.WriteLine("{0} {1:F2}", "Commission rate is",
               employee.CommissionRate);
            Console.WriteLine("{0} {1:C}", "Earnings are",
               employee.Earnings());

            employee.GrossSales = 5000.00M; // set gross sales
            employee.CommissionRate = .1M; // set commission rate

            Console.WriteLine("\n{0}:\n\n{1}",
               "Updated employee information obtained by ToString", employee);
            Console.WriteLine("earnings: {0:C}", employee.Earnings());
        } // end Main

    }
}
