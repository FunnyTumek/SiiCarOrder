using System.ComponentModel.DataAnnotations;
using Sii.Dealer.SharedKernel.Helpers;

namespace Sii.Dealer.Core.Application.DataTransferObjects;

public class EngineDto : IConfigurationOptionDto
{
    [Required]
    [SwaggerSchemaExample("EC01")]
    public string Code { get; set; }

    [SwaggerSchemaExample("1.0 TSI")]
    public string Name { get; set; }

    [Required]
    [SwaggerSchemaExample("998")]
    public int Capacity { get; set; }

    [Required]
    [SwaggerSchemaExample("75")]
    public int Power { get; set; }

    [Required]
    [SwaggerSchemaExample("Petrol")]
    public string Type { get; set; }

    [Required]
    [SwaggerSchemaExample(true)]
    public bool Availability { get; set; }

    [Required]
    [SwaggerSchemaExample("2000")]
    public decimal Price { get; set; }
}
