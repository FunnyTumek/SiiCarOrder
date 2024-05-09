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
    public class CarClassService: ICarClassService
    {
        private readonly IConfigurationOptionsRepository configurationOptionsRepository;
        private readonly ISalesUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly ILogger<CarClassService> logger;

        public CarClassService(
            IConfigurationOptionsRepository configurationOptionsRepository,
            ISalesUnitOfWork unitOfWork,
            IMapper mapper,
            ILogger<CarClassService> logger)
        {
            this.configurationOptionsRepository = configurationOptionsRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task Create(CarClassDto dto)
        {
            CarClass newEntity = new(dto.Code, dto.Name, dto.Availability, dto.Price);
            await configurationOptionsRepository.Add(newEntity);

            logger.LogInformation("Car Class has been created Code = {Code}.", dto.Code);
            unitOfWork.Commit();
        }

        public async Task<CarClassDto> Get(string code)
        {
            CarClass entity = await configurationOptionsRepository.GetByCode<CarClass>(code);
            return mapper.Map<CarClass, CarClassDto>(entity);
        }

        public async Task<IList<CarClassDto>> GetAll(bool onlyActive)
        {
            IList<CarClass> items = onlyActive
                ? await configurationOptionsRepository.GetActive<CarClass>()
                : await configurationOptionsRepository.GetAll<CarClass>();
            return items.Select(item => mapper.Map<CarClass, CarClassDto>(item)).ToList();
        }

        public async Task Update(CarClassDto dto)
        {
            var entity = await configurationOptionsRepository.GetByCode<CarClass>(dto.Code);
            entity.Update(dto.Name, dto.Availability);

            logger.LogInformation("Car Class has been updated Code = {Code}.", dto.Code);
            unitOfWork.Commit();
        }
    }
}
