using IdentityModel;
using IdentityServer4.Validation;
using IsubuBurada.IdentityServer.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace IsubuBurada.IdentityServer.UserValidator
{
    public class IsubuResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public IsubuResourceOwnerPasswordValidator(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            var user = await _userManager.FindByEmailAsync(context.UserName);
            if (user is null)
            {
                AddErrors(context);

                return;
            }

            var passwordDogruMu = await _userManager.CheckPasswordAsync(user, context.Password);

            if (!passwordDogruMu)
            {
                AddErrors(context);

                return;
            }

            context.Result = new GrantValidationResult(user.Id.ToString(),
                OidcConstants.AuthenticationMethods.Password);
        }

        private static void AddErrors(ResourceOwnerPasswordValidationContext context)
        {
            context.Result.CustomResponse = new System.Collections.Generic.Dictionary<string, object>
                {
                    { "errors", "E-posta ya da şifre hatalı" }
                };
        }
    }
}
