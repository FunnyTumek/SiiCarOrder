using System.Threading.Tasks;
using MassTransit;
using Microsoft.Extensions.Logging;
using Sii.CarOrder.Contracts.Dealer;
using Sii.Dealer.Customers.DataTransferObjects;
using Sii.Dealer.Customers.Services;


namespace Sii.Dealer.Customers.Consumers
{
    public class CustomersEventConsumer : IConsumer<UpdateClientDataEvent>
    {
        private readonly ILogger<CustomersEventConsumer> logger;
        private readonly ICustomersService customersService;

        public CustomersEventConsumer(ILogger<CustomersEventConsumer> logger, ICustomersService customersService)
        {
            this.logger = logger;
            this.customersService = customersService;
        }

        public Task Consume(ConsumeContext<UpdateClientDataEvent> context)
        {
            var customeremail = customersService.GetByEmailSync(context.Message.Email);
            if (customeremail == null)
            {
                customersService.CreateCustomer(new CustomerDto()
                {
                    Email = context.Message.Email,
                    FirstName = context.Message.FirstName,
                    LastName = context.Message.LastName,
                    Phone = context.Message.Phone,
                });
            }
            this.logger.LogDebug("{EventType} handled by {ConsumerType}.", nameof(UpdateClientDataEvent), nameof(CustomersEventConsumer));
            return Task.CompletedTask;
        }
    }
}
