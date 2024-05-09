using Sii.Dealer.SharedKernel.Enums;
using System;

namespace Sii.Dealer.Core.Application.DataTransferObjects
{
    public class PaymentDto
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public PaymentStatus Status { get; set; }
        public DateTime? PaymentDate { get; set; }
    }
}
