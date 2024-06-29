namespace MangaReader.Entities
{
    public class AuthenticationOptions
    {
        public string GrantType { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }

        public FormUrlEncodedContent ToFormUrlEncoded()
        {
            var formData = new List<KeyValuePair<string, string>>()
            {
                new ("grant_type", this.GrantType),
                new ("username", this.Username),
                new ("password", this.Password),
                new ("client_id", this.ClientId),
                new ("client_secret", this.ClientSecret)
            };

            return new FormUrlEncodedContent(formData);
        }
    }
}