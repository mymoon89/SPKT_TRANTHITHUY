using System;
// Time1 class definition
public class Time1 : Object
{
    private int hour;    // 0-23
    private int minute;  // 0-59
    private int second;  // 0-59
    // Time1 constructor initializes instance variables to 
    // zero to set default time to midnight
    public Time1()
    {
        SetTime(0, 0, 0);
    }
    // Set new time value in 24-hour format. Perform validity
    // checks on the data. Set invalid values to zero.
    public void SetTime(
       int hourValue, int minuteValue, int secondValue)
    {
        hour = (hourValue >= 0 && hourValue < 24) ?
           hourValue : 0;
        minute = (minuteValue >= 0 && minuteValue < 60) ?
           minuteValue : 0;
        second = (secondValue >= 0 && secondValue < 60) ?
    secondValue : 0;
    } // end method SetTime
    // convert time to universal-time (24 hour) format string
    public string ToUniversalString()
    {
        return String.Format(
           "{0:D2}:{1:D2}:{2:D2}", hour, minute, second);
    }
    // convert time to standard-time (12 hour) format string
    public string ToStandardString()
    {
        return String.Format("{0}:{1:D2}:{2:D2} {3}",
           ((hour == 12 || hour == 0) ? 12 : hour % 12),
           minute, second, (hour < 12 ? "AM" : "PM"));
    }
} // end class Time1

