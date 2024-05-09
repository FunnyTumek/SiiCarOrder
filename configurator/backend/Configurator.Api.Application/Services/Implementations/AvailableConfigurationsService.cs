using Configurator.Api.Dtos.Contracts;
using Configurator.Api.Dtos.Contracts.CarConfigurationParts;

namespace Configurator.Api.Application.Services.Implementations;

public class AvailableConfigurationsService : IAvailableConfigurationsService
{
    private readonly ICachedDtoRetrievalService _dtoRetrievalService;

    public AvailableConfigurationsService(ICachedDtoRetrievalService dtoRetrievalService)
    {
        _dtoRetrievalService = dtoRetrievalService;
    }

    public async Task<IEnumerable<CarConfigurationDto>> GetAvailableConfigurationsAsync()
    {
        var result = await _dtoRetrievalService.RetrieveDtoCollection<CarConfigurationDto>(
            cacheKey: "availableConfigurations",
            requestUri: "/api/configuration/available"
        );
        return result;
    }

    public async Task<IEnumerable<CarBrandDto>> GetAvailableBrandsAsync()
    {
        var result = await _dtoRetrievalService.RetrieveDtoCollection<CarBrandDto>(
            cacheKey: "brands",
            requestUri: "/api/configuration/brand"
        );
        return result;
    }

    public async Task<IEnumerable<CarModelDto>> GetAvailableModelsAsync()
    {
        var result = await _dtoRetrievalService.RetrieveDtoCollection<CarModelDto>(
            cacheKey: "models",
            requestUri: "/api/configuration/model"
        );
        return result;
    }

    public async Task<IEnumerable<CarClassDto>> GetAvailableClassesAsync()
    {
        var result = await _dtoRetrievalService.RetrieveDtoCollection<CarClassDto>(
            cacheKey: "classes",
            requestUri: "/api/configuration/class"
        );
        return result;
    }

    public async Task<IEnumerable<CarEquipmentVersionDto>> GetAvailableEquipmentVersionsAsync()
    {
        var result = await _dtoRetrievalService.RetrieveDtoCollection<CarEquipmentVersionDto>(
            cacheKey: "equipmentVersions",
            requestUri: "/api/configuration/equipmentversion"
        );
        return result;
    }

    public async Task<IEnumerable<CarColorDto>> GetAvailableColorsAsync()
    {
        var result = await _dtoRetrievalService.RetrieveDtoCollection<CarColorDto>(
            cacheKey: "colors",
            requestUri: "/api/configuration/color"
        );
        return result;
    }

    public async Task<IEnumerable<CarInteriorDto>> GetAvailableInteriorsAsync()
    {
        var result = await _dtoRetrievalService.RetrieveDtoCollection<CarInteriorDto>(
            cacheKey: "interiors",
            requestUri: "/api/configuration/interior"
        );
        return result;
    }

    public async Task<IEnumerable<CarAdditionalEquipmentDto>> GetAvailableAdditionalEquipmentAsync()
    {
        var result = await _dtoRetrievalService.RetrieveDtoCollection<CarAdditionalEquipmentDto>(
            cacheKey: "additionalEquipment",
            requestUri: "/api/configuration/additionalequipment"
        );
        return result;
    }

    public async Task<IEnumerable<CarEngineDto>> GetAvailableEnginesAsync()
    {
        var result = await _dtoRetrievalService.RetrieveDto<ICollection<CarEngineDto>>(
            cacheKey: "engines",
            requestUri: "/api/configuration/engine"
        );
        return result;
    }

    public async Task<IEnumerable<CarGearboxDto>> GetAvailableGearboxesAsync()
    {
        var result = await _dtoRetrievalService.RetrieveDtoCollection<CarGearboxDto>(
            cacheKey: "gearboxes",
            requestUri: "/api/configuration/gearbox"
        );
        return result;
    }
}
