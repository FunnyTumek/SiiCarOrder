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
    public class InteriorService : IInteriorService
    {
        private readonly IConfigurationOptionsRepository configurationOptionsRepository;
        private readonly ISalesUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly ILogger<InteriorService> logger;

        public InteriorService(
            IConfigurationOptionsRepository configurationOptionsRepository,
            ISalesUnitOfWork unitOfWork,
            IMapper mapper,
            ILogger<InteriorService> logger)
        {
            this.configurationOptionsRepository = configurationOptionsRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task Create(InteriorDto dto)
        {
            Interior newEntity = new(dto.Code, dto.Name, dto.Availability, dto.Price);
            await configurationOptionsRepository.Add(newEntity);

            logger.LogInformation("Interior has been created Code = {Code}.", dto.Code);
            unitOfWork.Commit();
        }

        public async Task<InteriorDto> Get(string code)
        {
            Interior entity = await configurationOptionsRepository.GetByCode<Interior>(code);
            return mapper.Map<Interior, InteriorDto>(entity);
        }

        public async Task<IList<InteriorDto>> GetAll(bool onlyActive)
        {
            IList<Interior> items = onlyActive
                ? await configurationOptionsRepository.GetActive<Interior>()
                : await configurationOptionsRepository.GetAll<Interior>();
            return items.Select(item => mapper.Map<Interior, InteriorDto>(item)).ToList();
        }
        public async Task Update(InteriorDto dto)
        {
            var entity = await configurationOptionsRepository.GetByCode<Interior>(dto.Code);
            entity.Update(dto.Name, dto.Availability);

            logger.LogInformation("Interior has been updated Code = {Code}.", dto.Code);
            unitOfWork.Commit();
        }
    }
}
