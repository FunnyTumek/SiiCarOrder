using Configurator.Api.DataAccess.Models.CarConfigurationParts;
using MongoDB.Bson.Serialization.Attributes;

namespace Configurator.Api.DataAccess.Models
{
    public class AvailableConfiguration : CarConfiguration
    {
        [BsonConstructor]
        public AvailableConfiguration(string id, BrandDetails brand, ModelDetails model, EquipmentVersionDetails equipmentVersion, CarClassDetails @class, EngineDetails engine, GearboxDetails gearbox, ColorDetails color, InteriorDetails interior, IEnumerable<AdditionalEquipmentDetails> additionalEquipment, decimal? price)
    : base(id, brand, model, equipmentVersion, @class, engine, gearbox, color, interior, additionalEquipment, price)
        {
        }
    }
}
