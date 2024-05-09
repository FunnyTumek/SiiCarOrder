using MongoDB.Bson.Serialization.Attributes;

namespace Configurator.Api.DataAccess.Models.CarConfigurationParts
{
    public class AdditionalEquipmentDetails
    {
		public string Code { get; private set; }
		public string Name { get; private set; }
		public decimal Price { get; private set; }

		[BsonConstructor]
		public AdditionalEquipmentDetails(string code, string name)
		{
			Code = code;
			Name = name;
		}
	}
}
