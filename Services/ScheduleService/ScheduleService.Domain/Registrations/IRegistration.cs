using ScheduleService.Domain.ValueObjects;

namespace ScheduleService.Domain.Registrations;

public interface IRegistration
{
    public string RegisteredUserId { get; set; }
    
    public TimeRange Time { get; set; }

    public string? Reason { get; set; }
}