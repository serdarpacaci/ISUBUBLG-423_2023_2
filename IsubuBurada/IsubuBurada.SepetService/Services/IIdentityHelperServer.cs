namespace IsubuBurada.SepetService.Services
{
    public interface IIdentityHelperService
    {
        string GetUserId();
    }


    public class IdentityHelperService : IIdentityHelperService
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public IdentityHelperService(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public string GetUserId()
        {
            return _contextAccessor.HttpContext.User.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value;
            
        }
    }

}
