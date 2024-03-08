
using IsubuBurada.KatalogService.Ayarlar;
using IsubuBurada.KatalogService.Services;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace IsubuBurada.KatalogService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddScoped<IKategoriService, KategoriService>();
            builder.Services.AddScoped<IUrunService, UrunService>();

            var mongoDbSection = builder.Configuration.GetSection("MongoDbSettings");
            builder.Services.Configure<MongoDbSettings>(mongoDbSection);
            // Add services to the container.

            builder.Services.AddAutoMapper(Assembly.GetEntryAssembly());

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
