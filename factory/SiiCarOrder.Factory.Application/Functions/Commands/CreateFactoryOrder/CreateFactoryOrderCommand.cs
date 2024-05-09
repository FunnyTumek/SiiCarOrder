using MediatR;
using Sii.CarOrder.Contracts.Enums;
using SiiCarOrder.Factory.Dtos.DataTransferObjects;

namespace SiiCarOrder.Factory.Application.Functions.Commands.CreateFactoryOrder
{
    public class CreateFactoryOrderCommand : IRequest<OrderedProductionDto>
    {
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
        public int OrderId { get; set; }
    }
}
