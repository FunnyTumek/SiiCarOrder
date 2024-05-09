using Sii.Dealer.Core.Base.Entities;
using System.Collections.Generic;

namespace Sii.Dealer.Core.Domain.Entities.CarConfigurationEntities
{
    public class AvailableCarConfiguration : AggregateRoot<int>
	{
        public AvailableCarConfiguration(){}

        public AvailableCarConfiguration(string brandCode, string modelCode, string equipmentVersionCode, string carClassClode, string engineCode, string gearboxCode, string colorCode, string interiorCode)
        {
			BrandCode = brandCode;
			ModelCode = modelCode;
			EquipmentVersionCode = equipmentVersionCode;
			ClassCode = carClassClode;
			EngineCode = engineCode;
			GearboxCode = gearboxCode;
			ColorCode = colorCode;
			InteriorCode = interiorCode;
		}

		public string BrandCode { get; set; }

		public virtual Brand Brand { get; set; }

		public string ModelCode { get; set; }

		public virtual Model Model { get; set; }

		public string EquipmentVersionCode { get; set; }

		public virtual EquipmentVersion EquipmentVersion { get; set; }

		public string ClassCode { get; set; }

		public virtual CarClass Class { get; set; }

		public string EngineCode { get; set; }

		public virtual Engine Engine { get; set; }

		public string GearboxCode { get; set; }

		public virtual Gearbox Gearbox { get; set; }

		public string ColorCode { get; set; }

		public virtual Color Color { get; set; }

		public string InteriorCode { get; set; }

		public virtual Interior Interior { get; set; }

		public virtual ICollection<AvailableConfigurationAdditionalEquipment> ConfigurationAdditionalEquipments { get; set; }
    }
}
