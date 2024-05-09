namespace Sii.CarOrder.Contracts.Dealer
{
    public class CollectOrderEvent
    {
        public int OrderId { get; }

        public CollectOrderEvent(int orderId)
        {
            OrderId = orderId;
        }
    }
}
