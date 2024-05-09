using Sii.Dealer.Core.Application.DataTransferObjects;
using System.Threading.Tasks;

namespace Sii.Dealer.Core.Application.Services
{
    public interface IFactoryService
    {
        Task<FactoryResponse?> SentOrder(FactoryDto factoryDto);
        Task SendOrder(int orderId);
    }
}