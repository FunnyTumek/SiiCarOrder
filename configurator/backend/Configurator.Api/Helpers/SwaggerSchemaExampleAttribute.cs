using System.Reflection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Configurator.Api;

[AttributeUsage(
	AttributeTargets.Class |
	AttributeTargets.Struct |
	AttributeTargets.Parameter |
	AttributeTargets.Property |
	AttributeTargets.Enum,
	AllowMultiple = false)]
public class SwaggerSchemaExampleAttribute : Attribute
{
	public SwaggerSchemaExampleAttribute(string example)
	{
		Example = example;
	}

	public SwaggerSchemaExampleAttribute(object? example)
	{
		Example = example?.ToString() ?? "null";
	}

	public string Example { get; set; }
}

public class SwaggerSchemaExampleFilter : ISchemaFilter
{
	public void Apply(OpenApiSchema schema, SchemaFilterContext context)
	{
		if (context.MemberInfo is not null)
		{
			var schemaAttribute = context.MemberInfo.GetCustomAttributes<SwaggerSchemaExampleAttribute>()
				.FirstOrDefault();
			if (schemaAttribute is not null)
			{
				ApplySchemaAttribute(schema, schemaAttribute);
			}
		}
	}

	private static void ApplySchemaAttribute(OpenApiSchema schema, SwaggerSchemaExampleAttribute schemaAttribute)
	{
		if (schemaAttribute.Example is not null)
		{
			schema.Example = new Microsoft.OpenApi.Any.OpenApiString(schemaAttribute.Example);
		}
	}
}
