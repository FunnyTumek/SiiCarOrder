using MediatR;
using Sii.Dealer.Core.Infrastructure.Data;
using Sii.Dealer.ReadModel.Dealer;
using Sii.Dealer.SharedKernel.Sales.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Sii.Dealer.ReadModel.Queries
{
	public class GetAllOrdersQuery : IRequest<IList<OrderListViewModel>>
	{
		public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery, IList<OrderListViewModel>>
		{
			private readonly IOrdersQuery _ordersQuery;
			public GetAllOrdersQueryHandler(IOrdersQuery ordersQuery)
			{
				_ordersQuery= ordersQuery;
			}

			public async Task<IList<OrderListViewModel>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
			{
				return await _ordersQuery.GetOrders();
			}
		}
	}
}
