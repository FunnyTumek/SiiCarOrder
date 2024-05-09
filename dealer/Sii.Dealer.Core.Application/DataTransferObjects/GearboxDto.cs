using System.ComponentModel.DataAnnotations;
using Sii.Dealer.SharedKernel.Helpers;

namespace Sii.Dealer.Core.Application.DataTransferObjects;

public class GearboxDto : IConfigurationOptionDto
{
    [Required]
    [SwaggerSchemaExample("GC01")]
    public string Code { get; set; }

    [Required]
    [SwaggerSchemaExample("GT01")]
    public string Name { get; set; }

    [Required]
    [SwaggerSchemaExample("manual")]
    public string Type { get; set; }

    [Required]
    [SwaggerSchemaExample("5")]
    public int GearsCount { get; set; }

    [Required]
    [SwaggerSchemaExample(true)]
    public bool Availability { get; set; }

    [Required]
    [SwaggerSchemaExample("2000")]
    public decimal Price { get; set; }
}
