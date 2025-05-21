using admin.libraryweb.Models;

namespace admin.libraryweb.Interfaces.Services
{
    public interface IAppAuthenticationService
    {
        Task Authenticate(LoginDto dto);
    }
}
