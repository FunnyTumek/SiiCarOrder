using Sii.Dealer.ReadModel.Models;
using Sii.Dealer.SharedKernel.Sales.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sii.Dealer.ReadModel.Dealer
{
	public interface IOrdersQuery
	{
		Task<IList<OrderListViewModel>> GetOrders();

		Task<PaginatedViewModel<OrderListViewModel>> GetOrders(int pageIndex, int pagesize);

		Task<OrderDetailReadModel> GetOrderDetails(int id);
		Task<OrderDetailViewModel> GetDataToAgreement(int id);
	}
}
