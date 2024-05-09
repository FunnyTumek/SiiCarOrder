using Configurator.Api.Dtos.Contracts.Helpers;

namespace Configurator.Api.Dtos.Contracts.CarConfigurationParts
{
	public class CarModelDto
	{
		public CarModelDto(string code, string name, decimal price)
		{
			Code = code;
			Name = name;
			Price = price;
		}

		[SwaggerSchemaExample("MC01")]
		public string Code { get; set; }

		[SwaggerSchemaExample("Model S")]
		public string Name { get; set; }

		[SwaggerSchemaExample("2000")]
		public decimal Price { get; set; }
	}
}

