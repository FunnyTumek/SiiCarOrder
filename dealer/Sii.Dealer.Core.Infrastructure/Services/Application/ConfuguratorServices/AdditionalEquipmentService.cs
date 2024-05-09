using AutoMapper;
using Microsoft.Extensions.Logging;
using Sii.Dealer.Core.Application.DataTransferObjects;
using Sii.Dealer.Core.Application.Services.ConfiguratorServices;
using Sii.Dealer.Core.Domain;
using Sii.Dealer.Core.Domain.Entities;
using Sii.Dealer.Core.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sii.Dealer.Core.Infrastructure.Services.Application.ConfuguratorServices
{
    public class AdditionalEquipmentService : IAdditionalEquipmentService
    {
        private readonly IConfigurationOptionsRepository configurationOptionsRepository;
        private readonly ISalesUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly ILogger<AdditionalEquipmentService> logger;

        public AdditionalEquipmentService(
            IConfigurationOptionsRepository configurationOptionsRepository,
            ISalesUnitOfWork unitOfWork,
            IMapper mapper,
            ILogger<AdditionalEquipmentService> logger)
        {
            this.configurationOptionsRepository = configurationOptionsRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task Create(AdditionalEquipmentDto dto)
        {
            AdditionalEquipment newBrandEntity = new(dto.Code, dto.Name, dto.Availability, dto.Price);
            await configurationOptionsRepository.Add(newBrandEntity);

            logger.LogInformation("AdditionalEquipment has been created Code = {Code}.", dto.Code);
            unitOfWork.Commit();
        }

        public async Task<AdditionalEquipmentDto> Get(string code)
        {
            AdditionalEquipment entity = await configurationOptionsRepository.GetByCode<AdditionalEquipment>(code);
            return mapper.Map<AdditionalEquipment, AdditionalEquipmentDto>(entity);
        }

        public async Task<IList<AdditionalEquipmentDto>> GetAll(bool onlyActive)
        {
            IList<AdditionalEquipment> items = onlyActive
                ? await configurationOptionsRepository.GetActive<AdditionalEquipment>()
                : await configurationOptionsRepository.GetAll<AdditionalEquipment>();
            return items.Select(item => mapper.Map<AdditionalEquipment, AdditionalEquipmentDto>(item)).ToList();
        }

        public async Task Update(AdditionalEquipmentDto dto)
        {
            var brandEntity = await configurationOptionsRepository.GetByCode<AdditionalEquipment>(dto.Code);
            brandEntity.Update(dto.Name,dto.Availability);

            logger.LogInformation("AdditionalEquipment has been updated Code = {Code}.", dto.Code);
            unitOfWork.Commit();
        }
    }
}
