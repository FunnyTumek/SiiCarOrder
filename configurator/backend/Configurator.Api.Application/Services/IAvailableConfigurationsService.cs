using Configurator.Api.Dtos.Contracts;
using Configurator.Api.Dtos.Contracts.CarConfigurationParts;

namespace Configurator.Api.Application.Services
{
    public interface IAvailableConfigurationsService
    {
        Task<IEnumerable<CarConfigurationDto>> GetAvailableConfigurationsAsync();
        Task<IEnumerable<CarBrandDto>> GetAvailableBrandsAsync();
        Task<IEnumerable<CarModelDto>> GetAvailableModelsAsync();
        Task<IEnumerable<CarClassDto>> GetAvailableClassesAsync();
        Task<IEnumerable<CarEquipmentVersionDto>> GetAvailableEquipmentVersionsAsync();
        Task<IEnumerable<CarColorDto>> GetAvailableColorsAsync();
        Task<IEnumerable<CarInteriorDto>> GetAvailableInteriorsAsync();
        Task<IEnumerable<CarAdditionalEquipmentDto>> GetAvailableAdditionalEquipmentAsync();
        Task<IEnumerable<CarEngineDto>> GetAvailableEnginesAsync();
        Task<IEnumerable<CarGearboxDto>> GetAvailableGearboxesAsync();
    }
}