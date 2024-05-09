namespace Configurator.Api.Application.Services
{
    public interface IJsonFileService
    {
        public Task<string> ReadFile(string fileName);
    }
}
