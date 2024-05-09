using MediatR;
using Sii.Dealer.Core.Application.DataTransferObjects;
using Sii.Dealer.Core.Application.Services;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Sii.Dealer.Core.Application.Queries
{
	public class GetPaymentsByOrderQuery : IRequest<IList<PaymentDto>>
	{
		public int Id { get; set; }
		public class GetPeymentsByOrderQueryHandler : IRequestHandler<GetPaymentsByOrderQuery, IList<PaymentDto>>
		{
			private readonly IOrdersApplicationService _ordersApplicationService;
			public GetPeymentsByOrderQueryHandler(IOrdersApplicationService ordersApplicationService)
			{
				_ordersApplicationService = ordersApplicationService;
			}

			public async Task<IList<PaymentDto>> Handle(GetPaymentsByOrderQuery request, CancellationToken cancellationToken)
			{
				return await _ordersApplicationService.GetPaymentsByOrder(request.Id);
			}
		}
		
	}
}
