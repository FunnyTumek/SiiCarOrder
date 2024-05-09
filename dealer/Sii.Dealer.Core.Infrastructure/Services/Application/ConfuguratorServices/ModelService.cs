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
    public class ModelService : IModelService
    {
        private readonly IConfigurationOptionsRepository configurationOptionsRepository;
        private readonly ISalesUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly ILogger<ModelService> logger;

        public ModelService(
            IConfigurationOptionsRepository configurationOptionsRepository,
            ISalesUnitOfWork unitOfWork,
            IMapper mapper)
        {
            this.configurationOptionsRepository = configurationOptionsRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task Create(ModelDto dto)
        {
            Model newEntity = new(dto.Code, dto.Name, dto.Availability, dto.Price);
            await configurationOptionsRepository.Add(newEntity);

            logger.LogInformation("Model has been created Code = {code}.", dto.Code);
            unitOfWork.Commit();
        }

        public async Task<ModelDto> Get(string code)
        {
            Model entity = await configurationOptionsRepository.GetByCode<Model>(code);
            return mapper.Map<Model, ModelDto>(entity);
        }

        public async Task<IList<ModelDto>> GetAll(bool onlyActive)
        {
            IList<Model> items = onlyActive
                ? await configurationOptionsRepository.GetActive<Model>()
                : await configurationOptionsRepository.GetAll<Model>();
            return items.Select(item => mapper.Map<Model, ModelDto>(item)).ToList();
        }

        public async Task Update(ModelDto dto)
        {
            var entity = await configurationOptionsRepository.GetByCode<Model>(dto.Code);
            entity.Update(dto.Name, dto.Availability);

            logger.LogInformation("Interior has been updated Code = {Code}.", dto.Code);
            unitOfWork.Commit();
        }
    }
}
