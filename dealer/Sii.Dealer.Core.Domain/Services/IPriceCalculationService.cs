using Sii.Dealer.Core.Domain.Entities;
using Sii.Dealer.Core.Domain.ValueObjects;
using System.Threading.Tasks;

namespace Sii.Dealer.Core.Domain.Services
{
    public interface IPriceCalculationService
    {
        Task<decimal> CalculatePrice(CarConfiguration carConfiguration);
    }
}
