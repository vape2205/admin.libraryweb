using admin.libraryweb.Models;
using admin.libraryweb.Models.ExternalServices.Auth;

namespace admin.libraryweb.Interfaces.Services
{
    public interface IExternalAuthService
    {
        Task<LoginResponse> Login(LoginDto dto);
        Task<RefreshTokenResponse> RefreshToken(RefreshTokenRequest request);
        Task<SignOutResponse> SignOut();
    }
}
