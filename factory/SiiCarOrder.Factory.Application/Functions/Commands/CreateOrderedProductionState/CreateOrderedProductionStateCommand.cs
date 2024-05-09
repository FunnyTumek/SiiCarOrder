using MediatR;
using SiiCarOrder.Factory.Domain.Entities;
using SiiCarOrder.Factory.Dtos.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiiCarOrder.Factory.Application.Functions.Commands.CreateOrderedProductionState
{
    public class CreateOrderedProductionStateCommand : IRequest<OrderedProductionProgressStateDto>
    {
        public OrderedProductionProgressState ProgressState { get; set; }
    }
}
