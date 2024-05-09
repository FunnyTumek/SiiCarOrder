using Configurator.Api.Dtos.Contracts.Helpers;

namespace Configurator.Api.Dtos.Contracts.CarConfigurationParts
{
	public class CarEngineDto
	{
		public CarEngineDto(string code, string name, string type, int capacity, int power, decimal price)
		{
			Code = code;
			Name = name;
			Type = type;
			Capacity = capacity;
			Power = power;
			Price = price;
		}

		[SwaggerSchemaExample("EC01")]
		public string Code { get; set; }

		[SwaggerSchemaExample("1.0 TSI")]
		public string Name { get; set; }

		[SwaggerSchemaExample("Petrol")]
		public string Type { get; set; }

		[SwaggerSchemaExample("998")]
		public int Capacity { get; set; }

		[SwaggerSchemaExample("75")]
		public int Power { get; set; }

		[SwaggerSchemaExample("2000")]
		public decimal Price { get; set; }
	}
}

