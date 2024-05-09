using System;
using Sii.Dealer.SharedKernel.Enums;

namespace Sii.Dealer.SharedKernel.Sales.ViewModels
{
    public class OrderListViewModel
    {
        public int Id { get; set; }

        public string? CustomerFirstName { get; set; }

        public string? CustomerLastName { get; set; }

        public DateTime CreationDate { get; set; }

        public decimal Price { get; set; }

        public OrderStatus Status { get; set; }
    }
}
