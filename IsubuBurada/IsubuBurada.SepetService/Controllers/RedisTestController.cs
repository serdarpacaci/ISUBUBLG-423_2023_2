using IsubuBurada.SepetService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace IsubuBurada.SepetService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RedisTestController : ControllerBase
    {
        private readonly RedisService _redisService;

        public RedisTestController(RedisService redisService)
        {
            _redisService = redisService;
        }

        [HttpGet]
        public async Task<IActionResult> GetDersler()
        {
            var db = _redisService.GetDatabase();

            var sonuc = await db.StringGetAsync("dersler");
            if (string.IsNullOrEmpty(sonuc))
            {
                var dersler = await DersleriGetir();
                sonuc = JsonSerializer.Serialize(dersler);
                await db.StringSetAsync("dersler", sonuc);
            }

            var result = JsonSerializer.Deserialize<List<Ders>>(sonuc);
            return Ok(result);
        }


        //[HttpGet]
        //public async Task<IActionResult> SetDersler(SetDerslerInput input)
        //{
        //    var db = _redisService.GetDatabase();

        //    var sonuc = await db.StringGetAsync("dersler");
        //    if (!string.IsNullOrEmpty(sonuc))
        //    {
        //        var result = JsonSerializer.Deserialize<List<Ders>>(sonuc);
        //        return Ok(result);
        //    }

        //    return Ok("Bulunamadı");
        //}

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
