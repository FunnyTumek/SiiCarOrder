using Microsoft.Extensions.Options;
using Quartz;
using SiiCarOrder.Factory.Scheduler.Models;
using System.Diagnostics;
using System.Timers;

namespace SiiCarOrder.Factory.Scheduler.Service
{
    public class TimersManagerService : ITimersManagerService
    {
        public Dictionary<Guid, System.Timers.Timer> Timers { get; set; }
        private readonly IOptions<ProductionParams> _productionParams;

        public TimersManagerService(IOptions<ProductionParams> productionParams) 
        { 
            Timers = new Dictionary<Guid, System.Timers.Timer>();
            _productionParams = productionParams;
        }

        public void AddTimer(Guid id)
        {
            if (!Timers.ContainsKey(id))
            {
                int productionDuration = _productionParams.Value.DurationInSeconds;
                System.Timers.Timer timer = new System.Timers.Timer((productionDuration / 10) * 1000);
                Timers.Add(id, timer);
            }
        }

        public void RemoveTimer(Guid id)
        {
            if (Timers.ContainsKey(id))
            {
                Timers[id].Dispose();
                Timers.Remove(id);
            }
        }

        public void StartTimer(Guid id)
        {
            AddTimer(id);
            Timers[id].Start();
        }

        public void StopTimer(Guid id)
        {
            if (Timers.ContainsKey(id))
            {
                Timers[id].Stop();
            }
            RemoveTimer(id);
        }

        public void StartTimer(Guid id, ElapsedEventHandler elapseMethod)
        {
            AddTimer(id, elapseMethod);
            Timers[id].Start();
        }

        public void AddTimer(Guid id, ElapsedEventHandler elapseMethod)
        {
            if (!Timers.ContainsKey(id))
            {
                int productionDuration = _productionParams.Value.DurationInSeconds;
                System.Timers.Timer timer = new System.Timers.Timer((productionDuration / 10) * 1000);
                timer.Elapsed += elapseMethod;
                Timers.Add(id, timer);
            }
        }

    }
}
