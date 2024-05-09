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
    public class ConfirmPaymentCommand : IRequest
    {
        public int Id { get; set; }
        public int PaymentId { get; set; }
    }

    public class ConfirmPaymentCommandHandler : IRequestHandler<ConfirmPaymentCommand>
    {
        private readonly IOrdersApplicationService _ordersApplicationService;
        public ConfirmPaymentCommandHandler(IOrdersApplicationService ordersApplicationService)
        {
            _ordersApplicationService = ordersApplicationService;
        }

        public async Task<Unit> Handle(ConfirmPaymentCommand request, CancellationToken cancellationToken)
        {
            await _ordersApplicationService.ConfirmPayment(request.Id, request.PaymentId);
            return Unit.Value;
        }
    }
}
