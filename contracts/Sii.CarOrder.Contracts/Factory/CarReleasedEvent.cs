namespace Sii.CarOrder.Contracts.Factory
{
    public class CarReleasedEvent
    {
        public int OrderId { get; set; }

        public CarReleasedEvent(int orderId)
        {
            OrderId = orderId;
        }
    }
}
