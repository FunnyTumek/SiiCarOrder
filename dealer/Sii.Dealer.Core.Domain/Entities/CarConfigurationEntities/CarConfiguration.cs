using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sii.Dealer.Core.Domain.Entities
{
    public class CarConfiguration
    {
        public int Id { get; set; }

        public int OrderId { get; set; }
        public virtual Order Order { get; set; }

        public string BrandCode { get; set; }
        public virtual Brand Brand { get; set; }

        public string ModelCode { get; set; }
        public virtual Model Model { get; set; }

        public string EquipmentVersionCode { get; set; }
        public virtual EquipmentVersion EquipmentVersion { get; set; }

        public string CarClassCode { get; set; }
        public virtual CarClass CarClass { get; set; }

        public string EngineCode { get; set; }
        public virtual Engine Engine { get; set; }

        public string GearboxCode { get; set; }
        public virtual Gearbox Gearbox { get; set; }

        public string ColorCode { get; set; }
        public virtual Color Color { get; set; }

        public string InteriorCode { get; set; }
        public virtual Interior Interior { get; set; }

        public AdditionalEquipmentSet AdditionalEquipmentSet { get; set; }

        [NotMapped]
        public IEnumerable<string> AdditionalEquipmentCodes { get; set; }

    }
}
