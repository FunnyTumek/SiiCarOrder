using MongoDB.Bson.Serialization.Attributes;

namespace Configurator.Api.DataAccess.Models.CarConfigurationParts
{
    public class EngineDetails
    {
		public string Code { get; private set; }
		public string Name { get; private set; }
		public string Type { get; private set; }
		public int Capacity { get; private set; }
		public int Power { get; private set; }
		public decimal Price { get; private set; }

		[BsonConstructor]
		public EngineDetails(string code, string name, string type, int capacity, int power)
		{
			Code = code;
			Name = name;
			Type = type;
			Capacity = capacity;
			Power = power;
		}
	}
}
