using ScheduleService.Domain;
using ScheduleService.Domain.Days;
using ScheduleService.Domain.Registrations;
using ScheduleService.Domain.Schedules;
using ScheduleService.Domain.ValueObjects;
using Shared;

namespace ScheduleService.Infrastructure;

public class EntityFactory : IEntityFactory
{
    public Schedule NewSchedule(string ownerId)
    {
        throw new NotImplementedException();
    }

    public Day NewDefaultWorkDay(string scheduleId, DateTime date)
    {
        return new Day(scheduleId, date, new TimeRange(DateTimeExtensions.GetDefaultWorkDayStart(date),
            DateTimeExtensions.GetDefaultWorkDayEnd(date)));
    }

    public Day NewDay(string scheduleId, DateTime date, DateTime workDayStart, DateTime workDayEnd)
    {
        return new Day(scheduleId, date, new TimeRange(workDayStart, workDayEnd));
    }

    public Registration NewRegistration(string registeredUserId, DateTime start, DateTime end, string? reason)
    {
        return new Registration(registeredUserId, new TimeRange(start, end), reason);
    }
}