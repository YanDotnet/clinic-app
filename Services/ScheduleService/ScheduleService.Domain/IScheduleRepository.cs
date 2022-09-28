using ScheduleService.Domain.Days;
using ScheduleService.Domain.Registrations;
using ScheduleService.Domain.Schedules;

namespace ScheduleService.Domain;

public interface IScheduleRepository
{    
    Task<Schedule?> GetSchedule(string id);
    Task<ICollection<Schedule>> GetSchedules(string ownerId);

    Task<Day?> GetDay(string dayId);
    Task<Day?> GetDay(string scheduleId, DateTime date);
    Task<ICollection<Day>> GetDays(string scheduleId);
    Task<ICollection<Day>> GetDays(string scheduleId, DateTime dateFrom, DateTime dateTo);

    Task<ICollection<Registration>> GetRegistration();
    void UpdateDay(Day day);
    void AddDay(Day day);
    void UpdateDay(Day day, Registration registration);

    void UpdateSchedule(Schedule schedule);
}