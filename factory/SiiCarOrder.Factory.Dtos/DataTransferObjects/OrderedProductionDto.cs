using Sii.CarOrder.Contracts.Enums;
using SiiCarOrder.Factory.Domain.Entities;

namespace SiiCarOrder.Factory.Dtos.DataTransferObjects
{
    public class OrderedProductionDto
    {
        public OrderedProductionDto()
        {
        }

        public OrderedProductionDto(OrderedProduction orderedProduction)
        {
            FactoryId = orderedProduction.Id;
            BrandCode = orderedProduction.BrandCode;
            ModelCode = orderedProduction.ModelCode;
            EquipmentVersionCode = orderedProduction.EquipmentVersionCode;
            ClassCode = orderedProduction.ClassCode;
            EngineCode = orderedProduction.EngineCode;
            GearboxCode = orderedProduction.GearboxCode;
            ColorCode = orderedProduction.ColorCode;
            InteriorCode = orderedProduction.InteriorCode;
            PlannedDeliveryDate = orderedProduction.DeliveryDate;
            CreateDate = orderedProduction.CreateDate;
            Vin = orderedProduction.Vin;
            Status = orderedProduction.Status;
            OrderId= orderedProduction.OrderId;
        }
        public int FactoryId { get; set; }
        public string BrandCode { get; set; }
        public string ModelCode { get; set; }
        public string EquipmentVersionCode { get; set; }
        public string ClassCode { get; set; }
        public string EngineCode { get; set; }
        public string GearboxCode { get; set; }
        public string ColorCode { get; set; }
        public string InteriorCode { get; set; }
        public DateTime PlannedDeliveryDate { get; set; }
        public ProductionStatus Status { get; set; }
        public DateTime CreateDate { get; set; }
        public Guid? Vin { get; set; }
        public int OrderId { get; set; }
    }
}
