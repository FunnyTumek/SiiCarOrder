using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Sii.Dealer.SharedKernel.Helpers;

namespace Sii.Dealer.Core.Application.DataTransferObjects;

public class CarConfigurationDto 
{
    [Required]
    [SwaggerSchemaExample("BC01")]
    public string BrandCode { get; set; }

    [Required]
    [SwaggerSchemaExample("MC01")]
    public string ModelCode { get; set; }

    [Required]
    [SwaggerSchemaExample("EV01")]
    public string EquipmentVersionCode { get; set; }

    [Required]
    [SwaggerSchemaExample("CC01")]
    public string ClassCode { get; set; }

    [Required]
    [SwaggerSchemaExample("EC01")]
    public string EngineCode { get; set; }

    [Required]
    [SwaggerSchemaExample("GC01")]
    public string GearboxCode { get; set; }

    [Required]
    [SwaggerSchemaExample("CO01")]
    public string ColorCode { get; set; }

    [Required]
    [SwaggerSchemaExample("IC01")]
    public string InteriorCode { get; set; }

    public IEnumerable<string> AdditionalEquipmentCodes { get; set; }
}
