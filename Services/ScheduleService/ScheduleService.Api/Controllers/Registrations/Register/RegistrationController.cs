using Microsoft.AspNetCore.Mvc;
using ScheduleService.Application.UseCases.Register;

namespace ScheduleService.Api.Controllers.Registrations.Register;

[ApiController]
[Route("api/v1/[controller]/[action]")]
public class RegistrationController : ControllerBase, IOutputPort
{
    private readonly IRegisterUseCase _useCase;
    private IActionResult _actionResult;

    public RegistrationController(IRegisterUseCase useCase)
    {
        _useCase = useCase;
        _actionResult = base.Ok();
    }
    
    [NonAction]
    public void Ok(string registrationId)
    {
        _actionResult = base.Ok(registrationId);
    }

    [NonAction]
    public void Invalid(IDictionary<string, List<string>> errors)
    {
        _actionResult = base.BadRequest(errors);
    }

    [NonAction]
    public void NotFound(string type, string id)
    {
        _actionResult = base.NotFound(type);
    }

    [HttpPost]
    public async Task<IActionResult> Register([FromBody] RegistrationRequest request)
    {
        _useCase.SetOutputPort(this);

        await _useCase.Execute(request.ScheduleId, request.UserId, request.Start, request.End, request.Reason);

        return _actionResult;
    }

    public class RegistrationRequest
    {
        public string ScheduleId { get; set; } = null!;

        public string UserId { get; set; }

        public DateTime Start { get; set; }
        
        public DateTime End { get; set; }
        
        public string Reason { get; set; }
    }
}