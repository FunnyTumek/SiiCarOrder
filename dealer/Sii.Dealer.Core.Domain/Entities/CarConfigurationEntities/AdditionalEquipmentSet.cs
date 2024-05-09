namespace Sii.Dealer.Core.Domain.Entities
{
    public class AdditionalEquipmentSet
    {
        public int Id { get; private set; }

        public int CarConfigurationId { get; private set; }

        public AdditionalEquipment AdditionalEquipment { get; private set; }

        public virtual CarConfiguration CarConfiguration { get; private set; }
    }
}
