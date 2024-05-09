using Configurator.Api.Dtos.Contracts.Helpers;

namespace Configurator.Api.Dtos.Contracts.CarConfigurationParts
{
	public class CarInteriorDto
	{
		public CarInteriorDto(string code, string name, decimal price)
		{
			Code = code;
			Name = name;
			Price = price;
		}

		[SwaggerSchemaExample("IC01")]
		public string Code { get; set; }

		[SwaggerSchemaExample("black leather")]
		public string Name { get; set; }

		[SwaggerSchemaExample("2000")]
		public decimal Price { get; set; }
	}
}

