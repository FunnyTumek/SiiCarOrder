using Configurator.Api.DataAccess.Models.CarConfigurationParts;
using Configurator.Api.Dtos.Contracts;
using MongoDB.Bson.Serialization.Attributes;

namespace Configurator.Api.DataAccess.Models
{
    public class SavedConfiguration : CarConfiguration
    {
		public string? UserId { get; private set; }

		[BsonConstructor]
		public SavedConfiguration(string id, string? userId, BrandDetails brand, ModelDetails model, EquipmentVersionDetails equipmentVersion, CarClassDetails @class, EngineDetails engine, GearboxDetails gearbox, ColorDetails color, InteriorDetails interior, IEnumerable<AdditionalEquipmentDetails> additionalEquipment, decimal? price)
			: base(id, brand, model, equipmentVersion, @class, engine, gearbox, color, interior, additionalEquipment, price)
		{
			UserId = userId;
		}

		public static SavedConfiguration CreateFromDto(CarConfigurationBaseDto dto, string? userId) => new(
			string.Empty,
			userId,
			new BrandDetails(dto.Brand.Code, dto.Brand.Name),
			new ModelDetails(dto.Model.Code, dto.Model.Name),
			new EquipmentVersionDetails(dto.EquipmentVersion.Code, dto.EquipmentVersion.Name),
			new CarClassDetails(dto.Class.Code, dto.Class.Name),
			new EngineDetails(dto.Engine.Code, dto.Engine.Name, dto.Engine.Type, dto.Engine.Capacity, dto.Engine.Power),
			new GearboxDetails(dto.Gearbox.Code, dto.Gearbox.Type, dto.Gearbox.GearsCount),
			new ColorDetails(dto.Color.Code, dto.Color.Name),
			new InteriorDetails(dto.Interior.Code, dto.Interior.Name),
			dto.AdditionalEquipments.Select(ae => new AdditionalEquipmentDetails(ae.Code, ae.Name)),
			dto.Price
		);
	}
}
