using System;

namespace Sii.Dealer.ReadModel.Models
{
    public class OrderListViewReadModel
    {
        public OrderListViewReadModel(int id, string customerFirstName, string customerLastName, DateTime creationDate, decimal price, string status)
        {
            Id = id;
            CustomerFirstName = customerFirstName;
            CustomerLastName = customerLastName;
            CreationDate = creationDate;
            Price = price;
            Status = status;
        }

        public int Id { get; set; }

        public string CustomerFirstName { get; set; }

        public string CustomerLastName { get; set; }

        public DateTime CreationDate { get; set; }

        public decimal Price { get; set; }

        public string Status { get; set; }
    }
}
