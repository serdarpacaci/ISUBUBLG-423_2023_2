using IsubuBurada.SepetService.Models;
using StackExchange.Redis;
using System.Text.Json;

namespace IsubuBurada.SepetService.Services
{
    public class MySepetService : ISepetService
    {
        private readonly RedisService _redisService;
        private readonly IDatabase _redisDatabase;
        public MySepetService(RedisService redisService)
        {
            _redisService = redisService;
            _redisDatabase = _redisService.GetDatabase();
        }

        public async Task<SepetDto> GetUyeSepet(string userId)
        {
            var sonuc =  await _redisDatabase.StringGetAsync(userId);
            
            if (string.IsNullOrEmpty(sonuc))
            {
                return new SepetDto() { UserId = userId };
            }

            var sepet = JsonSerializer.Deserialize<SepetDto>(sonuc);
            
            return sepet;
        }

        public async Task SepetKaydet(SepetDto input)
        {
            var sepetJson = JsonSerializer.Serialize(input);
            
            await _redisDatabase.StringSetAsync(input.UserId, sepetJson);
        }

        public async Task Sil(string userId)
        {
            await _redisDatabase.KeyDeleteAsync(userId);
        }
    }
}
