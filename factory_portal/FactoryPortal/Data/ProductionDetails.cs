using Sii.CarOrder.Contracts.Enums;
namespace FactoryPortal.Data

{
    public class ProductionDetails
    {
        public int FactoryId { get; set; }
        public DateTime PlannedDeliveryDate { get; set; }
        public DateTime CreateDate { get; set; }
        public Guid? Vin { get; set; }
		public ProductionStatus Status { get; set; }
        public int? Progress { get; set; }

	}
}
