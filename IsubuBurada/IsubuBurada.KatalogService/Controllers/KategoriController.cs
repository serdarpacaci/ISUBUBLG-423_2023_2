using IsubuBurada.KatalogService.Dtos;
using IsubuBurada.KatalogService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IsubuBurada.KatalogService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KategoriController : ControllerBase
    {
        private readonly IKategoriService _kategoriService;

        public KategoriController(IKategoriService kategoriService)
        {
            _kategoriService = kategoriService;
        }

        [HttpGet]
        public async Task<List<KategoriDto>> GetKategoriler()
        {
            var kategoriler = await _kategoriService.GetTumKategoriler();

            return kategoriler;
        }

        [HttpPost]
        public async Task CreateKategori(CreateOrEditKategoriDto input)
        {
            await _kategoriService.CreateOrUpdate(input);
        }

        [HttpPut]
        public async Task EditKategori(CreateOrEditKategoriDto input)
        {
            await _kategoriService.CreateOrUpdate(input);
        }

        [HttpDelete]
        public async Task Delete(string id)
        {
            await _kategoriService.Delete(id);
        }
    }
}
