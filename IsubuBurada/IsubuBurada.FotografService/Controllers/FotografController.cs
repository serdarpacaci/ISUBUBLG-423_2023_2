using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IsubuBurada.FotografService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FotografController : ControllerBase
    {
        private readonly string _fotografKlasoru;

        private List<string> _izinVerilenFormatlar = new List<string>
        {
            "image/png",
            "image/jpg",
            "image/jpeg",
            "image/gif",
        };

        public FotografController()
        {
            _fotografKlasoru = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");
        }

        //[HttpPost]
        //public IActionResult Kaydet(IFormFile fotograf)
        //{
        //    if (fotograf.Length == 0 || !_izinVerilenFormatlar.Any(x=> x == fotograf.ContentType))
        //    {
        //        return BadRequest("Hatalı");
        //    }

        //    var extension = Path.GetExtension(fotograf.FileName);
        //    var fileName = Path.GetRandomFileName();
        //    var filePath = Path.Combine(_fotografKlasoru, fileName);

        //    filePath = Path.ChangeExtension(filePath, extension);
        //    using var stream = new FileStream(filePath, FileMode.Create);
        //    fotograf.CopyTo(stream);

        //    return Ok();
        //}


        [HttpPost]
        public async Task<IActionResult> Kaydet(IFormFile fotograf, CancellationToken cancellationToken)
        {
            if (fotograf.Length == 0 || !_izinVerilenFormatlar.Any(x => x == fotograf.ContentType))
            {
                return BadRequest("Hatalı");
            }

            await Task.Delay(TimeSpan.FromSeconds(5));

            var extension = Path.GetExtension(fotograf.FileName);
            var fileName = Path.GetRandomFileName();
            var filePath = Path.Combine(_fotografKlasoru, fileName);

            filePath = Path.ChangeExtension(filePath, extension);
            using var stream = new FileStream(filePath, FileMode.Create);
            await fotograf.CopyToAsync(stream, cancellationToken);

            return Ok();
        }

        [HttpDelete]
        public IActionResult Sil(string fileName)
        {
            var filePath = Path.Combine(_fotografKlasoru, fileName);

            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }
            
            return Ok();
        }
    }
}
