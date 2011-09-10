using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            string columns = "Column 1\tColumn 2\tColumn 3";
            //Output: Column 1 Column 2 Column 3 
            Console.WriteLine(columns );
            string rows = "Row 1\r\nRow 2\r\nRow 3";
            Console.WriteLine(rows );
            /* Output: 
            Row 1 
            Row 2 
            Row 3
             */
            string title = "\"The \u00C6olean Harp\", by Samuel Taylor Coleridge";
            Console.WriteLine(title );
                        string unicodeString = "This string contains the unicode character Pi(\u03a0)";
            // Create two different encodings.
            Encoding ascii = Encoding.ASCII;
            Encoding unicode = Encoding.Unicode;

            // Convert the string into a byte[].
            byte[ ] unicodeBytes = unicode.GetBytes(unicodeString);
            // Perform the conversion from one encoding to the other.
            byte[] asciiBytes = Encoding.Convert(unicode, ascii, unicodeBytes);

            // Convert the new byte[] into a char[] and then into a string.
            // This is a slightly different approach to converting to illustrate
            // the use of GetCharCount/GetChars.
            char[] asciiChars = new char[ascii.GetCharCount(asciiBytes, 0, asciiBytes.Length)];
            ascii.GetChars(asciiBytes, 0, asciiBytes.Length, asciiChars, 0);
            string asciiString = new string(asciiChars);

            // Display the strings created before and after the conversion.
            Console.WriteLine("Original string: {0}", unicodeString);
            Console.WriteLine("Ascii converted string: {0}", asciiString);
            Console.Read();
            string[] numbers = 
        {
            "123-456-7890", 
            "444-234-22450", 
            "690-203-6578", 
            "146-893-232",
            "146-839-2322",
            "4007-295-1111", 
            "407-295-1111", 
            "407-2-5555", 
        };

            string sPattern = "^\\d{3}-\\d{3}-\\d{4}$";
            foreach (string s in numbers)
            {
                System.Console.Write("{0,14}", s);
               
                if (Regex.IsMatch(s, sPattern))
                {
                    System.Console.WriteLine(" - valid");
                }
                else
                {
                    System.Console.WriteLine(" - invalid");
                }
            }

            // Keep the console window open in debug mode.
            System.Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();

        }
    }
}
