using IdentityModel.Client;

namespace MangaReader.Entities
{
    public class AuthenticationOptions
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }

        public PasswordTokenRequest ToPasswordTokenRequest()
        {
            return new PasswordTokenRequest
            {
                ClientId = this.ClientId,
                ClientSecret = this.ClientSecret,
                UserName = this.Username,
                Password = this.Password
            };
        }

        public RefreshTokenRequest ToRefreshTokenRequest(string refreshToken)
        {
            return new RefreshTokenRequest
            {
                ClientId = this.ClientId,
                ClientSecret = this.ClientSecret,
                RefreshToken = refreshToken
            };
        }
    }
}