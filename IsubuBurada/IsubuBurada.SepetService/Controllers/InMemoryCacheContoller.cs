using IsubuBurada.SepetService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Security.Cryptography;

namespace IsubuBurada.SepetService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InMemoryCacheContoller : ControllerBase
    {
        private readonly IMemoryCache _memoryCache;

        public InMemoryCacheContoller(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        [HttpGet]
        public async Task<IActionResult> GetCacheTest()
        {
            var sonuc =  await _memoryCache.GetOrCreateAsync("dersler", async x =>
            {
                //x.AbsoluteExpiration = DateTime.Now.AddSeconds(15);
                x.SlidingExpiration = TimeSpan.FromSeconds(15);
                var dersler = await DersleriGetir();

                return dersler;
            });

            return Ok(sonuc);
        }

        private async Task<List<Ders>> DersleriGetir()
        {
            await Task.Delay(4000);

            return new List<Ders>
            {
                new Ders{ Id = Guid.NewGuid(), DersAdi = "Sql", OlusturmaTarihi = DateTime.Now},
                new Ders{ Id = Guid.NewGuid(), DersAdi = "C#", OlusturmaTarihi = DateTime.Now},
                new Ders{ Id = Guid.NewGuid(), DersAdi = "YTM", OlusturmaTarihi = DateTime.Now},
                new Ders{ Id = Guid.NewGuid(), DersAdi = "Micro Services", OlusturmaTarihi = DateTime.Now},

            };
        }
    }
}
