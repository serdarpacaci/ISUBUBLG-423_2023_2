using IsubuBurada.WebUi.Services;
using Microsoft.AspNetCore.Mvc;

namespace IsubuBurada.WebUi.Controllers
{
    public class AuthController : Controller
    {
        private readonly IIdentityService _identityService;

        public AuthController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public async Task<IActionResult> Index()
        {
            await _identityService.SignIn(new Dtos.SignInInput
            {
                UserName = "BobSmith@email.com",
                Password = "Pass123$"
            });
            return View();
        }
    }
}
