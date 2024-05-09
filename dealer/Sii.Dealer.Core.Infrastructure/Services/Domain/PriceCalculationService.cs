using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sii.Dealer.Core.Application.DataTransferObjects;
using Sii.Dealer.Core.Application.Services.ConfiguratorServices;
using Sii.Dealer.Core.Domain.Entities;
using Sii.Dealer.Core.Domain.Repositories;
using Sii.Dealer.Core.Domain.Services;

namespace Sii.Dealer.Core.Infrastructure.Services.Domain
{
    public class PriceCalculationService : IPriceCalculationService
    {
        private readonly IConfigurationOptionsRepository _configurationOptionsRepository;
        private readonly IAdditionalEquipmentService _additionalEquipmentService;
        public PriceCalculationService(IConfigurationOptionsRepository configurationOptionsRepository, IAdditionalEquipmentService additionalEquipmentService)
        {
            _configurationOptionsRepository = configurationOptionsRepository;
            _additionalEquipmentService = additionalEquipmentService;
        }
        public async Task<decimal> CalculatePrice(CarConfiguration carConfiguration)
        {
            IList<decimal> allElementsPrice = await _configurationOptionsRepository.GetPriceOfAllOptionsByCode(carConfiguration.BrandCode,
                                                                                        carConfiguration.CarClassCode,
                                                                                        carConfiguration.ModelCode,
                                                                                        carConfiguration.ColorCode,
                                                                                        carConfiguration.EngineCode,
                                                                                        carConfiguration.EquipmentVersionCode,
                                                                                        carConfiguration.GearboxCode,
                                                                                        carConfiguration.InteriorCode);
            decimal price = 0;
            foreach (var elementPrice in allElementsPrice)
            {
                price += elementPrice;             
            }

            IList<AdditionalEquipmentDto> allAdditionalEq = await _additionalEquipmentService.GetAll(true);
            foreach (var item in allAdditionalEq)
            {
                if (carConfiguration.AdditionalEquipmentCodes.Contains(item.Code))
                {
                    price += item.Price;
                }
            }
            return price;
        }
    }
}
