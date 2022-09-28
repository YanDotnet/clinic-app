using ScheduleService.Application.Services;
using ScheduleService.Domain;
using ScheduleService.Domain.ValueObjects;

namespace ScheduleService.Application.UseCases.Register;

public class RegisterUserCase : IRegisterUseCase
{
    private readonly IScheduleRepository _repository;
    private readonly IEntityFactory _factory;
    private readonly IUnitOfWork _unitOfWork;
    private IOutputPort _outputPort;

    public RegisterUserCase(IScheduleRepository repository, IEntityFactory factory, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _factory = factory;
        _unitOfWork = unitOfWork;
        _outputPort = new RegisterPresenter();
    }
    
    public async Task Execute(string scheduleId, string userId, DateTime start, DateTime end, string reason)
    {
        var day = await _repository.GetDay(scheduleId, start.Date);

        if (day is null)
        {
            day = _factory.NewDefaultWorkDay(scheduleId, start.Date);
        }

        day.Id = "t est";

        var timeOfReceipt = new TimeRange(start, end);

        var registration = _factory.NewRegistration(userId, start, end, reason);

        registration.Id = "test";
        
        if (day.IsEmptyTime(timeOfReceipt))
        {
            day.Register(registration);
        }

        _repository.AddDay(day);

        var result = await _unitOfWork.SaveChangesAsync();

        if (result)
        {
            _outputPort.Ok(registration.Id);
            return;
        }
        
        _outputPort.Invalid(new Dictionary<string, List<string>>
        {
            {"Database", new List<string>{"Error during update database"}}
        });
    }

    public void SetOutputPort(IOutputPort outputPort)
    {
        _outputPort = outputPort;
    }
}