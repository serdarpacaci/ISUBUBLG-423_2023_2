using IsubuBurada.KatalogService.Dtos;

namespace IsubuBurada.KatalogService.Services
{
    public interface IUrunService
    {
        Task<List<UrunDto>> GetTumUrunler();

        Task CreateOrUpdate(CreateOrEditUrunDto input);

        Task Delete(string id);
    }
}
