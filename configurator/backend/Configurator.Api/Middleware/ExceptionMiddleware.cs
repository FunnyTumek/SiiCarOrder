using Configurator.Api.Dtos.Contracts;

namespace Configurator.Api.Middleware;

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
			await response.WriteAsJsonAsync(new ErrorDetailsDto
			{
				StatusCode = StatusCodes.Status500InternalServerError,
				Message = "Internal Server Error",
				Exception = _includeStackTrace ? e.ToString() : null
			});
		}
	}
}
