namespace Shared;

public class DateTimeExtensions
{
    public static DateTime GetDefaultWorkDayStart(DateTime day)
    {
        return day.Date.AddHours(9);
    }
    
    public static DateTime GetDefaultWorkDayEnd(DateTime day)
    {
        return day.Date.AddHours(18);
    }
}