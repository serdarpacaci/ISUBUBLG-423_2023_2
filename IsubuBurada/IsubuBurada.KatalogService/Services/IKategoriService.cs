using IsubuBurada.KatalogService.Dtos;

namespace IsubuBurada.KatalogService.Services
{
    public interface IKategoriService
    {
        Task<List<KategoriDto>> GetTumKategoriler();

        Task CreateOrUpdate(CreateOrEditKategoriDto input);

        Task Delete(string id);
    }
}
