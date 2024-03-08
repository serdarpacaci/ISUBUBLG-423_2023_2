using AutoMapper;
using IsubuBurada.KatalogService.Ayarlar;
using IsubuBurada.KatalogService.Dtos;
using IsubuBurada.KatalogService.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace IsubuBurada.KatalogService.Services
{
    public class UrunService : IUrunService
    {
        private readonly IMongoCollection<Urun> _urunCollection;
        private readonly MongoDbSettings _databaseSettings;

        private IMapper _mapper;
        public UrunService(IOptions<MongoDbSettings> databaseSettings,
            IMapper mapper)
        {
            _databaseSettings = databaseSettings.Value;

            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.Database);

            _urunCollection = database
                .GetCollection<Urun>(MongoDbTables.UrunTableName);
            _mapper = mapper;
        }
        public async Task CreateOrUpdate(CreateOrEditUrunDto input)
        {
            if (string.IsNullOrEmpty(input.Id))
            {
                //create
                await Create(input);
            }
            else
            {
                //update

                await Update(input);
            }
        }

        private async Task Update(CreateOrEditUrunDto input)
        {
            var urun = _urunCollection
                .AsQueryable()
                .Where(x => x.Id == input.Id)
                .FirstOrDefault();

            _mapper.Map(input, urun);

            urun.GuncellenmeTarihi = DateTime.Now;

            await _urunCollection
                .ReplaceOneAsync(Builders<Urun>.Filter.Eq(x => x.Id, input.Id), urun);
        }

        private async Task Create(CreateOrEditUrunDto input)
        {
            var urun = _mapper.Map<Urun>(input);
            
            urun.EklenmeTarihi = DateTime.Now;
            await _urunCollection.InsertOneAsync(urun);
        }

        public async Task Delete(string id)
        {
            await _urunCollection
                .DeleteOneAsync(Builders<Urun>.Filter.Eq(x => x.Id, id));
        }

        public async Task<List<UrunDto>> GetTumUrunler()
        {
            var urunler = await _urunCollection
                .AsQueryable()
                .ToListAsync();

            var sonuc = _mapper.Map<List<UrunDto>>(urunler);

            return sonuc;
        }
    }
}
