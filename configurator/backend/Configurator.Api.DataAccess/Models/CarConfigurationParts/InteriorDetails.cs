using MongoDB.Bson.Serialization.Attributes;

namespace Configurator.Api.DataAccess.Models.CarConfigurationParts
{
    public class InteriorDetails
    {
		public string Code { get; private set; }
		public string Name { get; private set; }
		public decimal Price { get; private set; }

		[BsonConstructor]
		public InteriorDetails(string code, string name)
		{
			Code = code;
			Name = name;
		}
	}
}
