using Microsoft.AspNetCore.SignalR;
using Quartz;
using SiiCarOrder.Factory.Scheduler.Service;
using System.Diagnostics;
using SiiCarOrder.Factory.Scheduler.Hubs;
using Microsoft.Extensions.Options;
using SiiCarOrder.Factory.Scheduler.Models;
using Sii.CarOrder.Contracts.Enums;
using MassTransit;
using SiiCarOrder.Factory.Application.Service;
using SiiCarOrder.Factory.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace SiiCarOrder.Factory.Scheduler.Listeners
{
    public class CarProductionJobListener : IJobListener
    {
        public string Name => "CarProductionobListener";
        private readonly ITimersManagerService _timersManagerService;
        private readonly IHubContext<ProductionProgressHub, IProductionProgressHub> _hubContext;
        private readonly IOptions<ProductionParams> _productionParams;
        private readonly IList<ProductionProgressState> _states;
        private readonly IFactoryOrderService _factoryOrderService;

        public CarProductionJobListener(ITimersManagerService timersManagerService, IHubContext<ProductionProgressHub,IProductionProgressHub> hubContext,
                                        IOptions<ProductionParams> productionParams, IList<ProductionProgressState> states, IFactoryOrderService factoryOrderService)
        {
            _timersManagerService = timersManagerService;
            _hubContext = hubContext;
            _productionParams = productionParams;
            _states = states;
            _factoryOrderService = factoryOrderService;
        }

        public Task JobExecutionVetoed(IJobExecutionContext context, CancellationToken cancellationToken = default)
        {
            try
            {
                var id = (Guid)context.JobDetail.JobDataMap["CarVin"];
                _timersManagerService.StopTimer(id);

                AddProgressState((int)context.JobDetail.JobDataMap["ProductionId"], ProductionProgressState.Canceled);

                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                return Task.CompletedTask;
            }
        }

        public Task JobToBeExecuted(IJobExecutionContext context, CancellationToken cancellationToken = default)
        {
            try
            {
                var id = (Guid)context.JobDetail.JobDataMap["CarVin"];
                _timersManagerService.StartTimer(id, (sender, e) => OnTimedEvent(sender, e, context));

                AddProgressState((int)context.JobDetail.JobDataMap["ProductionId"], ProductionProgressState.Started);

                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                return Task.CompletedTask;
            }
        }

        public Task JobWasExecuted(IJobExecutionContext context, JobExecutionException? jobException, CancellationToken cancellationToken = default)
        {
            try
            {
                var id = (Guid)context.JobDetail.JobDataMap["CarVin"];
                _timersManagerService.StopTimer(id);

                _hubContext.Clients.All.ReportProductionProgress(id, 100);

                AddProgressState((int)context.JobDetail.JobDataMap["ProductionId"], ProductionProgressState.Ended);

                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                return Task.CompletedTask;
            }
        }

        private async void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e, IJobExecutionContext context)
        {
            var id = (Guid)context.JobDetail.JobDataMap["CarVin"];
            var runTime = context.JobRunTime;
            int duration = _productionParams.Value.DurationInSeconds;
            var progress = Math.Round((runTime.TotalSeconds / duration) * 100);
            if (progress < 100)
            {
                await _hubContext.Clients.All.ReportProductionProgress(id, (int)progress);
                await AddProgressState(context);
            }
        }

        private async Task AddProgressState(IJobExecutionContext context)
        {
            OrderedProductionProgressState progressState = new OrderedProductionProgressState()
            {
                ProductionId = (int)context.JobDetail.JobDataMap["ProductionId"],
                State = _states[0],
                Date = DateTime.Now,
                Information = _states[0] == ProductionProgressState.VinNumberAssigned ? ((Guid)context.JobDetail.JobDataMap["CarVin"]).ToString() : null
            };

            await _factoryOrderService.AddProgressStateAsync(progressState);
            _states.RemoveAt(0);
        }

        private async Task AddProgressState(int productionId, ProductionProgressState state)
        {
            OrderedProductionProgressState progressState = new OrderedProductionProgressState()
            {
                ProductionId = productionId,
                State = state,
                Date = DateTime.Now
            };

            await _factoryOrderService.AddProgressStateAsync(progressState);
        }

    }
}
