namespace ScheduleService.Application.UseCases.Register;

public class RegisterPresenter : IOutputPort
{
    public void Ok(string registrationId)
    {
        throw new NotImplementedException();
    }

    public void Invalid(IDictionary<string, List<string>> errors)
    {
        throw new NotImplementedException();
    }

    public void NotFound(string type, string id)
    {
        throw new NotImplementedException();
    }
}