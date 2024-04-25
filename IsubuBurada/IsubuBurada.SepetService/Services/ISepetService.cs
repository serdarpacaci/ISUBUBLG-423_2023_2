using IsubuBurada.SepetService.Models;

namespace IsubuBurada.SepetService.Services
{
    public interface ISepetService
    {
        Task SepetKaydet(SepetDto input);

        Task<SepetDto> GetUyeSepet(string userId);
        Task Sil(string userId);
    }
}
