using MediatR;
using Sii.Dealer.Core.Application.DataTransferObjects;
using Sii.Dealer.Core.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sii.Dealer.Core.Application.Queries
{
	public class CalculatePaymentsByOrderQuery : IRequest<IList<PaymentDto>>
	{
		public int Id { get; set; }
		public float Percentage { get; set; }

		public class CalculatePaymentsByOrderQueryHandler : IRequestHandler<CalculatePaymentsByOrderQuery, IList<PaymentDto>>
		{
			private readonly IOrdersApplicationService _ordersApplicationService;
			public CalculatePaymentsByOrderQueryHandler(IOrdersApplicationService ordersApplicationService)
			{
				_ordersApplicationService = ordersApplicationService;
			}

			public async Task<IList<PaymentDto>> Handle(CalculatePaymentsByOrderQuery request, CancellationToken cancellationToken)
			{
				return await _ordersApplicationService.CalculatePaymentsByOrder(request.Id, request.Percentage);
			}
		}
	}
}
