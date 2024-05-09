using Sii.Dealer.Core.Application.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sii.Dealer.Core.Application.Services
{
    public interface IOrdersApplicationService
    {
        Task<OrderDto> Get(int id);

        Task<OrderDto> PlaceOrder(CarConfigurationDto configuration, CustomerOrderDto customer);

        Task ApplyDiscount(int orderId, decimal discount, string comment);

		Task CancelOrder(int id);

		Task ConfirmOrder(int id, bool accept, float percentage);

		Task ConfirmPayment(int id, int PaymentId);

		Task<IList<PaymentDto>> GetPaymentsByOrder(int id);

		Task<IList<PaymentDto>> CalculatePaymentsByOrder(int id, float percentage);

        Task SetPlannedDeliveryDate(int id, int factoryId, DateTime? dateTime);

        Task SetStatusProduction(int id);

        Task<FactoryDto> GetCarConfiguration(int id);
        Task SetStatusToProductionAfterResponse(int id);
        Task SetStatusToProducted(int id, Guid carVin, DateTime productionStartDate, DateTime plannedDeliveryDate);
        Task SetStatusToCollected(int orderId);
        Task SetStatusToDelivered(int orderId);
    }
}
