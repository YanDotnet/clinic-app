namespace ScheduleService.Domain.ValueObjects;

public static class TimeRangeValidator
{
    public static void CheckTimes(DateTime start, DateTime end)
    {
        if (end <= start)
            throw new ApplicationException("timeRangeValidator.checkTimeException");
    }
}