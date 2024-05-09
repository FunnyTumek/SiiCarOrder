using AutoMapper;
using Microsoft.Extensions.Logging;
using Sii.Dealer.Core.Application.DataTransferObjects;
using Sii.Dealer.Core.Application.Services.ConfiguratorServices;
using Sii.Dealer.Core.Domain;
using Sii.Dealer.Core.Domain.Entities;
using Sii.Dealer.Core.Domain.Repositories;
using Sii.Dealer.SharedKernel.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sii.Dealer.Core.Infrastructure.Services.Application.ConfuguratorServices
{
    public class GearboxService : IGearboxService
    {
        
        private readonly IConfigurationOptionsRepository configurationOptionsRepository;
        private readonly ISalesUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly ILogger<GearboxService> logger;

        public GearboxService(
            IConfigurationOptionsRepository configurationOptionsRepository,
            ISalesUnitOfWork unitOfWork,
            IMapper mapper,
            ILogger<GearboxService> logger)
        {
            this.configurationOptionsRepository = configurationOptionsRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task Create(GearboxDto dto)
        {
            if (Enum.TryParse(dto.Type, out GearboxType type))
            {
                Gearbox newEntity = new(dto.Code, dto.Name, type, dto.GearsCount, dto.Availability, dto.Price);
                await configurationOptionsRepository.Add(newEntity);

                logger.LogInformation("Gearbox Version has been created Code = {Code}.", dto.Code);
                unitOfWork.Commit();
            }
            logger.LogError("Gearbox type is not valid.");
            throw new ArgumentException("Gearbox type is not valid", nameof(type));
        }

        public async Task<GearboxDto> Get(string code)
        {
            Gearbox entity = await configurationOptionsRepository.GetByCode<Gearbox>(code);
            return mapper.Map<Gearbox, GearboxDto>(entity);
        }

        public async Task<IList<GearboxDto>> GetAll(bool onlyActive)
        {
            IList<Gearbox> items = onlyActive
                ? await configurationOptionsRepository.GetActive<Gearbox>()
                : await configurationOptionsRepository.GetAll<Gearbox>();
            return items.Select(item => mapper.Map<Gearbox, GearboxDto>(item)).ToList();
        }

        public async Task Update(GearboxDto dto)
        {
            if (Enum.TryParse(dto.Type, out GearboxType type))
            {
                var entity = await configurationOptionsRepository.GetByCode<Gearbox>(dto.Code);
                entity.Update(dto.Name, type, dto.GearsCount, dto.Availability);

                logger.LogInformation("Gearbox Version has been updated Code = {Code}.", dto.Code);
                unitOfWork.Commit();
            }
            else
            {
                logger.LogError("Gearbox type is not valid.");
                throw new ArgumentException("Gearbox type is not valid", nameof(type));
            }
        }
    }
}

