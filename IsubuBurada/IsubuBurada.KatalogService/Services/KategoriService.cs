using AutoMapper;
using IsubuBurada.KatalogService.Ayarlar;
using IsubuBurada.KatalogService.Dtos;
using IsubuBurada.KatalogService.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace IsubuBurada.KatalogService.Services
{
    public class KategoriService : IKategoriService
    {
        private readonly IMongoCollection<Kategori> _kategoriCollection;
        private readonly MongoDbSettings _databaseSettings;

        private IMapper _mapper;
        public KategoriService(IOptions<MongoDbSettings> databaseSettings,
            IMapper mapper)
        {
            _databaseSettings = databaseSettings.Value;

            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.Database);

            _kategoriCollection = database
                .GetCollection<Kategori>(MongoDbTables.KategoriTableName);
            _mapper = mapper;
        }
        public async Task CreateOrUpdate(CreateOrEditKategoriDto input)
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

        private async Task Update(CreateOrEditKategoriDto input)
        {
            var kategori = _kategoriCollection
                .AsQueryable()
                .Where(x=> x.Id == input.Id)
                .FirstOrDefault();

            _mapper.Map(input, kategori);

            await _kategoriCollection
                .ReplaceOneAsync(Builders<Kategori>.Filter.Eq(x => x.Id, input.Id), kategori);
        }

        private async Task Create(CreateOrEditKategoriDto input)
        {
            var kategori = _mapper.Map<Kategori>(input);
            
            await _kategoriCollection.InsertOneAsync(kategori);
        }

        public async Task Delete(string id)
        {
            await _kategoriCollection
                .DeleteOneAsync(Builders<Kategori>.Filter.Eq(x => x.Id, id));
        }

        public async Task<List<KategoriDto>> GetTumKategoriler()
        {
            var kategoriler = await _kategoriCollection
                .AsQueryable()
                .ToListAsync();

            //var sonuc = kategoriler.Select(x => new KategoriDto
            //{
            //    Id = x.Id,
            //    Ad = x.Ad
            //}).ToList();

            var sonuc = _mapper.Map<List<KategoriDto>>(kategoriler);

            return sonuc;
        }
    }
}
