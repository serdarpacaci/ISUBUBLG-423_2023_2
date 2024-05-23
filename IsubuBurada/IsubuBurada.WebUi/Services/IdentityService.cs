using IdentityModel.Client;
using IsubuBurada.WebUi.Dtos;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System.Globalization;
using System.Security.Claims;
using System.Text.Json;

namespace IsubuBurada.WebUi.Services
{
    public class IdentityService : IIdentityService
    {
        HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public IdentityService(HttpClient httpClient, 
            IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<bool> SignIn(SignInInput input)
        {
            var disco = await _httpClient.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest
            {
                Address = "https://localhost:5001"
            });

            if (disco.IsError)
            {
                throw disco.Exception;
            }

            var request = new PasswordTokenRequest
            {
                ClientId = "IsubuBuradaMvcForUser", // configuration
                ClientSecret = "IsubuBuradaForUser",
                UserName = input.UserName,
                Password = input.Password,
                Address = disco.TokenEndpoint
            };

            var token = await _httpClient.RequestPasswordTokenAsync(request);

            if (token.IsError)
            {
                var responseContent = await token.HttpResponse.Content.ReadAsStringAsync();
                var hata = JsonSerializer.Deserialize<object>(responseContent);
                
                return false;
            }

            var userInfoRequest = new UserInfoRequest
            {
                Token = token.AccessToken,
                Address = disco.UserInfoEndpoint
            };

            var userInfo =  await _httpClient.GetUserInfoAsync(userInfoRequest);


            if (userInfo.IsError)
            {
                throw userInfo.Exception;
            }

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(userInfo.Claims,
                CookieAuthenticationDefaults.AuthenticationScheme, "name", "role");

            ClaimsPrincipal principal = new ClaimsPrincipal(claimsIdentity);
            var authenticationProperties = new AuthenticationProperties();
            
            authenticationProperties.StoreTokens(new List<AuthenticationToken>()
            {
                new AuthenticationToken()
                {
                    Name = OpenIdConnectParameterNames.AccessToken,
                    Value = token.AccessToken
                },
                new AuthenticationToken 
                {
                    Name=OpenIdConnectParameterNames.ExpiresIn,
                    Value= DateTime.Now.AddSeconds(token.ExpiresIn).ToString("o",CultureInfo.InvariantCulture)
                }
            }
            );

            await _httpContextAccessor.HttpContext
                .SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                principal, authenticationProperties);

            return true;
        }
    }
}
