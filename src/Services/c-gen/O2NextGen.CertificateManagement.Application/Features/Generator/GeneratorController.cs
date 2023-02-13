using Microsoft.AspNetCore.Mvc;

namespace O2NextGen.CertificateManagement.Application.Features.Generator;

[ApiVersion("1.0")]
[ApiVersion("1.1")]
[ApiController]
// ReSharper disable once RouteTemplates.RouteParameterConstraintNotResolved
[Route("api/v{v:apiVersion}/[controller]")]
public class GeneratorController
{
}