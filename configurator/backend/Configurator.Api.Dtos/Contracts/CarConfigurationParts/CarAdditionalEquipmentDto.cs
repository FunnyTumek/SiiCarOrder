using Configurator.Api.Dtos.Contracts.Helpers;

namespace Configurator.Api.Dtos.Contracts.CarConfigurationParts
{
    public class CarAdditionalEquipmentDto
    {
		public CarAdditionalEquipmentDto(string code, string name, decimal price)
		{
			Code = code;
			Name = name;
			Price = price;
		}

		[SwaggerSchemaExample("AE01")]
		public string Code { get; set; }

		[SwaggerSchemaExample("comfort seat package")]
		public string Name { get; set; }

		[SwaggerSchemaExample("2000")]
		public decimal Price { get; set; }
	}
}
