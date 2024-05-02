using IsubuBurada.IndirimService.Models;
using IsubuBurada.IndirimService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IsubuBurada.IndirimService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IndirimController : ControllerBase
    {
        private readonly IIndirimService _indirimService;

        public IndirimController(IIndirimService indirimService)
        {
            _indirimService = indirimService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var sonuc = await _indirimService.GetAllIndirim();

            return Ok(sonuc);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetbyId(int id)
        {
            var sonuc = await _indirimService.GetById(id);
            
            return Ok(sonuc);
        }

        [HttpPost]
        public async Task Kaydet(Indirim indirim)
        {
            await _indirimService.Kaydet(indirim);
        }

        [HttpPut]
        public async Task Guncelle(Indirim indirim)
        {
            await _indirimService.Guncelle(indirim);
        }

        [HttpDelete]
        public async Task Sil(int id)
        {
            await _indirimService.Sil(id);
        }
    }
}
