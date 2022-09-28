using ScheduleService.Domain.ValueObjects;

namespace ScheduleService.Domain.Registrations;

public class Registration : BaseEntity, IRegistration
{
    public string RegisteredUserId { get; set; } = null!;

    public TimeRange Time { get; set; }

    public string? Reason { get; set; }

    public Registration()
    {
        
    }

    public Registration(string registeredUserId, DateTime start, DateTime end, string? reason)
    {
        RegisteredUserId = registeredUserId;
        Time = new TimeRange(start, end);
        Reason = reason;
    }

    public Registration(string registeredUserId, TimeRange time, string? reason)
    {
        RegisteredUserId = registeredUserId;
        Time = time;
        Reason = reason;
    }
}