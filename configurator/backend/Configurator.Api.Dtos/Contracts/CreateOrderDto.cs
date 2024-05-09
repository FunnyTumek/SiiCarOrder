using System.Text.Json.Serialization;

namespace Configurator.Api.Dtos.Contracts
{
    public class CreateOrderDto
    {
		public CarConfigurationOrderDto Configuration { get; set; }
		public UserDetailsDto Customer { get; set; }

		[JsonConstructor]
		public CreateOrderDto(CarConfigurationOrderDto configuration, UserDetailsDto customer)
		{
			Configuration = configuration;
			Customer = customer;
		}
	}
}
