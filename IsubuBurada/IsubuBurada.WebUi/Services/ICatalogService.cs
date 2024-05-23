using IsubuBurada.WebUi.Dtos;

namespace IsubuBurada.WebUi.Services
{
    public interface IKatalogService
    {
        Task<List<KategoriDto>> GetKategoriler();
    }

    public class KatalogService : IKatalogService
    {
        private readonly HttpClient _client;
        public KatalogService(HttpClient client)
        {
            _client = client;

        }
        public async Task<List<KategoriDto>> GetKategoriler()
        {
            var cevap = await _client.GetAsync("");
            if (!cevap.IsSuccessStatusCode)
            {
                return null;
            }

            var sonuc = await cevap.Content.ReadFromJsonAsync<List<KategoriDto>>();

            return sonuc;
        }
    }
}
