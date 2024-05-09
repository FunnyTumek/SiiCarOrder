
namespace SiiCarOrder.Factory.Dtos.DataTransferObjects
{
    public class OrderedProductionFeedbackDto
    {
        public int FactoryId { get; set; }
        public DateTime PlannedDeliveryDate { get; set; }

        public OrderedProductionFeedbackDto(int id, DateTime deliveryDate)
        {
            FactoryId = id;
            PlannedDeliveryDate = deliveryDate;
        }
    }
}
