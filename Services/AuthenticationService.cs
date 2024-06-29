using MangaReader.Entities;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace MangaReader.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly HttpClient _httpClient;
        private readonly AuthenticationOptions _options;

        public AuthenticationService(HttpClient httpClient, IOptions<AuthenticationOptions> options)
        {
            _httpClient = httpClient;
            _options = options.Value;
        }

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
