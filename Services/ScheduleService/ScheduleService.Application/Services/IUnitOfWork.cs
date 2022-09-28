namespace ScheduleService.Application.Services;

public interface IUnitOfWork
{
    Task<bool> SaveChangesAsync();
}