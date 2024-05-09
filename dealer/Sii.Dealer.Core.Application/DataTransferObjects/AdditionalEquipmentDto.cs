using System.ComponentModel.DataAnnotations;
using Sii.Dealer.SharedKernel.Helpers;

namespace Sii.Dealer.Core.Application.DataTransferObjects;

public class AdditionalEquipmentDto : IConfigurationOptionDto
{
    [Required]
    [SwaggerSchemaExample("AE01")]
    public string Code { get; set; }

    [Required]
    [SwaggerSchemaExample("comfort seat package")]
    public string Name { get; set; }

    [Required]
    [SwaggerSchemaExample(true)]
    public bool Availability { get; set; }

    [Required]
    [SwaggerSchemaExample("2000")]
    public decimal Price { get; set; }
}
