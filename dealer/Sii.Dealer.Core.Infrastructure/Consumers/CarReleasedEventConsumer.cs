using MassTransit;
using Microsoft.Extensions.Logging;
using Sii.CarOrder.Contracts.Factory;
using Sii.Dealer.Core.Application.Services;
using Sii.Dealer.Core.Infrastructure.Services.Application;
using System.Threading.Tasks;

namespace Sii.Dealer.Core.Infrastructure.Consumers
{
    public class CarReleasedEventConsumer : IConsumer<CarReleasedEvent>
    {
        private readonly IOrdersApplicationService _ordersService;
        private readonly ILogger<CarReleasedEventConsumer> _logger;
        public CarReleasedEventConsumer(IOrdersApplicationService ordersService, ILogger<CarReleasedEventConsumer> logger)
        {
            _ordersService = ordersService;
            _logger = logger;
        }
        public async Task Consume(ConsumeContext<CarReleasedEvent> context)
        {
            await _ordersService.SetStatusToCollected(context.Message.OrderId);
            _logger.LogInformation("The car was successfully picked up from the factory. Order status was updated to collected");
        }
    }
}
