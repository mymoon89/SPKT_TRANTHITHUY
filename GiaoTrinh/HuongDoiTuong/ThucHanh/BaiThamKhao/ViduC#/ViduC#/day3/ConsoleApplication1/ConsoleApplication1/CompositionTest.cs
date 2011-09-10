  using System;
    using System.Windows.Forms;
namespace ConsoleApplication1
{
    // Composition class definition
    class CompositionTest
    {
        // main entry point for application
        static void Main(string[] args)
        {
            Employee e =
               new Employee("Bob", "Jones", 7, 24, 1949, 3, 12, 1988);

            MessageBox.Show(e.ToEmployeeString(),
               "Testing Class Employee");

        } // end method Main

    }
}
