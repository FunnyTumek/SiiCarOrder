using MediatR;
using Sii.Dealer.Core.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sii.Dealer.Core.Application.Commands
{
    public class ConfirmOrderCommand : IRequest
    {
        public int Id { get; set; }
        public bool Accept { get; set; }
        public float Percentage { get; set; }
    }

    public class ConfirmOrderCommandHandler : IRequestHandler<ConfirmOrderCommand>
    {
        private readonly IOrdersApplicationService _ordersApplicationService;
        public ConfirmOrderCommandHandler(IOrdersApplicationService ordersApplicationService)
        {
            _ordersApplicationService = ordersApplicationService;
        }

        public async Task<Unit> Handle(ConfirmOrderCommand request, CancellationToken cancellationToken)
        {
            await _ordersApplicationService.ConfirmOrder(request.Id, request.Accept, request.Percentage);
            return Unit.Value;
        }
    }
}
