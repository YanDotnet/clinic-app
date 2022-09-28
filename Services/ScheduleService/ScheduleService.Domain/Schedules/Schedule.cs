using ScheduleService.Domain.Days;

namespace ScheduleService.Domain.Schedules;

public class Schedule : BaseEntity, ISchedule
{
    public string OwnerId { get; set; } = null!;
    
    public DayCollection Days { get; set; } = new();
}