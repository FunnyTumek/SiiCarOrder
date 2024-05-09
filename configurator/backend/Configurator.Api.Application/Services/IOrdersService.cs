using Configurator.Api.Dtos.Contracts;

namespace Configurator.Api.Application.Services
{
    public interface IOrdersService
    {
        Task SendOrder(CreateOrderDto createOrderDto);
    }
}