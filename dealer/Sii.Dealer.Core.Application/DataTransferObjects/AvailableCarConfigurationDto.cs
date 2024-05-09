using Sii.Dealer.SharedKernel.Helpers;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sii.Dealer.Core.Application.DataTransferObjects
{
    public class AvailableCarConfigurationDto
    {
		public AvailableCarConfigurationDto()
		{ 
		}
        public int Id { get; set; }

        [Required]
        [SwaggerSchemaExample("BC01")]
        public string BrandCode { get; set; }

        public BrandDto Brand { get; set; }

        [Required]
        [SwaggerSchemaExample("MC01")]
        public string ModelCode { get; set; }

        public ModelDto Model { get; set; }

        [Required]
        [SwaggerSchemaExample("EV01")]
        public string EquipmentVersionCode { get; set; }

        public EquipmentVersionDto EquipmentVersion { get; set; }

        [Required]
        [SwaggerSchemaExample("CC01")]
        public string ClassCode { get; set; }

        public CarClassDto Class { get; set; }

        [Required]
        [SwaggerSchemaExample("EC01")]
        public string EngineCode { get; set; }

        public EngineDto Engine { get; set; }

        [Required]
        [SwaggerSchemaExample("GC01")]
        public string GearboxCode { get; set; }

        public GearboxDto Gearbox { get; set; }

        [Required]
        [SwaggerSchemaExample("CO01")]
        public string ColorCode { get; set; }

        public ColorDto Color { get; set; }

        [Required]
        [SwaggerSchemaExample("IC01")]
        public string InteriorCode { get; set; }

        public InteriorDto Interior { get; set; }

        [SwaggerSchemaExample("AE01, AE02, AE03")]
        public ICollection<AdditionalEquipmentDto> AdditionalEquipments { get; set; }

        [SwaggerSchemaExample("AE01")]
        public ICollection<string> AdditionalEquipmentCodes { get; set; }

        [SwaggerSchemaExample("129999.99")]
        public decimal Price { get; set; }
    }

}
