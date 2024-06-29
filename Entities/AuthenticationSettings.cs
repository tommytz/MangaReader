namespace MangaReader.Entities
{
    public class AuthenticationSettings
    {
        public string GrantType { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }

        public FormUrlEncodedContent ToFormUrlEncoded()
        {
            var formData = new Dictionary<string, string>()
            {
                { "grant_type", this.GrantType },
                { "username", this.Username },
                { "password", this.Password },
                { "client_id", this.ClientId },
                { "client_secret", this.ClientSecret }
            };

            return new FormUrlEncodedContent(formData);
        }
    }
}