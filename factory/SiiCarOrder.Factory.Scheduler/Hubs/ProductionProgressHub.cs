using Microsoft.AspNetCore.SignalR;

namespace SiiCarOrder.Factory.Scheduler.Hubs
{
    public class ProductionProgressHub : Hub<IProductionProgressHub>
    {
        public async Task ReportProductionProgress(Guid carVin, int progress)
        {
            await Clients.All.ReportProductionProgress(carVin, progress);
        }
    }
}
