using Sii.Dealer.SharedKernel.Enums;
using System;

namespace Sii.Dealer.SharedKernel.Sales.ViewModels
{
    public class OrderDetailViewModel
    {
        public int id { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime CreationDate { get; set; }
        public bool AgreementSigned { get; set; }
        public DateTime? AgreementSignedDate { get; set; }
        public DateTime? PlannedDeliveryDate { get; set; }

        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhone { get; set; }

        public string Brand { get; set; }
        public string Model { get; set; }
        public string EquipmentVersion { get; set; }
        public string Class { get; set; }
        public string Engine { get; set; }
        public int EngineType { get; set; }
        public int EnginePower { get; set; }
        public int EngineCapacity { get; set; }
        public int GearboxType { get; set; }
        public int GearboxCount { get; set; }
        public string Color { get; set; }
        public string Interior { get; set; }
    }
}
