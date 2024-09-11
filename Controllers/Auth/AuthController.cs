using CQRSOrderManagement.Interfaces.Dispatchers;
using CQRSOrderManagement.Models.Auth.Command;
using CQRSOrderManagement.Models.Auth.Response;
using Microsoft.AspNetCore.Mvc;

namespace CQRSOrderManagement.Controllers.Auth
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly ICommandDispatcher _dispatcher;

        public AuthController(ICommandDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterCommand command)
        {
            var result = await _dispatcher.DispatchAsync<RegisterCommand, AuthResponse>(command);
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginCommand command)
        {
            var result = await _dispatcher.DispatchAsync<LoginCommand, AuthResponse>(command);
            return Ok(result);
        }

        [HttpPost("forget-password")]
        public async Task<IActionResult> ForgetPassword([FromBody] ForgetPasswordCommand command)
        {
            var result = await _dispatcher.DispatchAsync<ForgetPasswordCommand, ForgetPasswordResponse>(command);
            return Ok(result);
        }
    }

}
