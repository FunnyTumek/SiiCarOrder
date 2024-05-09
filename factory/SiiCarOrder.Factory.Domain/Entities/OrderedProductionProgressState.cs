using Sii.CarOrder.Contracts.Enums;

namespace SiiCarOrder.Factory.Domain.Entities
{
    public class OrderedProductionProgressState
    {
        public int Id { get; set; }
        public int ProductionId { get; set; }
        public ProductionProgressState State { get; set; }
        public DateTime Date { get; set; }
        public string Information { get; set; }
        public OrderedProduction Production { get; set; }
    }
}
