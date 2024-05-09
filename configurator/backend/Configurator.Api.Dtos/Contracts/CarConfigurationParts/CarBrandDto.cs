using Configurator.Api.Dtos.Contracts.Helpers;

namespace Configurator.Api.Dtos.Contracts.CarConfigurationParts
{
    public class CarBrandDto
    {
        public CarBrandDto(string code, string name, decimal price)
        {
            Code = code;
            Name = name;
            Price = price;
        }
        [SwaggerSchemaExample("BC01")]
        public string Code
        {
            get; set;
        }
        [SwaggerSchemaExample("Sii")]
        public string Name
        {
            get; set;
        }
        [SwaggerSchemaExample("2000")]
        public decimal Price
        {
            get; set;
        }
    }
}

