using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions; 
namespace ReplaceRegex
{
    class Program
    {
        static void Main(string[] args)
        {
             
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
            // Create regex to search for IP address pattern.
            string pattern =
            @"([01]?\d\d?|2[0-4]\d|25[0-5])\." +
            @"([01]?\d\d?|2[0-4]\d|25[0-5])\." +
            @"([01]?\d\d?|2[0-4]\d|25[0-5])\." +
            @"([01]?\d\d?|2[0-4]\d|25[0-5])";
            Regex regex = new Regex(pattern);
            Console.WriteLine("Input given —> {0}",
            regex.Replace(numbers[0],
            "xxx.xxx.xxx.xxx"));

        }
    }
}
