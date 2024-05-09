using Sii.Dealer.SharedKernel.Enums;
using System;

namespace Sii.Dealer.ReadModel.Models;

public class OrderDetailInfoReadModel
{
    public OrderDetailInfoReadModel(int id, decimal price, OrderStatus status, decimal discount, DateTime creationDate, bool agreementSigned, DateTime? agreementSignedDate, DateTime? plannedDeliveryDate)
    {
        this.id = id;
        Price = price;
        Status = status;
        Discount = discount;
        CreationDate = creationDate;
        AgreementSigned = agreementSigned;
        AgreementSignedDate = agreementSignedDate;
        PlannedDeliveryDate = plannedDeliveryDate;
    }

    public int id { get; set; }
    public decimal Price { get; set; }
    public decimal Discount { get; set; }
    public DateTime CreationDate { get; set; }
    public OrderStatus Status { get; set; }
    public bool AgreementSigned { get; set; }
    public DateTime? AgreementSignedDate { get; set; }
    public DateTime? PlannedDeliveryDate { get; set; }
}
