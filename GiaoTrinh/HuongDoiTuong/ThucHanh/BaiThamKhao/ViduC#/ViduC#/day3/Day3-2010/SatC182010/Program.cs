using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SatC182010
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Time1 time = new Time1();  // calls Time1 constructor
            string output;
            // assign string representation of time to output
            output = "Initial universal time is: " +
               time.ToUniversalString() +
               "\nInitial standard time is: " +
               time.ToStandardString();
            // attempt valid time settings
            time.SetTime(13, 27, 6);
            // append new string representations of time to output
            output += "\n\nUniversal time after SetTime is: " +
               time.ToUniversalString() +
               "\nStandard time after SetTime is: " +
               time.ToStandardString();
            // attempt invalid time settings
            time.SetTime(99, 99, 99);
            output += "\n\nAfter attempting invalid settings: " +
        "\nUniversal time: " + time.ToUniversalString() +
        "\nStandard time: " + time.ToStandardString();
            MessageBox.Show(output, "Testing Class Time1");

        }
    }
}
