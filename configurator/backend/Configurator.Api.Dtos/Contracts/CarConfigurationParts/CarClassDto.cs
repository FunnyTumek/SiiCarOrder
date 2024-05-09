using Configurator.Api.Dtos.Contracts.Helpers;

namespace Configurator.Api.Dtos.Contracts.CarConfigurationParts
{
	public class CarClassDto
	{
		public CarClassDto(string code, string name, decimal price)
		{
			Code = code;
			Name = name;
			Price = price;
		}

		[SwaggerSchemaExample("CC01")]
		public string Code { get; set; }

		[SwaggerSchemaExample("City")]
		public string Name { get; set; }

		[SwaggerSchemaExample("2000")]
		public decimal Price { get; set; }
	}
}

