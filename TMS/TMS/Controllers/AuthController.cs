using Domain.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using ServiceAbstraction;

namespace TMS.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        public AuthController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Login([FromBody] UserLoginRequest request)
        {
            var response = await _serviceManager.AuthService.LoginAsync(request);

            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register([FromBody] UserRegisterationRequest request)
        {
            var response = await _serviceManager.AuthService.RegisterAsync(request);

            return Ok(response);
        }

        [Authorize]
        [HttpGet("me")]
        public async Task<IActionResult> GetCurrentUser()
        {
            var response = await _serviceManager.AuthService.GetCurrentUserAsync();
            return Ok(response);
        }
    }
}
