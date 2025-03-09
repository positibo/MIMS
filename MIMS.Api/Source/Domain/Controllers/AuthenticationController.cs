using MediatR;
using Microsoft.AspNetCore.Mvc;
using MIMS.Api.Source.Domain.UseCases.V1.LoginUser;
using MIMS.Api.Source.Domain.UseCases.V1.RegisterUser;

namespace MIMS.Api.Source.Domain.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IMediator mediator;

        public AuthenticationController(IMediator mediator) => this.mediator = mediator;

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserRequest request) =>
            Ok(await mediator.Send(new LoginUserCommand(request)));

        [HttpPost("register")]
        public async Task<IActionResult> Login([FromBody] RegisterUserRequest request) =>
            Ok(await mediator.Send(new RegisterUserCommand(request)));

        //_logger.LogInformation("User {Username} successfully authenticated", username);
    }
}
