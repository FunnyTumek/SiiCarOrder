using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sii.Dealer.Core.Domain.Entities.CarConfigurationEntities
{
    public class AvailableConfigurationAdditionalEquipment
    {
        public AvailableConfigurationAdditionalEquipment()
        {

        }
        public AvailableConfigurationAdditionalEquipment(int availableCarConfigurationId, string equipmentCode)
        {
            AvailableConfigurationId = availableCarConfigurationId;
            EquipmentCode = equipmentCode;
        }

        public AvailableCarConfiguration AvailableCarConfiguration { get; private set; }
        public int AvailableConfigurationId { get; private set; }
        public string EquipmentCode { get; private set; }
        public AdditionalEquipment AdditionalEquipment { get; private set; }
    }
}
