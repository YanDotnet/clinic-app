using ScheduleService.Domain.Registrations;
using ScheduleService.Domain.ValueObjects;

namespace ScheduleService.Domain.Days;

public class Day : BaseEntity
{
    public string ScheduleId { get; set; }

    public DateTime Date { get; set; }
    
    public TimeRange AvailableTime { get; set; }

    public RegistrationCollection Registrations { get; set; } = new();

    private Day()
    {
        
    }

    public Day(string id, string scheduleId, DateTime dateTime, DateTime start, DateTime end)
        : this(id, scheduleId, dateTime, new TimeRange(start, end))
    {
        
    }
    
    public Day(string scheduleId, DateTime date, TimeRange availableTime)
    {
        Id = Guid.NewGuid().ToString();
        ScheduleId = scheduleId;
        Date = date;
        AvailableTime = availableTime;
    }

    public Day(string id, string scheduleId, DateTime date, TimeRange availableTime)
    {
        Id = id;
        ScheduleId = scheduleId;
        Date = date;
        AvailableTime = availableTime;
    }

    public bool TryRegister(Registration registration)
    {
        try
        {
            Register(registration);
            return true;
        }
        catch
        {
            return false;
        }
    }
    
    public void Register(Registration registration)
    {
        if (!IsValidTimeToRegister(registration.Time))
            throw new ApplicationException("day.register.invalidTime");
        
        Registrations.Add(registration);
    }

    public bool IsValidTimeToRegister(TimeRange timeRange)
    {
        return AvailableTime.Contains(timeRange) && IsEmptyTime(timeRange);
    }
    
    public bool IsEmptyTime(TimeRange timeRange)
    {
        return !Registrations.Exists(registration => timeRange.InRange(registration.Time));
    }
}