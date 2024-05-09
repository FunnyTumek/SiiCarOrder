namespace Configurator.Api.Application.Services;

public interface ICacheService
{
    public Task<string?> GetCachedStringAsync(string key);
    public Task SetCachedStringAsync(string key, string value, TimeSpan? cacheTime = null);
}
