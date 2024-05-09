using System.Collections;
using System.Collections.Generic;

namespace Sii.Dealer.Core.Application.DataTransferObjects
{
    public class FactoryDto
    {
        public string BrandCode { get; set; }
        public string ModelCode { get; set; }
        public string EquipmentVersionCode { get; set; }
        public string ClassCode { get; set; }
        public string EngineCode { get; set; }
        public string GearboxCode { get; set; }
        public string ColorCode { get; set; }
        public string InteriorCode { get; set; }
        public IEnumerable<string> AdditionalEquipmentCodes { get; set; }

    }
}
