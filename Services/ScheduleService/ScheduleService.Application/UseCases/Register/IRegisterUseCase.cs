namespace ScheduleService.Application.UseCases.Register;

public interface IRegisterUseCase
{
    Task Execute(string scheduleId, string userId, DateTime start, DateTime end, string reason);

    void SetOutputPort(IOutputPort outputPort);
}