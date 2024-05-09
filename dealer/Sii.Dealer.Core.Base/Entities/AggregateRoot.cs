namespace Sii.Dealer.Core.Base.Entities
{
    public abstract class AggregateRoot<T>
    {
        public T Id { get; protected set; }
    }
}
