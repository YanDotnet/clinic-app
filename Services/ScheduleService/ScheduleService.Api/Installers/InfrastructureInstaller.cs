using ScheduleService.Application.Services;
using ScheduleService.Application.UseCases.Register;
using ScheduleService.Domain;
using ScheduleService.Infrastructure;

namespace ScheduleService.Api.Installers;

public class InfrastructureInstaller : IInstaller
{
    public void InstallServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IScheduleRepository, Repository>();
        services.AddScoped<IEntityFactory, EntityFactory>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IRegisterUseCase, RegisterUserCase>();
    }
}