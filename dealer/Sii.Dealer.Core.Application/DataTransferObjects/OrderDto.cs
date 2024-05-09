using Sii.Dealer.Core.Domain.Entities;
using Sii.Dealer.SharedKernel.Enums;

namespace Sii.Dealer.Core.Application.DataTransferObjects
{
    public class OrderDto
    {
        public OrderDto()
        {
        }

        public OrderDto(Order order)
        {
            OrderId = order.Id;
            Price = order.Price;
            Status = order.Status;
            Customer = $"{order.Customer.FirstName} {order.Customer.LastName}";
        }

        public int OrderId { get; set; }

        public decimal Price { get; set; }

        public OrderStatus Status { get; set; }

        public string Customer { get; set; }
    }
}
