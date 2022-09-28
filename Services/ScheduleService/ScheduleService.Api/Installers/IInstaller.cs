namespace ScheduleService.Api.Installers;

public interface IInstaller
{
    void InstallServices(IServiceCollection services, IConfiguration configuration);
}