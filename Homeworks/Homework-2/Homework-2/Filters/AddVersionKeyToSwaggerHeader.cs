using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Homework_2.Middlewares
{
    // Adding "app-version" key to Swagger Header using IOperationFilter.
    public class AddVersionKeyToSwaggerHeader : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "app-version",
                @In = ParameterLocation.Header,
                Description = "Please enter a version number",
                Required = true,
                Schema = new OpenApiSchema
                {
                    Type = "string",
                    Default = new OpenApiString("1.0.5")
                    // This is default app version number from "appsettings.json" file.
                }
            });
        }
    }
}


