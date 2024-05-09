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
    public class ColorService : IColorService
    {
        private readonly IConfigurationOptionsRepository configurationOptionsRepository;
        private readonly ISalesUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly ILogger<ColorService> logger;

        public ColorService(
            IConfigurationOptionsRepository configurationOptionsRepository,
            ISalesUnitOfWork unitOfWork,
            IMapper mapper,
            ILogger<ColorService> logger)
        {
            this.configurationOptionsRepository = configurationOptionsRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task Create(ColorDto dto)
        {
            Color newEntity = new(dto.Code, dto.Name, dto.Availability, dto.Price);
            await configurationOptionsRepository.Add(newEntity);

            logger.LogInformation("Color has been created Code = {Code}.", dto.Code);
            unitOfWork.Commit();
        }

        public async Task<ColorDto> Get(string code)
        {
            Color entity = await configurationOptionsRepository.GetByCode<Color>(code);
            return mapper.Map<Color, ColorDto>(entity);
        }

        public async Task<IList<ColorDto>> GetAll(bool onlyActive)
        {
            IList<Color> items = onlyActive
                ? await configurationOptionsRepository.GetActive<Color>()
                : await configurationOptionsRepository.GetAll<Color>();
            return items.Select(item => mapper.Map<Color, ColorDto>(item)).ToList();
        }

        public async Task Update(ColorDto dto)
        {
            var entity = await configurationOptionsRepository.GetByCode<Color>(dto.Code);
            entity.Update(dto.Name, dto.Availability);

            logger.LogInformation("Color has been updated Code = {Code}.", dto.Code);
            unitOfWork.Commit();
        }
    }
}
