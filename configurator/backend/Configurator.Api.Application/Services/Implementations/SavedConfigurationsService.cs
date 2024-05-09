using MongoDB.Driver;
using AutoMapper;
using Configurator.Api.DataAccess.Data;
using Configurator.Api.Dtos.Contracts;
using Configurator.Api.DataAccess.Models;
using Microsoft.Extensions.Logging;

namespace Configurator.Api.Application.Services.Implementations
{
    public class SavedConfigurationsService : ISavedConfigurationsService
    {
        private readonly IMongoCollection<SavedConfiguration> _collection;
        private readonly IMapper _mapper;
        private readonly ILogger<SavedConfigurationsService> _logger;

        public SavedConfigurationsService(IConfigurationsDbContext dbContext, IMapper mapper, ILogger<SavedConfigurationsService> logger)
        {
            _collection = dbContext.SavedConfigurations;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<CarConfigurationDto?> GetByIdAsync(string id)
        {
            bool parsed = MongoDB.Bson.ObjectId.TryParse(id, out _);
            if (!parsed)
            {
                _logger.LogDebug("Configuration with id \"{id}\" was wrong parsed.", id);
                return null;
            }
            var savedConfiguration = await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();
            if (savedConfiguration is null)
            {
                return null;
            }
            var response = _mapper.Map<SavedConfiguration, CarConfigurationDto>(savedConfiguration);
            return response;
        }

        public async Task<string> SaveAsync(CarConfigurationBaseDto request)
        {
            string? userId = null; // TODO: Get user id from token if present, leave null otherwise
            var savedConfiguration = SavedConfiguration.CreateFromDto(request, userId);
            await _collection.InsertOneAsync(savedConfiguration);
            if (savedConfiguration.Id is null)
            {
                throw new Exception("There was a problem with saving configuration - saved configuration id is null.");
            }
            _logger.LogDebug("Configuration saved with id {id}.", savedConfiguration.Id);
            return savedConfiguration.Id;
        }
    }
}