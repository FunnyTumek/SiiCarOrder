namespace Configurator.Api.Application.Services;

public interface ICachedDtoRetrievalService
{
    Task<TDto> RetrieveDto<TDto>(string cacheKey, string requestUri);
    Task<ICollection<TDto>> RetrieveDtoCollection<TDto>(string cacheKey, string requestUri);
}
