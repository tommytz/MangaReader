using MangaReader.Entities;

namespace MangaReader.Services
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResponse> AuthenticateAsync();
    }
}
