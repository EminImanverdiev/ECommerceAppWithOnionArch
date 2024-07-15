using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using OnionApi.Application.Interfaces.RedisCache;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApi.Infrastructure.RedisCache
{
    public class RedisCacheService : IRedisCacheService
    {
        private readonly IConnectionMultiplexer _connectionMultiplexer;
        private readonly IDatabase _database;
        private readonly RedisCacheSettings _settings;
        public RedisCacheService(IOptions<RedisCacheSettings> options)
        {
            _settings = options.Value;
            var opt = ConfigurationOptions.Parse(_settings.ConnectionString);
            _connectionMultiplexer=ConnectionMultiplexer.Connect(opt);
            _database = _connectionMultiplexer.GetDatabase();
        }
        public async Task<T> GetAsync<T>(string key)
        {
            var value=await _database.StringGetAsync(key);
            if (value.HasValue)
                return JsonConvert.DeserializeObject<T>(value);
            return default;
        }

        public async Task<T> SetAsync<T>(string key, T value, DateTime? expirationTime = null)
        {
            TimeSpan timeSpan=expirationTime.Value-DateTime.UtcNow;
            await _database.StringSetAsync(key,JsonConvert.SerializeObject(value),timeSpan);
        }
    }
}
