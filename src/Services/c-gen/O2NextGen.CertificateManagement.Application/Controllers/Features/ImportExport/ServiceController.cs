using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace O2NextGen.CertificateManagement.Application.Controllers.Features.ImportExport;
[Authorize]
[Route("api/[controller]")]
[ApiController]
[ApiVersion("1.0")]
//[ApiVersion("1.1")]
public class ServiceController : ControllerBase
{
}