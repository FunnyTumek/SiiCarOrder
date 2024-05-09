using Microsoft.Extensions.Options;
using StackExchange.Redis;

namespace Configurator.Api.Application.Services.Implementations;

public class RedisCacheService : ICacheService
{
    private readonly IConnectionMultiplexer _redis;

    public TimeSpan DefaultCacheTime { get; }

    public RedisCacheService(IConnectionMultiplexer redis, IOptions<RedisSettings> redisSettings)
    {
        _redis = redis;
        DefaultCacheTime = redisSettings.Value.CacheTime;
    }

    public async Task<string?> GetCachedStringAsync(string key)
    {
        IDatabase cache = _redis.GetDatabase();
        RedisValue value = await cache.StringGetAsync(key);
        return value; // Implicit conversion to `string?` type
    }

    public async Task SetCachedStringAsync(string key, string value, TimeSpan? cacheTime = null)
    {
        cacheTime ??= DefaultCacheTime;
        IDatabase cache = _redis.GetDatabase();
        await cache.StringSetAsync(key, value, cacheTime);
    }
}
