using Configurator.Api.Dtos.Contracts.Helpers;

namespace Configurator.Api.Dtos.Contracts.CarConfigurationParts
{
	public class CarEquipmentVersionDto
	{
		public CarEquipmentVersionDto(string code, string name, decimal price)
		{
			Code = code;
			Name = name;
			Price = price;
		}

		[SwaggerSchemaExample("EV01")]
		public string Code { get; set; }

		[SwaggerSchemaExample("Basic")]
		public string Name { get; set; }

		[SwaggerSchemaExample("2000")]
		public decimal Price { get; set; }
	}
}

