namespace SiiCarOrder.Factory.Scheduler.Hubs
{
    public interface IProductionProgressHub
    {
        Task ReportProductionProgress(Guid carVin, int progress);
    }
}
