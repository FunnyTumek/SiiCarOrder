using Sii.Dealer.Core.Base.Entities;
using Sii.Dealer.SharedKernel.Enums;
using System;

namespace Sii.Dealer.Core.Domain.Entities
{
    public class Payment
    {
        #region Properties
        public int Id { get; private set; }
        public int OrderId { get; private set; }
        public Order Order { get; private set; }
        public decimal Price { get; private set; }
        public PaymentStatus Status { get; private set; }
        public DateTime? PaymentDate { get; private set; }

        #endregion

        public Payment(Order order, decimal amount)
        {
            Price = amount;
            Order = order;
            PaymentDate = null;
            Status = PaymentStatus.Created;
        }

        public void MarkDateAndStatusToPaid()
        {
            if (Status != PaymentStatus.Created) throw new Exception("Incorrect status.");
            
            Status = PaymentStatus.Paid;
            PaymentDate = DateTime.Now;
        }

        private Payment()
        {
        }
    }
}
