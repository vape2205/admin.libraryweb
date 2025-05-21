using admin.libraryweb.Interfaces.Services;
using admin.libraryweb.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace admin.libraryweb.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly IAppAuthenticationService _appAuthenticationService;

        public AccountController(IAppAuthenticationService appAuthenticationService)
        {
            _appAuthenticationService = appAuthenticationService;
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }

            await _appAuthenticationService.Authenticate(request);
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
