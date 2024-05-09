using AutoMapper;
using Sii.Dealer.Core.Application.DataTransferObjects;
using Sii.Dealer.Core.Application.Services.ConfiguratorServices;
using Sii.Dealer.Core.Domain.Entities;
using Sii.Dealer.Core.Domain.Entities.CarConfigurationEntities;
using Sii.Dealer.Core.Domain.Repositories;
using Sii.Dealer.Core.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sii.Dealer.Core.Infrastructure.Services.Application.ConfuguratorServices
{
    public class AvailableConfigurationsService : IAvailableConfigurationsService
    {
        private readonly IAvailableConfigurationsRepository _availableConfigurationsRepository;
        private readonly IPriceCalculationService _priceCalculationService;
        private readonly IMapper _mapper;

        public AvailableConfigurationsService(IAvailableConfigurationsRepository configurationOptionsRepository, IMapper mapper, IPriceCalculationService priceCalculationService)
        {
            _availableConfigurationsRepository = configurationOptionsRepository;
            _mapper = mapper;
            _priceCalculationService = priceCalculationService;
        }

        public async Task<IList<AvailableCarConfigurationDto>>GetAll()
        {
            IEnumerable<AvailableCarConfiguration> allConfigurations = await _availableConfigurationsRepository.GetAll();
            var availableConfigurationsDto = allConfigurations.Select(item => _mapper.Map<AvailableCarConfiguration, AvailableCarConfigurationDto>(item)).ToList();
            var configurations = SetAdditionaEquipmentToDto(allConfigurations, availableConfigurationsDto);
            foreach (var confDto in configurations)
            {
                var carConfiguration = new CarConfiguration()
                {
                    BrandCode = confDto.BrandCode,
                    ModelCode = confDto.ModelCode,
                    EquipmentVersionCode = confDto.EquipmentVersionCode,
                    CarClassCode = confDto.ClassCode,
                    ColorCode = confDto.ColorCode,
                    InteriorCode = confDto.InteriorCode,
                    EngineCode = confDto.EngineCode,
                    GearboxCode = confDto.GearboxCode,
                    AdditionalEquipmentCodes = confDto.AdditionalEquipmentCodes
                };
                confDto.Price = await _priceCalculationService.CalculatePrice(carConfiguration);
            }
            return configurations;
        }

        public async Task<int> SaveAsync(AvailableCarConfigurationDto dto)
        {
            AvailableCarConfiguration availableConfigurationToAdd = new(dto.BrandCode , dto.ModelCode, dto.EquipmentVersionCode, dto.ClassCode, dto.EngineCode, dto.GearboxCode, dto.ColorCode, dto.InteriorCode);
            var confId = await _availableConfigurationsRepository.SaveConfiguration(availableConfigurationToAdd);
            foreach (var eqCode in dto.AdditionalEquipmentCodes)
            {
                AvailableConfigurationAdditionalEquipment configurationEquipment = new(confId, eqCode);
                await _availableConfigurationsRepository.SaveEquipment(configurationEquipment);
            }
            return confId;
        }

        private IList<AvailableCarConfigurationDto> SetAdditionaEquipmentToDto(IEnumerable<AvailableCarConfiguration> allConfigurations, IList<AvailableCarConfigurationDto> availableConfigurationsDto)
        {
            foreach (var configItem in allConfigurations)
            {
                var configDto = availableConfigurationsDto.FirstOrDefault(x => x.Id == configItem.Id);
                configDto.AdditionalEquipments = new List<AdditionalEquipmentDto>();
                configDto.AdditionalEquipmentCodes = new List<string>();
                foreach (var eq in configItem.ConfigurationAdditionalEquipments)
                {
                    eq.AdditionalEquipment.ConfigurationAdditionalEquipments = null;
                    configDto.AdditionalEquipments.Add(_mapper.Map<AdditionalEquipment, AdditionalEquipmentDto>(eq.AdditionalEquipment));
                    configDto.AdditionalEquipmentCodes.Add(eq.AdditionalEquipment.Code);
                }
            }
            return availableConfigurationsDto;
        }
    }
}
