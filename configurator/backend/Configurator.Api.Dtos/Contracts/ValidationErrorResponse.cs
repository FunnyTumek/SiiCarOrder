using Configurator.Api.Dtos.Contracts.Helpers;
using Swashbuckle.AspNetCore.Annotations;

namespace Configurator.Api.Dtos.Contracts
{
	[SwaggerSchema("Object containing the errors that occurred during validation")]
	public class ValidationErrorResponse
	{
		public ValidationErrorResponse(string title, IEnumerable<string> errors)
		{
			Title = title;
			Errors = errors;
		}

		[SwaggerSchemaExample("The request body was invalid")]
		public string Title { get; set; }

		[SwaggerSchemaExample("[\"The brand is required\", \"The model is required\"]")]
		public IEnumerable<string> Errors { get; set; }
	}
}
