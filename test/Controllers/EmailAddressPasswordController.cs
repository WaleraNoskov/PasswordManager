using Contracts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace PasswordManager.Web;

[ApiController]
[Route("[controller]/[action]")]
public class EmailAddressPasswordController : Controller
{
    private readonly IMediator mediator;
    public EmailAddressPasswordController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateEmailAddressPasswordCommand request)
    {
        var response = await mediator.Send(request);
        
        if(response.IsFailure)
            return BadRequest(response.Error);

        return Ok();
    }
}
