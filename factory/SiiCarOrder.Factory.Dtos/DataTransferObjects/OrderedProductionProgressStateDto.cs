using Sii.CarOrder.Contracts.Enums;
using Sii.CarOrder.Contracts.Models;
using SiiCarOrder.Factory.Domain.Entities;

namespace SiiCarOrder.Factory.Dtos.DataTransferObjects
{
    public class OrderedProductionProgressStateDto
    {
        public OrderedProductionProgressStateDto() 
        {

        }

        public OrderedProductionProgressStateDto(OrderedProductionProgressState progressState)
        {
            Date = progressState.Date;
            Information= progressState.Information;
            StateName = ProductionProgressStates.States[progressState.State];
        }

        public string StateName { get; set; }
        public DateTime Date { get; set; }
        public string Information { get; set; }
    }
}
