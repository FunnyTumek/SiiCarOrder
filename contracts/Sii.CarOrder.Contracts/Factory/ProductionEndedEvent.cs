namespace Sii.CarOrder.Contracts.Factory
{
    public class ProductionEndedEvent
    {
        public int OrderId { get; set; }
        public Guid CarVin { get; set; }

        public ProductionEndedEvent(int orderId, Guid carVin)
        {
            OrderId = orderId;
            CarVin = carVin;
        }
    }
}
