
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    public class Date
    {
        private int month;  // 1-12
        private int day;    // 1-31 based on month
        private int year;   // any year

        // constructor confirms proper value for month;
        // call method Check Day to confirm proper
        // value for day
        public Date(int theMonth, int theDay, int theYear)
        {
            // validate month
            if (theMonth > 0 && theMonth <= 12)
                month = theMonth;

            else
            {
                month = 1;
                Console.WriteLine(
                   "Month {0} invalid. Set to month 1.", theMonth);
            }


            year = theYear;                 // could validate year
            day = CheckDay(theDay);       // validate day
        }
        private int CheckDay(int testDay)
        {
            int[] daysPerMonth = { 0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

            // check if day in range for month
            if (testDay > 0 && testDay <= daysPerMonth[month])
                return testDay;

            // check for leap year
            if (month == 2 && testDay == 29 &&
                 (year % 400 == 0 ||
                   (year % 4 == 0 && year % 100 != 0)))
                return testDay;

            Console.WriteLine(
               "Day {0} invalid. Set to day 1.", testDay);

            return 1;  // leave object in consistent state
        }

        // return date string as month/day/year
        public string ToDateString()
        {
            return month + "/" + day + "/" + year;
        }

    }

}
