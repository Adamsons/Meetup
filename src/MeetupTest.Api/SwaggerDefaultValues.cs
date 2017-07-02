using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Linq;

namespace MeetupTest.Api
{
    public class SwaggerDefaultValues : IOperationFilter
    {
        public void Apply(Operation operation, OperationFilterContext context)
        {
            foreach (var parameter in operation.Parameters.OfType<NonBodyParameter>())
            {
                var description = context.ApiDescription.ParameterDescriptions.First(p => p.Name == parameter.Name);

                if (parameter.Description == null)
                    parameter.Description = description.ModelMetadata.Description;

                if (parameter.Default == null)
                    parameter.Default = description.RouteInfo.DefaultValue;

                parameter.Required |= !description.RouteInfo.IsOptional;
            }
        }
    }
}