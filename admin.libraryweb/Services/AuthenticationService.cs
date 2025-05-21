using admin.libraryweb.Interfaces.Services;
using admin.libraryweb.Models;
using Microsoft.AspNetCore.Authentication;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace admin.libraryweb.Services
{
    public class AuthenticationService : IAppAuthenticationService
    {
        private readonly IExternalAuthService _authService;
        private readonly IHttpContextAccessor _contextAccessor;

        public AuthenticationService(IExternalAuthService authService,
            IHttpContextAccessor contextAccessor)
        {
            _authService = authService;
            _contextAccessor = contextAccessor;
        }

        public async Task Authenticate(LoginDto dto)
        {
            var response = await _authService.Login(dto);
            if (response == null)
            {
                return;
            }

            var jwtHandler = new JwtSecurityTokenHandler();
            var jwtToken = jwtHandler.ReadJwtToken(response.IdToken);
            var userId = jwtToken.Claims.FirstOrDefault(x => x.Type == "nameid")?.Value ?? string.Empty;

            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, dto.Username),
                    new Claim(ClaimTypes.NameIdentifier, userId)
                };
            ClaimsIdentity userIdentity = new ClaimsIdentity(claims, "login");
            ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);

            var properties = new AuthenticationProperties();
            properties.IsPersistent = true;
            properties.Items["access_token"] = response.AccessToken;
            properties.Items["refresh_token"] = response.RefreshToken;
            properties.Items["id_token"] = response.IdToken;

            await _contextAccessor.HttpContext.SignInAsync(principal, properties);
            _contextAccessor.HttpContext.Response.Cookies.Append("access_token", response.AccessToken);
            _contextAccessor.HttpContext.Response.Cookies.Append("refresh_token", response.RefreshToken);
            _contextAccessor.HttpContext.Response.Cookies.Append("id_token", response.IdToken);
        }
    }
}