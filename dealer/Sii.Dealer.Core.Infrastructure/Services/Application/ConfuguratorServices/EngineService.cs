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
    public class EngineService : IEngineService
    {
        private readonly IConfigurationOptionsRepository configurationOptionsRepository;
        private readonly ISalesUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly ILogger<EngineService> logger;

        public EngineService(
            IConfigurationOptionsRepository configurationOptionsRepository,
            ISalesUnitOfWork unitOfWork,
            IMapper mapper,
            ILogger<EngineService> logger)
        {
            this.configurationOptionsRepository = configurationOptionsRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task Create(EngineDto dto)
        {
            if (!Enum.TryParse(dto.Type, out EngineType type))
            {
                logger.LogError("Engine type is not valid.");
                throw new ArgumentException("Engine type is not valid", nameof(dto));
            }
            Engine newEntity = new(dto.Code, dto.Name, dto.Capacity, dto.Power, type, dto.Availability, dto.Price);
            await configurationOptionsRepository.Add(newEntity);

            logger.LogInformation("Engine has been created Code = {Code}.", dto.Code);
            unitOfWork.Commit();
            
        }

        public async Task<EngineDto> Get(string code)
        {
            Engine entity = await configurationOptionsRepository.GetByCode<Engine>(code);
            return mapper.Map<Engine, EngineDto>(entity);
        }

        public async Task<IList<EngineDto>> GetAll(bool onlyActive)
        {
            IList<Engine> items = onlyActive
                ? await configurationOptionsRepository.GetActive<Engine>()
                : await configurationOptionsRepository.GetAll<Engine>();
            return items.Select(item => mapper.Map<Engine, EngineDto>(item)).ToList();//TODO:LIST TO LIST
        }

        public async Task Update(EngineDto dto)
        {
            if (Enum.TryParse(dto.Type, out EngineType type))
            {
                var entity = await configurationOptionsRepository.GetByCode<Engine>(dto.Code);
                entity.Update(dto.Name, dto.Capacity, dto.Power, type, dto.Availability);
                logger.LogInformation("Color has been updated Code = {Code}.", dto.Code);
                unitOfWork.Commit();
            }
            else
            {
                logger.LogError("Engine type is not valid.");
                throw new ArgumentException("Engine type is not valid", nameof(type));
            }  
        }
    }
}
