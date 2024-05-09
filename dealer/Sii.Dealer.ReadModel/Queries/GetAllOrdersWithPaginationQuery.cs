using MediatR;
using Microsoft.EntityFrameworkCore;
using Sii.Dealer.Core.Infrastructure.Data;
using Sii.Dealer.ReadModel.Dealer;
using Sii.Dealer.SharedKernel.Sales.ViewModels;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Sii.Dealer.ReadModel.Queries
{
	public class GetAllOrdersWithPaginationQuery : IRequest<PaginatedViewModel<OrderListViewModel>>
	{
		public int PageIndex { get; set; } = 0;
		public int Pagesize { get; set; } = 10;
		public class GetAllOrdersWithPaginationQueryHandler : IRequestHandler<GetAllOrdersWithPaginationQuery, PaginatedViewModel<OrderListViewModel>>
		{
			private readonly IOrdersQuery _ordersQuery;
			public GetAllOrdersWithPaginationQueryHandler(IOrdersQuery ordersQuery)
			{
				_ordersQuery = ordersQuery;
			}

			public async Task<PaginatedViewModel<OrderListViewModel>> Handle(GetAllOrdersWithPaginationQuery request, CancellationToken cancellationToken)
			{
				return await _ordersQuery.GetOrders(request.PageIndex, request.Pagesize);
			}
		}
	}
}
