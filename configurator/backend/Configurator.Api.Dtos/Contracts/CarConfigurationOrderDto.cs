using System.Text.Json.Serialization;

namespace Configurator.Api.Dtos.Contracts
{
    public class CarConfigurationOrderDto
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

		[JsonConstructor]
		public CarConfigurationOrderDto(string brandCode, string modelCode, string equipmentVersionCode, string classCode, string engineCode, string gearboxCode, string colorCode, string interiorCode, IEnumerable<string> additionalEquipmentCodes)
		{
			BrandCode = brandCode;
			ModelCode = modelCode;
			EquipmentVersionCode = equipmentVersionCode;
			ClassCode = classCode;
			EngineCode = engineCode;
			GearboxCode = gearboxCode;
			ColorCode = colorCode;
			InteriorCode = interiorCode;
			AdditionalEquipmentCodes = additionalEquipmentCodes;
		}
	}
}
