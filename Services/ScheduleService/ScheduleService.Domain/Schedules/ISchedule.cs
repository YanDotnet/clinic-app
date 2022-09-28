using ScheduleService.Domain.Days;

namespace ScheduleService.Domain.Schedules;

public interface ISchedule
{
    string OwnerId { get; set; }
    
    DayCollection Days { get; set; }
}