using System;
using System.Collections.Generic;
using System.Linq;
using Sii.Dealer.Core.Base.Entities;
using Sii.Dealer.Core.Domain.ValueObjects;
using Sii.Dealer.SharedKernel.Enums;

namespace Sii.Dealer.Core.Domain.Entities
{
    public class Order : AggregateRoot<int>
    {
        private readonly List<OrderComment> comments = new();
        private readonly List<Payment> payments = new();

        public static Order Create(CarConfiguration configuration, decimal price, Customer customer)
        {
            if (configuration is null) throw new ArgumentException("Missing configuration", nameof(configuration));
            if (customer is null) throw new ArgumentException("Missing customer", nameof(customer));
            if (price <= 0) throw new ArgumentException("Invalid price", nameof(price));

            return new()
            {
                Configuration = configuration,
                Customer = customer,
                Price = price,
                CreationDate = DateTime.Now,
                Status = OrderStatus.Created,
                AgreementIsSigned = false
            };
        }

        private Order()
        {
        }

        #region Properties

        public virtual CarConfiguration Configuration { get; private set; }

        public Customer Customer { get; private set; }

        public DateTime CreationDate { get; private set; }

        public DateTime? PlannedDeliveryDate { get; private set; }

        public DateTime? ReleaseDate { get; private set; }

        public bool AgreementIsSigned { get; private set; }

        public decimal Price { get; private set; }

        public OrderStatus Status { get; private set; }

        public IReadOnlyCollection<OrderComment> Comments { get => comments.AsReadOnly(); }

        public decimal? Discount;

        public IReadOnlyCollection<Payment> Payments { get => payments.AsReadOnly(); }

        public DateTime? AgreementSignedDate { get; private set; }

        public int FactoryId { get; private set; }
        public Guid? CarVin { get; private set; }

        public DateTime? ProductionStartDate { get; private set; }

        #endregion

        public void ApplyDiscount(decimal discount)
        {
            if (discount < 0) throw new ArgumentException("Wrong discount value.", nameof(discount));
            if (discount >= Price) throw new ArgumentException("Wrong discount value", nameof(discount));
            if (Status != OrderStatus.Created) throw new Exception($"Applying discount is available only for order with {OrderStatus.Created} status.");
        }

        public void ConfirmOrderAndCreatePaymentsUsingPercentages(float percentage)
        {
            if (Status != OrderStatus.Created) throw new Exception("Can't confirm order");
            if (percentage <= 0 || percentage >= 100) throw new Exception("Wrong amount");

            decimal advance = (this.Price * (Convert.ToDecimal(percentage) / 100));
            decimal RemainderOfAmount = this.Price - advance;

            var AdvanceAmount = new Payment(this, advance);
            var BalanceOfAmount = new Payment(this, RemainderOfAmount);

            this.payments.Add(AdvanceAmount);
            this.payments.Add(BalanceOfAmount);

            Status = OrderStatus.Confirmed;
            AgreementIsSigned = true;
            AgreementSignedDate = DateTime.Now;
        }

        public List<Payment> CalculatePayments(float percentage)
        {
            List<Payment> payments = new();

            decimal advance = (this.Price * (Convert.ToDecimal(percentage) / 100));
            decimal RemainderOfAmount = this.Price - advance;

            var AdvanceAmount = new Payment(this, advance);
            var BalanceOfAmount = new Payment(this, RemainderOfAmount);

            payments.Add(AdvanceAmount);
            payments.Add(BalanceOfAmount);

            return payments;
        }

        public void UpdatePlannedDeliveryDate(DateTime plannedDeliveryDate)
        {
            if (Status != OrderStatus.Confirmed) throw new Exception("Can't define planned delivery date for closed or not confirmed orders");

            PlannedDeliveryDate = plannedDeliveryDate;
        }

        public void ComplitedOrder(DateTime releaseDate)
        {
            ReleaseDate = releaseDate;
            Status = OrderStatus.Finished;
        }

        public void CancelOrder()
        {
            if (Status == OrderStatus.Finished) throw new Exception("Can't reject closed order.");

            Status = OrderStatus.Canceled;
        }

        public void ConfirmPayment(Payment payment)
        {
            if (Status is not OrderStatus.Confirmed and not OrderStatus.ReadyToProduction and not OrderStatus.Production and not OrderStatus.Produced)
            {
                throw new InvalidOperationException("Order did not have a correct status.");
            }
            if (AgreementIsSigned == false) throw new Exception("Agreement has to signed.");

            payment.MarkDateAndStatusToPaid();

            SetPaidStatus();
        }

        public void SetPaidStatus()
        {
            var paidPaymentsCount = payments.Where(payment => payment.Status == PaymentStatus.Paid).Count();
            if (paidPaymentsCount == payments.Count())
            {
                Status = OrderStatus.Paid;
            }
            else if (paidPaymentsCount > 0)
            {
                Status = OrderStatus.ReadyToProduction;
            }
        }

        public void AddComment(string comment)
        {
            this.comments.Add(new OrderComment(comment, this));
        }

        public void SetStatusProduction(Order order)
        {
            if (order.Status == OrderStatus.Paid || order.Status == OrderStatus.ReadyToProduction)
            {
                if (order.AgreementIsSigned == true)
                {
                    order.Status = OrderStatus.Production;
                }
                else throw new Exception("Agreement has to signed.");
            }
            else throw new Exception("Incorrect status.");
        }

        public void SetPlannedDeliveryDate(int factoryId, DateTime? dateTime)
        {
            PlannedDeliveryDate = dateTime;
            FactoryId = factoryId;
        }

        public void SetVinDuringTheStartOfProduction(Guid carVin, DateTime productionStartDate, DateTime plannedDeliveryDate)
        {
            CarVin = carVin;
            Status = OrderStatus.Production;
            PlannedDeliveryDate = plannedDeliveryDate;
            ProductionStartDate = productionStartDate;
        }

        public void UpdateOrderStatus(OrderStatus status)
        {
            Status = status;
		}
    }
}
