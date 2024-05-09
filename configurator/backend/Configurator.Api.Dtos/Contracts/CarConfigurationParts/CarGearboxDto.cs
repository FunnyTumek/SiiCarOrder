using Configurator.Api.Dtos.Contracts.Helpers;

namespace Configurator.Api.Dtos.Contracts.CarConfigurationParts
{
	public class CarGearboxDto
	{
		public CarGearboxDto(string code, string type, int gearsCount, decimal price)
		{
			Code = code;
			Type = type;
			GearsCount = gearsCount;
			Price = price;
		}

		[SwaggerSchemaExample("GC01")]
		public string Code { get; set; }

		[SwaggerSchemaExample("manual")]
		public string Type { get; set; }

		[SwaggerSchemaExample("5")]
		public int GearsCount { get; set; }

		[SwaggerSchemaExample("2000")]
		public decimal Price { get; set; }
	}
}

