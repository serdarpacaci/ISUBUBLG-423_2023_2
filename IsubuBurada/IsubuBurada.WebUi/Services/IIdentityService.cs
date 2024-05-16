using IdentityModel.Client;
using IsubuBurada.WebUi.Dtos;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System.Net.WebSockets;
using System.Security.Claims;
using System.Text.Json;

namespace IsubuBurada.WebUi.Services
{
    public interface IIdentityService
    {
        Task<bool> SignIn(SignInInput input);
    }

    public class IdentityService : IIdentityService
    {
        HttpClient _httpClient;
        public IdentityService()
        {
            _httpClient = new HttpClient();
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
                ClientId = "IsubuBuradaMvcForUser",
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
                }
            }
            );


            return true;
        }
    }
}
