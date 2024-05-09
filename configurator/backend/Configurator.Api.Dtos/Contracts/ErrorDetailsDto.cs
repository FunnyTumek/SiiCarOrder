using System.Text.Json.Serialization;

namespace Configurator.Api.Dtos.Contracts
{
    public class ErrorDetailsDto
    {
        public int StatusCode { get; set; }
        public string Message { get; set; } = string.Empty;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Exception { get; set; }
    }
}
