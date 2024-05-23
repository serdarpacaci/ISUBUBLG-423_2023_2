using IsubuBurada.WebUi.Handlers;
using IsubuBurada.WebUi.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Configuration;

namespace IsubuBurada.WebUi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddHttpContextAccessor();
            builder.Services.AddAccessTokenManagement();

            builder.Services.AddScoped<ResourceOwnerPasswordTokenHandler>();
            builder.Services.AddScoped<ClientCredentialTokenHandler>();

            //builder.Services.AddScoped<IClientCredentialTokenService, ClientCredentialTokenService>();
            builder.Services.AddHttpClientServices(builder.Configuration);
           
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, opts =>
            {
                opts.LoginPath = "/Auth/SignIn";
                opts.ExpireTimeSpan = TimeSpan.FromDays(1);
                opts.SlidingExpiration = true;
                opts.Cookie.Name = "isubuBurada";
            });
            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
