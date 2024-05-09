using MediatR;
using Sii.Dealer.ReadModel.Dealer;
using Sii.Dealer.ReadModel.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Sii.Dealer.ReadModel.Queries
{
	public class GetOrderByIdQuery : IRequest<OrderDetailReadModel>
	{
		public int Id { get; set; }
		public class GetOrderByIdQeuryHandler : IRequestHandler<GetOrderByIdQuery, OrderDetailReadModel>
		{
			private readonly IOrdersQuery _ordersQuery;
			public GetOrderByIdQeuryHandler(IOrdersQuery ordersQuery)
			{
				_ordersQuery = ordersQuery;
			}

			public async Task<OrderDetailReadModel> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
			{
				return await _ordersQuery.GetOrderDetails(request.Id);
			}
		}
	}
}
