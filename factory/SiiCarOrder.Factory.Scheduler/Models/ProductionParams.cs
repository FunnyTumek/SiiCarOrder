using System.ComponentModel.DataAnnotations;

namespace SiiCarOrder.Factory.Scheduler.Models
{
    public sealed class ProductionParams
    {
        public static string Name => "ProductionParams";
        [Required]
        public int DurationInSeconds { get; set; }
    }
}
