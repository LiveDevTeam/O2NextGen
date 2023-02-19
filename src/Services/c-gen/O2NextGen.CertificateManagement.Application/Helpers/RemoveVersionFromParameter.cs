using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace O2NextGen.CertificateManagement.Application.Helpers;

public class RemoveVersionFromParameter : IOperationFilter
{

    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        var versionParameter = operation.Parameters.SingleOrDefault(p => p.Name.ToLower() == "v");
        operation.Parameters.Remove(versionParameter);
    }
}