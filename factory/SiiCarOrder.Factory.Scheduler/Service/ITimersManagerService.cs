using System.Timers;

namespace SiiCarOrder.Factory.Scheduler.Service
{
    public interface ITimersManagerService
    {
        Dictionary<Guid, System.Timers.Timer> Timers { get; set; }

        void AddTimer(Guid id);
        void RemoveTimer(Guid id);
        void StartTimer(Guid id);
        void StopTimer(Guid id);
        void AddTimer(Guid id, ElapsedEventHandler elapseMethod);
        void StartTimer(Guid id, ElapsedEventHandler elapseMethod);
    }
}
