using Ambev.DeveloperEvaluation.Domain.Services;
using StackExchange.Redis;
using System.Text.Json;

namespace Ambev.DeveloperEvaluation.WebApi.Services
{
    public class RedisCacheService : IRedisCacheService
    {
        private readonly IDatabase _db;
        private readonly IConnectionMultiplexer _connection;


        public RedisCacheService(IConnectionMultiplexer connection)
        {
            _db = connection.GetDatabase();
            _connection = connection;
        }

        public async Task<T?> GetAsync<T>(string key)
        {
            var value = await _db.StringGetAsync(key);
            return value.HasValue ? JsonSerializer.Deserialize<T>(value) : default;
        }

        public async Task SetAsync<T>(string key, T data, TimeSpan? expiry = null)
        {
            var json = JsonSerializer.Serialize(data);
            await _db.StringSetAsync(key, json, expiry ?? TimeSpan.FromMinutes(5));
        }
        public async Task RemoveByPrefixAsync(string prefix)
        {
            var endpoints = _connection.GetEndPoints();
            var server = _connection.GetServer(endpoints.First());

            var keys = server.Keys(pattern: $"{prefix}*").ToArray();
            foreach (var key in keys)
            {
                await _db.KeyDeleteAsync(key);
            }
        }
    }
}
