using Sii.Dealer.Api.Middleware.Models;

namespace Sii.Dealer.Api.Middleware
{
    public class ExceptionMiddleware : IMiddleware
    {
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly bool _includeStackTrace;

        public ExceptionMiddleware(ILogger<ExceptionMiddleware> logger, bool includeStackTrace = false)
        {
            _logger = logger;
            _includeStackTrace = includeStackTrace;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Unhandled exception occurred");
                var response = context.Response;
                response.ContentType = "application/json";
                response.StatusCode = StatusCodes.Status500InternalServerError;
                await response.WriteAsJsonAsync(new ErrorDetails(
                    StatusCodes.Status500InternalServerError,
                    $"Internal Server Error {e.Message}",
                    _includeStackTrace ? e.ToString() : null)
                );
            }
        }
    }
}
