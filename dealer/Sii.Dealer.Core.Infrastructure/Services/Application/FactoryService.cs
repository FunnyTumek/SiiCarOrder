using MassTransit;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Sii.CarOrder.Contracts.Dealer;
using Sii.Dealer.Core.Application.DataTransferObjects;
using Sii.Dealer.Core.Application.Services;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Sii.Dealer.Core.Infrastructure.Services.Application
{
	public class FactoryService : IFactoryService
	{
		private readonly HttpClient httpClient;
		private readonly ILogger<FactoryService> logger;
        private readonly IOrdersApplicationService _ordersService;
        private readonly IBus _bus;

        public FactoryService(IHttpClientFactory httpClientFactory, ILogger<FactoryService> logger, IOrdersApplicationService ordersService, IBus bus)
		{
			httpClient = httpClientFactory.CreateClient("Factory.Api");
			this.logger = logger;
			_ordersService = ordersService;
			_bus = bus;
		}

		public async Task<FactoryResponse?> SentOrder(FactoryDto factoryDto)
		{
			var response = await httpClient.PostAsJsonAsync("/api/factory", factoryDto);
			if (response.StatusCode != HttpStatusCode.OK)
			{
				logger.LogError("HttpClient doesn't work.");
				return null;
			}
			string plannedDeliveryDate = await response.Content.ReadAsStringAsync();

			logger.LogInformation("HttpClient get PlannedDeliveryDate = {PlannedDeliveryDate}.", plannedDeliveryDate);
			return JsonConvert.DeserializeObject<FactoryResponse>(plannedDeliveryDate);
		}

		public async Task SendOrder(int orderId)
		{
            var order = await _ordersService.GetCarConfiguration(orderId);
            await _bus.Publish(new PlaceOrderDealerEvent(orderId, order.BrandCode, order.ModelCode, order.EquipmentVersionCode, order.ClassCode, order.EngineCode, order.GearboxCode, order.ColorCode, order.InteriorCode, order.AdditionalEquipmentCodes));
        }
	}
}