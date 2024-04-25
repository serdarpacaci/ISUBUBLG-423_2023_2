
using IsubuBurada.SepetService.Models;
using IsubuBurada.SepetService.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.IdentityModel.Tokens.Jwt;

namespace IsubuBurada.SepetService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var redisSection = builder.Configuration.GetSection("RedisSettings");
            builder.Services.Configure<RedisSettings>(redisSection);

            builder.Services.AddSingleton<RedisService>();
            builder.Services.AddScoped<ISepetService, MySepetService>();
            builder.Services.AddScoped<IIdentityHelperService, IdentityHelperService>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddMemoryCache();


            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
               .AddJwtBearer(x =>
               {
                   x.Authority = "https://localhost:5001";
                   x.Audience = "resource_sepet";
                   x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                   {
                       ClockSkew = TimeSpan.FromSeconds(20),
                       RequireExpirationTime = true,
                       ValidateLifetime = true,
                   };
               });

            builder.Services.AddHttpContextAccessor();

            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            
            //JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Remove("sub");

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
