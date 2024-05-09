using MongoDB.Bson.Serialization.Attributes;

namespace Configurator.Api.DataAccess.Models.CarConfigurationParts
{
    public class GearboxDetails
    {
		public string Code { get; private set; }
		public string Type { get; private set; }
		public int GearsCount { get; private set; }
		public decimal Price { get; private set; }

		[BsonConstructor]
		public GearboxDetails(string code, string type, int gearsCount)
		{
			Code = code;
			Type = type;
			GearsCount = gearsCount;
		}
	}
}
