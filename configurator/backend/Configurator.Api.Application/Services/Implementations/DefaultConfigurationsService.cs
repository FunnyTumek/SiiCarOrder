using Configurator.Api.Dtos.Contracts;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace Configurator.Api.Application.Services.Implementations
{
    public class DefaultConfigurationsService : IDefaultConfigurationsService
    {
        private readonly IJsonFileService _jsonFileService;
        private readonly IOptions<DefaultCarConfigurationSettings> _configurationOptions;

        public DefaultConfigurationsService(IJsonFileService jsonFileService, IOptions<DefaultCarConfigurationSettings> options)
        {
            _jsonFileService = jsonFileService;
            _configurationOptions = options;
        }

        public async Task<CarConfigurationDto> GetDataForDefaultConfigurationAsync()
        {
            string fileName = _configurationOptions.Value.FileName;
            string json = await _jsonFileService.ReadFile(fileName);
            CarConfigurationDto? result = JsonSerializer.Deserialize<CarConfigurationDto>(json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );
            if (result is null)
                throw new SystemException($"Failed to deserialize configuration data from file");
            return result;
        }
    }
}