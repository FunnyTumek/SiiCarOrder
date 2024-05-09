using AutoMapper;
using Microsoft.Extensions.Logging;
using Sii.Dealer.Core.Application.DataTransferObjects;
using Sii.Dealer.Core.Application.Services.ConfiguratorServices;
using Sii.Dealer.Core.Domain;
using Sii.Dealer.Core.Domain.Entities;
using Sii.Dealer.Core.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sii.Dealer.Core.Infrastructure.Services.Application.ConfuguratorServices
{
    public class BrandService : IBrandService
    {
        private readonly IConfigurationOptionsRepository configurationOptionsRepository;
        private readonly ISalesUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly ILogger<BrandService> logger;

        public BrandService(
            IConfigurationOptionsRepository configurationOptionsRepository,
            ISalesUnitOfWork unitOfWork,
            IMapper mapper,
            ILogger<BrandService> logger)
        {
            this.configurationOptionsRepository = configurationOptionsRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task Create(BrandDto dto)
        {
            Brand newBrandEntity = new(dto.Code, dto.Name, dto.Availability, dto.Price);
            await configurationOptionsRepository.Add(newBrandEntity);

            logger.LogInformation("Brand has been created Code = {Code}.", dto.Code);
            unitOfWork.Commit();
        }

        public async Task<BrandDto> Get(string code)
        {
            Brand entity = await configurationOptionsRepository.GetByCode<Brand>(code);
            return mapper.Map<Brand, BrandDto>(entity);
        }

        public async Task<IList<BrandDto>> GetAll(bool onlyActive)
        {
            IList<Brand> items = onlyActive
                ? await configurationOptionsRepository.GetActive<Brand>()
                : await configurationOptionsRepository.GetAll<Brand>();
            return items.Select(item => mapper.Map<Brand, BrandDto>(item)).ToList(); 
        }

        public async Task Update(BrandDto dto)
        {
            var brandEntity = await configurationOptionsRepository.GetByCode<Brand>(dto.Code);
            brandEntity.Update(dto.Name, dto.Availability);

            logger.LogInformation("Brand has been updated Code = {Code}.", dto.Code);
            unitOfWork.Commit();
        }
    }
}
