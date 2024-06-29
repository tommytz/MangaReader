using MangaReader.Entities;
using System.Net.Http.Headers;
using System.Text.Json;

namespace MangaReader.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;

        public AuthenticationService(HttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient;
            _config = config;
        }

        public async Task<AuthenticationResponse> AuthenticateAsync()
        {
            // TODO: Consider using IOptions instead to the whole IConfiguration
            var authConfig = _config.GetSection("AuthenticationSettings").Get<AuthenticationSettings>();

            try
            {
                HttpResponseMessage response = await _httpClient.PostAsync(string.Empty, authConfig.ToFormUrlEncoded());

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
