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
        private readonly ICacheManager _cacheManager;

        public AuthenticationController(
            ILogger<AuthenticationController> logger,
            ICacheManager cacheManager)
        {
            _logger = logger;
            _cacheManager = cacheManager;
        }

        [HttpGet(Name = "GetBearerToken")]
        public async Task<ActionResult<string>> GetBearerToken()
        {
            var bearer = await _cacheManager.GetAccessTokenAsync();

            return Ok(bearer);
        }
    }
}
