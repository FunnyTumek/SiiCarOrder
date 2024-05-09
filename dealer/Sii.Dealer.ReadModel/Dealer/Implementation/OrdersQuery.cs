using Microsoft.EntityFrameworkCore;
using Sii.Dealer.Core.Infrastructure.Data;
using Sii.Dealer.ReadModel.Models;
using Sii.Dealer.SharedKernel.Enums;
using Sii.Dealer.SharedKernel.Sales.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sii.Dealer.ReadModel.Dealer.Implementation
{
	public class OrdersQuery : IOrdersQuery
	{
		private readonly SalesDbContext context;

		public OrdersQuery(SalesDbContext context)
		{
			this.context = context;
		}

		public async Task<IList<OrderListViewModel>> GetOrders()
		{
			return await this.context.OrderListView.OrderBy(x => x.CreationDate).ToListAsync();
		}

		public async Task<PaginatedViewModel<OrderListViewModel>> GetOrders(int pageIndex = 0, int pagesize = 10)
		{
			var totalRecords = await this.context.OrderListView.CountAsync();
			var totalPages = totalRecords / pagesize;
			var skip = pageIndex * pagesize;
			var records = await this.context.OrderListView.OrderBy(x => x.CreationDate).Skip(skip).Take(pagesize).ToListAsync();
			return new PaginatedViewModel<OrderListViewModel>()
			{
				Data = records,
				PageIndex = pageIndex,
				PageSize = pagesize,
				TotalRecords = totalRecords,
			};
		}

		public async Task<OrderDetailViewModel> GetOrderDetailViewModel(int id)
		{
			return await this.context.OrderDetailListView.FirstOrDefaultAsync(x => x.id == id);
		}

		public async Task<OrderDetailReadModel> GetOrderDetails(int id)
		{
			var orderDetailListViewModel = await this.context.OrderDetailListView.FirstOrDefaultAsync(x => x.id == id);
			if (orderDetailListViewModel == null) throw new Exception("There is no such ID.");

			var customer = new OrderDetailCustomerReadModel(orderDetailListViewModel.CustomerFirstName, orderDetailListViewModel.CustomerLastName, orderDetailListViewModel.CustomerEmail, orderDetailListViewModel.CustomerPhone);

			var information = new OrderDetailInfoReadModel(orderDetailListViewModel.id, orderDetailListViewModel.Price, orderDetailListViewModel.Status, orderDetailListViewModel.Discount, orderDetailListViewModel.CreationDate, orderDetailListViewModel.AgreementSigned, orderDetailListViewModel.AgreementSignedDate, orderDetailListViewModel.PlannedDeliveryDate);

			var configuration = new OrderDetailConfigurationReadModel(orderDetailListViewModel.Brand, orderDetailListViewModel.Model, orderDetailListViewModel.EquipmentVersion, orderDetailListViewModel.Class, orderDetailListViewModel.Engine, Enum.GetName(typeof(EngineType), orderDetailListViewModel.EngineType), orderDetailListViewModel.EnginePower, orderDetailListViewModel.EngineCapacity, Enum.GetName(typeof(GearboxType), orderDetailListViewModel.GearboxType), orderDetailListViewModel.GearboxCount, orderDetailListViewModel.Color, orderDetailListViewModel.Interior);

			return new OrderDetailReadModel(customer, information, configuration);
		}

		public async Task<OrderDetailViewModel> GetDataToAgreement(int id)
		{
			var order = await context.OrderDetailListView.FirstOrDefaultAsync(x => x.id == id);

			if (order == null) throw new Exception("There is no such ID.");
			return order;
		}
	}
}
