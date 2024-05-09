namespace Sii.CarOrder.Contracts.Factory
{
    public class ProductionStartedEvent
    {
        public ProductionStartedEvent(int orderId, Guid carVin, DateTime startDate, DateTime plannedFinishDate)
        {
            OrderId = orderId;
            CarVin = carVin;
            StartDate = startDate;
            PlannedFinishDate = plannedFinishDate;
        }

        public int OrderId { get; set; }
        public Guid CarVin { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime PlannedFinishDate { get; set; }
    }
}
