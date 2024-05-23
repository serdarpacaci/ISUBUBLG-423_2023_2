using IsubuBurada.WebUi.Handlers;

namespace IsubuBurada.WebUi.Services
{
    public static class IsubuServiceExtension
    {
        public static void AddHttpClientServices(this IServiceCollection services, IConfiguration Configuration)
        {
            //var serviceApiSettings = Configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
            services.AddHttpClient<IClientCredentialTokenService, ClientCredentialTokenService>();
            services.AddHttpClient<IIdentityService, IdentityService>();

            services.AddHttpClient<IKatalogService, KatalogService>(opt =>

            {
                opt.BaseAddress = new Uri($"https://localhost:7229/services/katalog");
            }).AddHttpMessageHandler<ClientCredentialTokenHandler>();


        }
    }
}