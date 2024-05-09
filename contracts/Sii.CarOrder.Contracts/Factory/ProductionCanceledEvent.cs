
namespace Sii.CarOrder.Contracts.Factory
{
    public class ProductionCanceledEvent
    {
        public int OrderId { get; set; }

        public Guid CarVin { get; set; }

        public string? Reason { get; set; }
    }
}
