using GMS.Application.Services.Authentication.Command.Register;
using GMS.Application.Services.Authentication.Queries.Login;
using GMS.Contracts.Authentication;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        private readonly ISender _mediator;

        public AuthController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {

            var command = new RegisterCommand(request.Firstname, request.Lastname, request.Email, request.Password);

            var authResult = await _mediator.Send(command);

            return Ok(authResult);
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var query = new LoginQuery(request.Email, request.Password);

            var authResult = await _mediator.Send(query);

            return Ok(authResult);
        }
    }
}
