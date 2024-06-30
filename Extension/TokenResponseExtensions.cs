using IdentityModel.Client;

namespace ExtensionMethods
{
    public static class TokenResponseExtensions
    {
        private static readonly string _refreshExpiresIn = "refresh_expires_in";

        public static int RefreshExpiresIn(this TokenResponse tokenResponse)
        {
            var value = tokenResponse.TryGet(_refreshExpiresIn);

            if (value != null)
            {
                if (int.TryParse(value, out var theValue))
                {
                    return theValue;
                }
            }

            return 0;
        }
    }
}
