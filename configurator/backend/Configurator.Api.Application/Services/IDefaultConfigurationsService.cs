using Configurator.Api.Dtos.Contracts;

namespace Configurator.Api.Application.Services
{
    public interface IDefaultConfigurationsService
    {
        Task<CarConfigurationDto> GetDataForDefaultConfigurationAsync();
    }
}