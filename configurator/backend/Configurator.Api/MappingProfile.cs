using AutoMapper;
using Configurator.Api.DataAccess.Models;
using Configurator.Api.DataAccess.Models.CarConfigurationParts;
using Configurator.Api.Dtos.Contracts;
using Configurator.Api.Dtos.Contracts.CarConfigurationParts;

namespace Configurator.Api;

public class MappingProfile : Profile
{
	public MappingProfile()
	{
		CreateMap<BrandDetails, CarBrandDto>();
		CreateMap<ModelDetails, CarModelDto>();
		CreateMap<EquipmentVersionDetails, CarEquipmentVersionDto>();
		CreateMap<CarClassDetails, CarClassDto>();
		CreateMap<EngineDetails, CarEngineDto>();
		CreateMap<GearboxDetails, CarGearboxDto>();
		CreateMap<ColorDetails, CarColorDto>();
		CreateMap<InteriorDetails, CarInteriorDto>();
		CreateMap<AdditionalEquipmentDetails, CarAdditionalEquipmentDto>();
		CreateMap<SavedConfiguration, CarConfigurationDto>();
		CreateMap<AvailableConfiguration, CarConfigurationDto>();
	}
}
