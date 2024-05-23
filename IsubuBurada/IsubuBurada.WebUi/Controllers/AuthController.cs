using IsubuBurada.WebUi.Dtos;
using IsubuBurada.WebUi.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
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

        public IActionResult SignIn(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(SignInInput input)
        {
            if (!ModelState.IsValid)
                return View(input);

            var result = await _identityService.SignIn(new Dtos.SignInInput
            {
                UserName = input.UserName,// "BobSmith@email.com",
                Password = input.Password, //"Pass123$"
            });

            if (result)
            {
                //Local url redirect kontrol edilmeli
                if (!string.IsNullOrEmpty(input.ReturnUrl))
                    return Redirect(input.ReturnUrl);
            }


            return View(input);
        }

        public async  Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Index", "Home");
        }
    }
}
