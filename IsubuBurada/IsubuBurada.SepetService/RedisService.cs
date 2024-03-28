using IsubuBurada.SepetService.Models;
using Microsoft.Extensions.Options;
using StackExchange.Redis;

namespace IsubuBurada.SepetService
{
    public class RedisService
    {
        private readonly int port;
        private readonly string host;

        private ConnectionMultiplexer _connectionMultiplexer;

        public RedisService(IOptions<RedisSettings> options)
        {
            port = options.Value.Port;
            host = options.Value.Host;

            Baglan();
        }

        public void Baglan()
        {
            var configuration = $"{host}:{port}";

            _connectionMultiplexer = ConnectionMultiplexer.Connect(configuration);
        }

        public IDatabase GetDatabase(int id = 1)
        {
            return _connectionMultiplexer.GetDatabase(id);
        }


    }
}
