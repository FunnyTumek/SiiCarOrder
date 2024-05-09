using System.Text.Json.Serialization;

namespace Sii.Dealer.Api.Middleware.Models;

public class ErrorDetails
{
    public int StatusCode { get; }

    public string Message { get; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Exception { get; }

    public ErrorDetails(int statusCode, string message, string? exception = null)
    {
        StatusCode = statusCode;
        Message = message;
        Exception = exception;
    }
}
