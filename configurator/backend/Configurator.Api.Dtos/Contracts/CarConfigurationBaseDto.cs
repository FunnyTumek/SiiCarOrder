using Configurator.Api.Dtos.Contracts.CarConfigurationParts;
using Configurator.Api.Dtos.Contracts.Helpers;
using System.Text.Json.Serialization;

namespace Configurator.Api.Dtos.Contracts
{
    public class CarConfigurationBaseDto
    {
		[JsonConstructor]
		public CarConfigurationBaseDto(CarBrandDto brand, CarModelDto model, CarEquipmentVersionDto equipmentVersion, CarClassDto @class, CarEngineDto engine, CarGearboxDto gearbox, CarColorDto color, CarInteriorDto interior, decimal price, ICollection<CarAdditionalEquipmentDto> additionalEquipments)
		{
			Brand = brand;
			Model = model;
			EquipmentVersion = equipmentVersion;
			Class = @class;
			Engine = engine;
			Gearbox = gearbox;
			Color = color;
			Interior = interior;
			AdditionalEquipments = additionalEquipments;
			Price = price;
		}

		public CarBrandDto Brand { get; set; }

		public CarModelDto Model { get; set; }

		public CarEquipmentVersionDto EquipmentVersion { get; set; }

		public CarClassDto Class { get; set; }

		public CarEngineDto Engine { get; set; }

		public CarGearboxDto Gearbox { get; set; }

		public CarColorDto Color { get; set; }

		public CarInteriorDto Interior { get; set; }

		public ICollection<CarAdditionalEquipmentDto> AdditionalEquipments { get; set; }

		[SwaggerSchemaExample("129999.99")]
		public decimal Price { get; set; }
	}
}
