using Microsoft.AspNetCore.Mvc;
using Nentindo.Presentation.Models.Auth.Requests;
using Nentindo.Services.Auth;

namespace Nentindo.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        IAuthService _authService;
        public AuthenticateController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUserRequest payload)
        {
            try
            {
                var response = await _authService.Register(payload);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest payload)
        {
            try
            {
                var userResponse = await _authService.VerifyCredentials(payload);
                if (!userResponse.IsSuccessful)
                {
                    return Ok(userResponse);
                }
                var token = _authService.GenerateToken(userResponse.Result);
                return Ok(new { Token = token });
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}