using System.ComponentModel.DataAnnotations;
using Sii.Dealer.SharedKernel.Helpers;

namespace Sii.Dealer.Core.Application.DataTransferObjects;

public class ColorDto :IConfigurationOptionDto
{
    [Required]
    [SwaggerSchemaExample("CO01")]
    public string Code { get; set; }

    [Required]
    [SwaggerSchemaExample("black")]
    public string Name { get; set; }

    [Required]
    [SwaggerSchemaExample(true)]
    public bool Availability { get; set; }


    [SwaggerSchemaExample("2000")]
    public decimal Price { get; set; }
}
