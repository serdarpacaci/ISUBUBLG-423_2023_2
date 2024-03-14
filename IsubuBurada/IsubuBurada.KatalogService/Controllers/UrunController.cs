using IsubuBurada.KatalogService.Dtos;
using IsubuBurada.KatalogService.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IsubuBurada.KatalogService.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UrunController : ControllerBase
    {
        private readonly IUrunService _urunService;

        public UrunController(IUrunService urunService)
        {
            _urunService = urunService;
        }

        [HttpGet]
        public async Task<List<UrunDto>> GetUrunler()
        {
            var urunler = await _urunService.GetTumUrunler();

            return urunler;
        }

        [HttpPost]
        public async Task CreateUrun(CreateOrEditUrunDto input)
        {
            await _urunService.CreateOrUpdate(input);
        }

        [HttpPut]
        public async Task EditUrun(CreateOrEditUrunDto input)
        {
            await _urunService.CreateOrUpdate(input);
        }

        [HttpDelete]
        public async Task Delete(string id)
        {
            await _urunService.Delete(id);
        }
    }
}
