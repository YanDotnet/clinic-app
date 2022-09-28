using Microsoft.EntityFrameworkCore;
using ScheduleService.Infrastructure.Persistence;

namespace ScheduleService.Api.Installers;

public class DbInstaller : IInstaller
{
    public void InstallServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(
            o => o.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
    }
}