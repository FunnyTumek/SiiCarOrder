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
    public class EquipmentVersionService : IEquipmentVersionService
    {
        private readonly IConfigurationOptionsRepository configurationOptionsRepository;
        private readonly ISalesUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly ILogger<EquipmentVersionService> logger;

        public EquipmentVersionService(
            IConfigurationOptionsRepository configurationOptionsRepository,
            ISalesUnitOfWork unitOfWork,
            IMapper mapper,
            ILogger<EquipmentVersionService> logger)
        {
            this.configurationOptionsRepository = configurationOptionsRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task Create(EquipmentVersionDto dto)
        {
            EquipmentVersion newEntity = new(dto.Code, dto.Name, dto.Availability, dto.Price);
            await configurationOptionsRepository.Add(newEntity);

            logger.LogInformation("Equipment Version has been created Code = {Code}.", dto.Code);
            unitOfWork.Commit();
        }

        public async Task<EquipmentVersionDto> Get(string code)
        {
            EquipmentVersion entity = await configurationOptionsRepository.GetByCode<EquipmentVersion>(code);
            return mapper.Map<EquipmentVersion, EquipmentVersionDto>(entity);
        }

        public async Task<IList<EquipmentVersionDto>> GetAll(bool onlyActive)
        {
            IList<EquipmentVersion> items = onlyActive
                ? await configurationOptionsRepository.GetActive<EquipmentVersion>()
                : await configurationOptionsRepository.GetAll<EquipmentVersion>();
            return items.Select(item => mapper.Map<EquipmentVersion, EquipmentVersionDto>(item)).ToList();
        }

        public async Task Update(EquipmentVersionDto dto)
        {
            var entity = await configurationOptionsRepository.GetByCode<EquipmentVersion>(dto.Code);
            entity.Update(dto.Name, dto.Availability);

            logger.LogInformation("Equipment Version has been updated Code = {Code}.", dto.Code);
            unitOfWork.Commit();
        }
    }
}

