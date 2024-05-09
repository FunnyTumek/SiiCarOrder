using Sii.CarOrder.Contracts.Models;

namespace Sii.CarOrder.Contracts.Configuration
{
    public class PlaceOrderConfigurationEvent
    {
		public OrderCustomer customer { get; set; }
        public OrderCarConfiguration carConfiguration { get; set; }

        public PlaceOrderConfigurationEvent(OrderCustomer customer, OrderCarConfiguration carConfiguration)
        {
            this.customer = customer;
            this.carConfiguration = carConfiguration;
        }
    }
}
