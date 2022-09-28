namespace ScheduleService.Application.UseCases.Register;

public interface IOutputPort
{
    void Ok(string registrationId);
    
    void Invalid(IDictionary<string, List<string>> errors);

    void NotFound(string type, string id);
}