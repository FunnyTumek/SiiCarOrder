using System.ComponentModel.DataAnnotations;
using Sii.Dealer.SharedKernel.Helpers;

namespace Sii.Dealer.Core.Application.DataTransferObjects;

public class EquipmentVersionDto : IConfigurationOptionDto
{
    [Required]
    [SwaggerSchemaExample("EV01")]
    public string Code { get; set; }

    [Required]
    [SwaggerSchemaExample("Basic")]
    public string Name { get; set; }

    [Required]
    [SwaggerSchemaExample(true)]
    public bool Availability { get; set; }

    [Required]
    [SwaggerSchemaExample("2000")]
    public decimal Price { get; set; }
}
