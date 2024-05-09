using Configurator.Api.Dtos.Contracts.CarConfigurationParts;
using Configurator.Api.Dtos.Contracts.Helpers;
using System.Text.Json.Serialization;

namespace Configurator.Api.Dtos.Contracts
{
    public class CarConfigurationDto : CarConfigurationBaseDto
	{
		[JsonConstructor]
		public CarConfigurationDto(int id, CarBrandDto brand, CarModelDto model, CarEquipmentVersionDto equipmentVersion, CarClassDto @class, CarEngineDto engine, CarGearboxDto gearbox, CarColorDto color, CarInteriorDto interior, decimal price, ICollection<CarAdditionalEquipmentDto> additionalEquipments)
			: base(brand, model, equipmentVersion, @class, engine, gearbox, color, interior, price, additionalEquipments)
		{
			Id = id;
		}

		[SwaggerSchemaExample("1")]
		public int Id { get; set; }
	}
}
