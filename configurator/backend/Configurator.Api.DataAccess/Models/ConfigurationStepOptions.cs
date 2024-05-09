using Configurator.Api.DataAccess.Models.CarConfigurationParts;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Configurator.Api.DataAccess.Models
{
    public class ConfigurationStepOptions
    {
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string Id { get; private set; }

		public IEnumerable<BrandDetails> Brands { get; private set; }

		public IEnumerable<ModelDetails> Models { get; private set; }

		public IEnumerable<EquipmentVersionDetails> EquipmentVersions { get; private set; }

		public IEnumerable<CarClassDetails> Classes { get; private set; }

		public IEnumerable<EngineDetails> Engines { get; private set; }

		public IEnumerable<GearboxDetails> Gearboxes { get; private set; }

		public IEnumerable<ColorDetails> Colors { get; private set; }

		public IEnumerable<InteriorDetails> Interiors { get; private set; }

		public IEnumerable<AdditionalEquipmentDetails> AdditionalEquipments { get; private set; }

		[BsonConstructor]
		public ConfigurationStepOptions(string id, IEnumerable<BrandDetails> brands, IEnumerable<ModelDetails> models, IEnumerable<EquipmentVersionDetails> equipmentVersions, IEnumerable<CarClassDetails> classes, IEnumerable<EngineDetails> engines, IEnumerable<GearboxDetails> gearboxes, IEnumerable<ColorDetails> colors, IEnumerable<InteriorDetails> interiors, IEnumerable<AdditionalEquipmentDetails> additionalEquipments)
		{
			Id = id;
			Brands = brands;
			Models = models;
			EquipmentVersions = equipmentVersions;
			Classes = classes;
			Engines = engines;
			Gearboxes = gearboxes;
			Colors = colors;
			Interiors = interiors;
			AdditionalEquipments = additionalEquipments;
		}
	}
}
