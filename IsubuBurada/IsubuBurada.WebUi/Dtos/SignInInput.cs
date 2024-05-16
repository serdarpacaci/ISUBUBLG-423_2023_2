using Microsoft.AspNetCore.Identity;

namespace IsubuBurada.WebUi.Dtos
{
    public class SignInInput
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
