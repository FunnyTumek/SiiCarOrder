using Sii.CarOrder.Contracts.Enums;

namespace SiiCarOrder.Factory.Domain.Entities
{
    public class OrderedProduction
    {
        public int Id { get; set; }
        public string BrandCode { get; set; }
        public string ModelCode { get; set; }
        public string EquipmentVersionCode { get; set; }
        public string ClassCode { get; set; }
        public string EngineCode { get; set; }
        public string GearboxCode { get; set; }
        public string ColorCode { get; set; }
        public string InteriorCode { get; set; }
        public DateTime DeliveryDate { get; set; }
        public DateTime CreateDate { get; set; }
        public Guid? Vin { get; set; }
        public ProductionStatus Status { get; set; }
        public int OrderId { get; set; }
        public ICollection<OrderedProductionProgressState> ProgressStates { get; set; }

	}
}
