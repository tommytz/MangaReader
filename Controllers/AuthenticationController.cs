using MangaReader.Entities;
using MangaReader.Services;
using Microsoft.AspNetCore.Mvc;

namespace MangaReader.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly ILogger<AuthenticationController> _logger;
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(
            ILogger<AuthenticationController> logger,
            IAuthenticationService authenticationService)
        {
            _logger = logger;
            _authenticationService = authenticationService;
        }

        [HttpGet(Name = "GetBearerToken")]
        public async Task<ActionResult<AuthResponse>> GetBearerToken()
        {
            var authResponse = await _authenticationService.AuthenticateAsync();

            return Ok(authResponse);
        }
    }
}
