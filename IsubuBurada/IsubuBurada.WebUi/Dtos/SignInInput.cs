using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace IsubuBurada.WebUi.Dtos
{
    public class SignInInput
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }
    }
}
