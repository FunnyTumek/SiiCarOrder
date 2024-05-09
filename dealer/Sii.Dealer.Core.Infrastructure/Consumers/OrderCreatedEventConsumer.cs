using MassTransit;
using Microsoft.Extensions.Logging;
using Sii.CarOrder.Contracts.Configuration;
using Sii.Dealer.Core.Application.DataTransferObjects;
using Sii.Dealer.Core.Application.Services;
using System.Threading.Tasks;

namespace Sii.Dealer.Core.Infrastructure.Consumers
{
    public class OrderCreatedEventConsumer : IConsumer<PlaceOrderConfigurationEvent>
    {
        private readonly ILogger<OrderCreatedEventConsumer> logger;
        private readonly IOrdersApplicationService ordersApplicationService;

        public OrderCreatedEventConsumer(ILogger<OrderCreatedEventConsumer> logger, IOrdersApplicationService ordersApplicationService)
        {
            this.logger = logger;
            this.ordersApplicationService = ordersApplicationService;   
        }

        public async Task Consume(ConsumeContext<PlaceOrderConfigurationEvent> context)
        {
            var customer = new CustomerOrderDto()
            {
                FirstName = context.Message.customer.FirstName,
                LastName = context.Message.customer.LastName,
                Email = context.Message.customer.Email,
                Phone = context.Message.customer.Phone
            };

            var carConfiguration = new CarConfigurationDto()
            {
                BrandCode = context.Message.carConfiguration.BrandCode,
                ModelCode = context.Message.carConfiguration.ModelCode,
                EquipmentVersionCode = context.Message.carConfiguration.EquipmentVersionCode,
                ClassCode = context.Message.carConfiguration.ClassCode,
                EngineCode = context.Message.carConfiguration.EngineCode,
                ColorCode = context.Message.carConfiguration.ColorCode,
                GearboxCode = context.Message.carConfiguration.GearboxCode,
                InteriorCode = context.Message.carConfiguration.InteriorCode,
                AdditionalEquipmentCodes = context.Message.carConfiguration.AdditionalEquipmentCodes
            };

            logger.LogInformation("{EventType} handled by {ConsumerType}.", nameof(OrderCreatedEventConsumer), nameof(PlaceOrderConfigurationEvent));
            await ordersApplicationService.PlaceOrder(carConfiguration, customer);
        }
    }
}
