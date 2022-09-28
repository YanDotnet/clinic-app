using Shared;

namespace ScheduleService.Domain.ValueObjects;

public class TimeRange : ValueObject
{
    public DateTime Start { get; set; }
    
    public DateTime End { get; set; }

    public TimeRange()
    {
        
    }

    public TimeRange(DateTime start, DateTime end)
    {
        TimeRangeValidator.CheckTimes(start, end);
        
        Start = start;
        End = end;
    }

    public TimeRange ChangeStartTime(DateTime newStart)
    {
        TimeRangeValidator.CheckTimes(newStart, End);

        return new TimeRange(newStart, End);
    }

    public TimeRange ChangeEndTime(DateTime newEnd)
    {
        TimeRangeValidator.CheckTimes(Start, newEnd);

        return new TimeRange(Start, newEnd);
    }

    public bool Contains(TimeRange inner)
    {
        return Start <= inner.Start && End >= inner.End;
    }

    public bool InRange(TimeRange other)
    {
        return Start <= other.End && End >= other.Start;
    }

    public override string ToString()
    {
        return $"{Start:HH:mm} - {End:HH:mm}";
    }
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Start;
        yield return End;
    }
}