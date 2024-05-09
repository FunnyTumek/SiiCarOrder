namespace Sii.Dealer.Core.Domain.Entities
{
    public interface IConfigurationOption
    {
        string Code { get; }

        string Name { get; }

        bool Availability { get; }

        decimal Price { get; }
       
    }
}
