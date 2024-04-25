
using IsubuBurada.SepetService.Models;
using IsubuBurada.SepetService.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IsubuBurada.SepetService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SepetController : ControllerBase
    {
        private readonly ISepetService _sepetService;
        private readonly IIdentityHelperService _identityHelperService;

        public SepetController(ISepetService sepetService, 
            IIdentityHelperService identityHelperService)
        {
            _sepetService = sepetService;
            _identityHelperService = identityHelperService;
        }

        [HttpGet]
        public async Task<IActionResult> GetSepet()
        {
            string userId = _identityHelperService.GetUserId();
            var sepet = await _sepetService.GetUyeSepet(userId);

            return Ok(sepet);
        }

        [HttpPost]
        public async Task<IActionResult> SepetKaydet(SepetDto sepetDto)
        {
            string userId = _identityHelperService.GetUserId();
            sepetDto.UserId = userId;

            await _sepetService.SepetKaydet(sepetDto);

            return Created();
        }


        [HttpDelete]
        public async Task<IActionResult> SepetSil()
        {
            string userId = _identityHelperService.GetUserId();

            await _sepetService.Sil(userId);

            return Ok();
        }

    }
}
