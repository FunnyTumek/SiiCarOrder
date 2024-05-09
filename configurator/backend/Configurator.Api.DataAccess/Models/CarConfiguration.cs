using Configurator.Api.DataAccess.Models.CarConfigurationParts;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Configurator.Api.DataAccess.Models
{
    public class CarConfiguration
    {
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string Id { get; private set; }

		public BrandDetails Brand { get; private set; }

		public ModelDetails Model { get; private set; }

		public EquipmentVersionDetails EquipmentVersion { get; private set; }

		public CarClassDetails Class { get; private set; }

		public EngineDetails Engine { get; private set; }

		public GearboxDetails Gearbox { get; private set; }

		public ColorDetails Color { get; private set; }

		public InteriorDetails Interior { get; private set; }

		public IEnumerable<AdditionalEquipmentDetails> AdditionalEquipment { get; private set; }

		public decimal? Price { get; private set; }

		[BsonConstructor]
		public CarConfiguration(string id, BrandDetails brand, ModelDetails model, EquipmentVersionDetails equipmentVersion, CarClassDetails @class, EngineDetails engine, GearboxDetails gearbox, ColorDetails color, InteriorDetails interior, IEnumerable<AdditionalEquipmentDetails> additionalEquipment, decimal? price)
		{
			Id = id;
			Brand = brand;
			Model = model;
			EquipmentVersion = equipmentVersion;
			Class = @class;
			Engine = engine;
			Gearbox = gearbox;
			Color = color;
			Interior = interior;
			AdditionalEquipment = additionalEquipment;
			Price = price;
		}
	}
}
