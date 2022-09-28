using Microsoft.EntityFrameworkCore;
using ScheduleService.Domain;
using ScheduleService.Domain.Days;
using ScheduleService.Domain.Registrations;
using ScheduleService.Domain.Schedules;
using ScheduleService.Infrastructure.Persistence;

namespace ScheduleService.Infrastructure;

public class Repository : IScheduleRepository
{
    private readonly AppDbContext _context;

    public Repository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<Schedule?> GetSchedule(string id)
    {
        return await _context.Schedules.FindAsync(id);
    }

    public async Task<ICollection<Schedule>> GetSchedules(string ownerId)
    {
        return await _context.Schedules.Where(x => x.OwnerId == ownerId).ToListAsync();
    }

    public async Task<Day?> GetDay(string dayId)
    {
        return await _context.Days.FindAsync(dayId);
    }

    public async Task<Day?> GetDay(string scheduleId, DateTime date)
    {
        return await _context.Days.FirstOrDefaultAsync(x => x.ScheduleId == scheduleId && x.Date == date);
    }

    public Task<ICollection<Day>> GetDays(string scheduleId)
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<Day>> GetDays(string scheduleId, DateTime dateFrom, DateTime dateTo)
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<Registration>> GetRegistration()
    {
        throw new NotImplementedException();
    }

    public void UpdateDay(Day day)
    {
        _context.Days.Update(day);
    }

    public void AddDay(Day day)
    {
        _context.Days.Add(day);
    }

    public void UpdateDay(Day day, Registration registration)
    {
        throw new NotImplementedException();
    }

    public void UpdateSchedule(Schedule schedule)
    {
        _context.Schedules.Update(schedule);
    }
}