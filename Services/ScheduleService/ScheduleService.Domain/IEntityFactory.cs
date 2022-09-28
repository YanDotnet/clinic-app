using ScheduleService.Domain.Days;
using ScheduleService.Domain.Registrations;
using ScheduleService.Domain.Schedules;

namespace ScheduleService.Domain;

public interface IEntityFactory
{
    Schedule NewSchedule(string ownerId);

    Day NewDefaultWorkDay(string scheduleId, DateTime date);

    Day NewDay(string scheduleId, DateTime date, DateTime workDayStart, DateTime workDayEnd);

    Registration NewRegistration(string registeredUserId, DateTime start, DateTime end, string? reason);
}