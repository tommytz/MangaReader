using ExtensionMethods;
using Microsoft.Extensions.Caching.Memory;

namespace MangaReader.Services
{
    public interface ICacheManager
    {
        Task<string> GetAccessTokenAsync();
    }

    public class CacheManager : ICacheManager
    {
        private readonly IMemoryCache _memoryCache;
        private readonly IAuthenticationService _authenticationService;

        public CacheManager(IMemoryCache memoryCache, IAuthenticationService authenticationService)
        {
            _memoryCache = memoryCache;
            _authenticationService = authenticationService;
        }

        public async Task<string> GetAccessTokenAsync()
        {
            if (!_memoryCache.TryGetValue("AccessToken", out string? accessToken))
            {
                var authResponse = await _authenticationService.AuthenticateAsync();
                accessToken = authResponse.AccessToken;
                var refreshExpiry = authResponse.RefreshExpiresIn();

                var options = new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromSeconds(authResponse.ExpiresIn));
                _memoryCache.Set<string>("AccessToken", accessToken, options);
            }

            return accessToken;
        }
    }
}
