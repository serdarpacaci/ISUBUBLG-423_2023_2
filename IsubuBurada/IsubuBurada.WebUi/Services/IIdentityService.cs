using IsubuBurada.WebUi.Dtos;

namespace IsubuBurada.WebUi.Services
{
    public interface IIdentityService
    {
        Task<bool> SignIn(SignInInput input);
    }
}
