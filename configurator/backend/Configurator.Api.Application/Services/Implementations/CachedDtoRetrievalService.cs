using System.Net.Http.Json;
using System.Text.Json;

namespace Configurator.Api.Application.Services.Implementations;

public class CachedDtoRetrievalService : ICachedDtoRetrievalService
{
    private readonly ICacheService _cacheService;
    private readonly HttpClient _httpClient;

    public CachedDtoRetrievalService(ICacheService cacheService, IHttpClientFactory httpClientFactory)
    {
        _cacheService = cacheService;
        _httpClient = httpClientFactory.CreateClient("Dealer.Api");
    }

    public async Task<TDto> RetrieveDto<TDto>(string cacheKey, string requestUri)
    {
        string? cachedValue = await _cacheService.GetCachedStringAsync(cacheKey);
        TDto? result = default;
        if (cachedValue is not null)
        {
            result = JsonSerializer.Deserialize<TDto>(cachedValue);
        }
        if (result is null)
        {
            result = await _httpClient.GetFromJsonAsync<TDto>(requestUri)
                ?? throw new JsonException("Received null from Dealer.Api");
            await _cacheService.SetCachedStringAsync(cacheKey, JsonSerializer.Serialize(result));
        }
        return result;
    }

    public async Task<ICollection<TDto>> RetrieveDtoCollection<TDto>(string cacheKey, string requestUri)
    {
        return await RetrieveDto<ICollection<TDto>>(cacheKey, requestUri);
    }
}
