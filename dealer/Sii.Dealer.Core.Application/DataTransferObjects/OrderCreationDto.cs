using Sii.Dealer.Core.Domain.Entities;
using System.ComponentModel.DataAnnotations;


namespace Sii.Dealer.Core.Application.DataTransferObjects
{
    public class OrderCreationDto
    {
		public OrderCreationDto()
		{
		}

		public OrderCreationDto(CarConfigurationDto configuration, CustomerOrderDto customer)
        {
            Configuration = configuration;
            Customer = customer;
        }

        [Required]
        public CarConfigurationDto Configuration { get; set; }

        [Required]
        public CustomerOrderDto Customer { get; set; }
    }
}
