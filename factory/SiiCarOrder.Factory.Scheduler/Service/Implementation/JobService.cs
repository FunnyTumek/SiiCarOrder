using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Options;
using Quartz;
using Quartz.Impl.Matchers;
using Sii.CarOrder.Contracts.Enums;
using Sii.CarOrder.Contracts.Models;
using SiiCarOrder.Factory.Application.Service;
using SiiCarOrder.Factory.Scheduler.Hubs;
using SiiCarOrder.Factory.Scheduler.Listeners;
using SiiCarOrder.Factory.Scheduler.Models;

namespace SiiCarOrder.Factory.Scheduler.Service
{
	public class JobService : IJobService
	{
		private readonly ISchedulerService _schedulerService;
		private readonly ITimersManagerService _timersManagerService;
		private readonly IHubContext<ProductionProgressHub, IProductionProgressHub> _hubContext;
		private readonly IOptions<ProductionParams> _productionParams;
		private readonly IFactoryOrderService _factoryOrderService;

		public JobService(ISchedulerService schedulerService, ITimersManagerService timersManagerService, IHubContext<ProductionProgressHub,
						  IProductionProgressHub> hubContext, IOptions<ProductionParams> productionParams, IFactoryOrderService factoryOrderService)
		{
			_schedulerService = schedulerService;
			_timersManagerService = timersManagerService;
			_hubContext = hubContext;
			_productionParams = productionParams;
			_factoryOrderService = factoryOrderService;
		}

		public async Task CreateAndAddToScheduler(int orderId, Guid carVin, int productionId)
		{
			var data = new JobDataMap();
			data.Add("OrderId", orderId);
			data.Add("CarVin", carVin);
			data.Add("ProductionId", productionId);

			//define the job and tie it to our CarProducingJob class
			IJobDetail job = JobBuilder.Create<CarProductionJob>()
				.WithIdentity("CarProductionJob_" + carVin, "CarProductionGroup")
				.UsingJobData(data)
				.Build();

			//trigger the job to run in some time
			ISimpleTrigger trigger = (ISimpleTrigger)TriggerBuilder.Create()
				.WithIdentity("CarProductionTrigger_" + carVin, "CarProductionGroup")
				.StartAt(DateBuilder.FutureDate(15, IntervalUnit.Second))
				.Build();

			var productionScheduler = await _schedulerService.Get();
			IList<ProductionProgressState> states = ProductionProgressStates.States.Where(w => (int)w.Key > 2).Select(w => w.Key).ToList();
			productionScheduler?.ListenerManager.AddJobListener(new CarProductionJobListener(_timersManagerService, _hubContext, _productionParams,
																							 ProductionProgressStates.GetShuffledList(states),
																							 _factoryOrderService),
																KeyMatcher<JobKey>.KeyEquals(job.Key));
			productionScheduler?.ScheduleJob(job, trigger);
		}
	}
}