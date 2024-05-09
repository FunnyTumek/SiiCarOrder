namespace Configurator.Api.Application.Services.Implementations
{
    public class JsonFileService : IJsonFileService
    {
        public async Task<string> ReadFile(string fileName) 
        {
            return await File.ReadAllTextAsync(fileName);
        }
    }
}
