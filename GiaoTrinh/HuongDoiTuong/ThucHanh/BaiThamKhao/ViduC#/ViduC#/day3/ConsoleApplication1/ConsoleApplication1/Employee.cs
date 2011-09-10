using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    public class Employee
    {
      private string firstName;
      private string lastName;
      private Date birthDate;   
      private Date hireDate;
   
      // constructor initializes name, birth date and hire date
      public Employee( string first, string last, 
         int birthMonth, int birthDay, int birthYear, 
         int hireMonth, int hireDay, int hireYear )
      {
         firstName = first;
         lastName = last;
   
         // create new Date for Employee birth day
         birthDate = new Date( birthMonth, birthDay, birthYear );
         hireDate = new Date( hireMonth, hireDay, hireYear );
      }
             public string ToEmployeeString()
      {
         return lastName + ", " + firstName +
            "  Hired: " + hireDate.ToDateString() +
            "  Birthday: " + birthDate.ToDateString();
      }
   
   }

}
