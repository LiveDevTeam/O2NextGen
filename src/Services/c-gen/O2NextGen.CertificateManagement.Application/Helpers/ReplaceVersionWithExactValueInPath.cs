using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace O2NextGen.CertificateManagement.Application.Helpers;

public class ReplaceVersionWithExactValueInPath : IDocumentFilter
{
    public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
    {
        if (swaggerDoc == null)
            throw new ArgumentNullException(nameof(swaggerDoc));

        var replacements = new OpenApiPaths();

        foreach (var (key, value) in swaggerDoc.Paths)
        {
            replacements.Add(key.Replace("v{v}", swaggerDoc.Info.Version, StringComparison.InvariantCulture), value);
        }

        swaggerDoc.Paths = replacements;
    }
}