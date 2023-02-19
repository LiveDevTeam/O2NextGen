using Microsoft.AspNetCore.Mvc;

namespace O2NextGen.CertificateManagement.Application.Features.Templates;

[ApiVersion("1.0")]
// [ApiVersion("1.1")]
[ApiController]
// ReSharper disable once RouteTemplates.RouteParameterConstraintNotResolved
[Route("api/v{v:apiVersion}/[controller]")]
public class TemplateController : ControllerBase
{
    [HttpGet]
    public IActionResult GetTemplate()
    {
        return Ok();
    }

    [HttpGet("settings")]
    public IActionResult GetSettingsOtTemplate()
    {
        return Ok();
    }
}