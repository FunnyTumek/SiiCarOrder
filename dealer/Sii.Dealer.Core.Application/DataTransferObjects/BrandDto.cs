using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Sii.Dealer.SharedKernel.Helpers;

namespace Sii.Dealer.Core.Application.DataTransferObjects;

public class BrandDto : IConfigurationOptionDto
{
    [Required]
    [SwaggerSchemaExample("BC01")]
    public string Code { get; set; }

    [Required]
    [SwaggerSchemaExample("Sii")]
    public string Name { get; set; }

    [Required]
    [SwaggerSchemaExample("true")]
    public bool Availability { get; set; }

    [Required]
    [SwaggerSchemaExample("2000")]
    public decimal Price { get; set; }
}
