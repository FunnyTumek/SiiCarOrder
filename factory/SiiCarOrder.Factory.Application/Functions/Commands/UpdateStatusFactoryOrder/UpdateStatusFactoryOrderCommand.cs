using MediatR;
using Sii.CarOrder.Contracts.Enums;

namespace SiiCarOrder.Factory.Application.Functions.Commands.UpdateStatusFactoryOrder
{
    public class UpdateStatusFactoryOrderCommand : IRequest
    {
        public int OrderId { get; set; }
        public ProductionStatus ProductionStatus { get; set; }
    }
}
