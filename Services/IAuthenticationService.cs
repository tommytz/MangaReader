using MangaReader.Entities;

namespace MangaReader.Services
{
    public interface IAuthenticationService
    {
        Task<AuthResponse> AuthenticateAsync();
    }
}
