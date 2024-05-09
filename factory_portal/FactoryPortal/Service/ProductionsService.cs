using FactoryPortal.Data;
using System.Net.Http.Json;

namespace FactoryPortal.Service
{
    public class ProductionsService : IProductionsService
    {
        private readonly HttpClient httpClient;

        public ProductionsService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<ProductionDetails> GetProductionDetail(int id)
        {
            return await httpClient.GetFromJsonAsync<ProductionDetails>($"api/factory/{id}");
        }

        public async Task<IEnumerable<ProductionDetails>> GetCurrentProductions()
        {
            return await httpClient.GetFromJsonAsync<ProductionDetails[]>("api/factory");
        }

        public async Task<IEnumerable<ProductionProgressState>> GetProductionStates(int id)
        {
            return await httpClient.GetFromJsonAsync<ProductionProgressState[]>($"api/factory/{id}/getProductionStates");
        }
    
		public async Task CancelProduction(int id, Guid carVin, string reason)
		{
			using var content = new StringContent("");
			await httpClient.PutAsJsonAsync($"api/factory/cancel?id={id}&carvin={carVin}&reason={reason}", content);
		}
	}
}
