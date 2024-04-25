using IsubuBurada.IndirimService.Models;

namespace IsubuBurada.IndirimService.Services
{
    public interface IIndirimService
    {
        Task<Indirim> GetAllIndirim();
        Task<Indirim> GetById(int id);
        Task Kaydet(Indirim indirim);
        Task Guncelle(Indirim indirim);
        Task Sil(int id);
    }

    public class IndirimService : IIndirimService
    {
        public Task<Indirim> GetAllIndirim()
        {
            throw new NotImplementedException();
        }

        public Task<Indirim> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Guncelle(Indirim indirim)
        {
            throw new NotImplementedException();
        }

        public Task Kaydet(Indirim indirim)
        {
            throw new NotImplementedException();
        }

        public Task Sil(int id)
        {
            throw new NotImplementedException();
        }
    }
}
