using AutoMapper;
using Sii.Dealer.Core.Application.DataTransferObjects;
using Sii.Dealer.Core.Domain.Entities;
using Sii.Dealer.Core.Domain.Entities.CarConfigurationEntities;

namespace Sii.Dealer.Core.Infrastructure.Mappings;

public class MappingProfile : Profile
{
	public MappingProfile()
	{
		CreateMap<Brand, BrandDto>();
		CreateMap<Model, ModelDto>();
		CreateMap<Color, ColorDto>();
		CreateMap<CarClass, CarClassDto>();
		CreateMap<Engine, EngineDto>();
		CreateMap<Gearbox,GearboxDto>();
		CreateMap<Interior, InteriorDto>();
		CreateMap<Model,ModelDto>();
		CreateMap<EquipmentVersion, EquipmentVersionDto>();
		CreateMap<AdditionalEquipment, AdditionalEquipmentDto>();
		CreateMap<Payment, PaymentDto>();
		CreateMap<AvailableCarConfiguration, AvailableCarConfigurationDto>();
	}
}