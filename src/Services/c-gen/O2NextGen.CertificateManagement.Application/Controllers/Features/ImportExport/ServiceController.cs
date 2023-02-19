using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace O2NextGen.CertificateManagement.Application.Controllers.Features.ImportExport;
[Authorize]
[Route("api/[controller]")]
[ApiController]
public class ServiceController : ControllerBase
{
}