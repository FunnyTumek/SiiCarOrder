using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sii.Dealer.Core.Application.DataTransferObjects
{
    public class FactoryResponse
    {
        public int FactoryId { get; set; }
        public DateTime PlannedDeliveryDate { get; set; }

        public FactoryResponse(int factoryId, DateTime plannedDeliveryDate)
        {
            FactoryId = factoryId;
            PlannedDeliveryDate = plannedDeliveryDate;
        }
    }
}
