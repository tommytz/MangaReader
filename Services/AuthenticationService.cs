using MangaReader.Entities;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace MangaReader.Services
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResponse> AuthenticateAsync();
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

        // TODO: Consider using https://github.com/IdentityModel/IdentityModel for token requests and refresh
        public async Task<AuthenticationResponse> AuthenticateAsync()
        {
            try
            {
                HttpResponseMessage response = await _httpClient.PostAsync(string.Empty, _options.ToFormUrlEncoded());

                var json = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<AuthenticationResponse>(json);

                return result;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}
