using Configurator.Api.Dtos.Contracts;
using MassTransit;
using Microsoft.Extensions.Logging;
using Sii.CarOrder.Contracts.Configuration;
using Sii.CarOrder.Contracts.Models;

namespace Configurator.Api.Application.Services.Implementations
{
    public class OrdersService : IOrdersService
    {
        private readonly ILogger<OrdersService> logger;
        private readonly IBus bus;

        public OrdersService(ILogger<OrdersService> logger, IBus bus)
        {
            this.logger = logger;
            this.bus = bus;
        }

        public async Task SendOrder(CreateOrderDto createOrderDto)
        {
            var carConfiguration = new OrderCarConfiguration() 
            { 
                BrandCode = createOrderDto.Configuration.BrandCode,
                ModelCode = createOrderDto.Configuration.ModelCode,
                EquipmentVersionCode = createOrderDto.Configuration.EquipmentVersionCode,
                ClassCode = createOrderDto.Configuration.ClassCode,
                EngineCode = createOrderDto.Configuration.EngineCode,
                GearboxCode = createOrderDto.Configuration.GearboxCode,
                ColorCode = createOrderDto.Configuration.ColorCode,
                InteriorCode = createOrderDto.Configuration.InteriorCode,
                AdditionalEquipmentCodes = createOrderDto.Configuration.AdditionalEquipmentCodes
            };

            var customer = new OrderCustomer(createOrderDto.Customer.FirstName, createOrderDto.Customer.LastName, createOrderDto.Customer.Email, createOrderDto.Customer.Phone);

            await bus.Publish(new PlaceOrderConfigurationEvent(customer, carConfiguration));
        }
    }
}