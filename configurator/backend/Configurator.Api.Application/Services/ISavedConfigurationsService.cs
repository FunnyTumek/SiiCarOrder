using Configurator.Api.Dtos.Contracts;

namespace Configurator.Api.Application.Services
{
    public interface ISavedConfigurationsService
    {
        Task<string> SaveAsync(CarConfigurationBaseDto request);
        Task<CarConfigurationDto?> GetByIdAsync(string id);
    }
}