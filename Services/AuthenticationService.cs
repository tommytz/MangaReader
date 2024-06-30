using IdentityModel.Client;
using MangaReader.Entities;
using Microsoft.Extensions.Options;

namespace MangaReader.Services
{
    public interface IAuthenticationService
    {
        Task<TokenResponse> AuthenticateAsync();
    }

    public class AuthenticationService : IAuthenticationService
    {
        private readonly HttpClient _httpClient;
        private readonly AuthenticationOptions _options;

        public AuthenticationService(HttpClient httpClient, IOptions<AuthenticationOptions> options)
        {
            _httpClient = httpClient;
            _options = options.Value;
        }

        public async Task<TokenResponse> AuthenticateAsync()
        {
            // TODO: Add some error handling code here
            return await _httpClient.RequestPasswordTokenAsync(_options.ToPasswordTokenRequest());
        }
    }
}
