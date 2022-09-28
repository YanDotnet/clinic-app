namespace ScheduleService.Application.UseCases.Register;

public class RegisterValidationUseCase : IRegisterUseCase
{
    private readonly IRegisterUseCase _useCase;
    private IOutputPort _outputPort;
    private readonly Dictionary<string, List<string>> _errors = new();

    public RegisterValidationUseCase(IRegisterUseCase useCase)
    {
        _useCase = useCase;
        _outputPort = new RegisterPresenter();
    }

    public async Task Execute(string scheduleId, string userId, DateTime start, DateTime end, string reason)
    {
        if (end <= start)
        {
            _errors.Add("End", new List<string>{"End time can not be bigger than start time"});
            
            _outputPort.Invalid(_errors);
        }

        await _useCase.Execute(scheduleId, userId, start, end, reason);
    }

    public void SetOutputPort(IOutputPort outputPort)
    {
        _outputPort = outputPort;
        _useCase.SetOutputPort(outputPort);
    }
}