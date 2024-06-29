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

        public async Task<AuthResponse> AuthenticateAsync()
        {
            var userAgent = new ProductInfoHeaderValue(".NET", "8.0");
            _httpClient.DefaultRequestHeaders.UserAgent.Add(userAgent);
            
            var authConfig = _config.GetSection("AuthenticationSettings").Get<AuthenticationSettings>();

            try
            {
                HttpResponseMessage response = await _httpClient.PostAsync
                (
                    "https://auth.mangadex.org/realms/mangadex/protocol/openid-connect/token",
                     authConfig.ToFormUrlEncoded()
                );

                var json = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<AuthResponse>(json);

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
