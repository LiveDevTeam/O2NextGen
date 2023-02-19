using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using O2NextGen.CertificateManagement.Application.Services;

namespace O2NextGen.CertificateManagement.Application.Controllers.Features.Projects;
[Authorize]
[ApiVersion("1.0")]
[ApiVersion("1.1")]
[ApiController]
// ReSharper disable once RouteTemplates.RouteParameterConstraintNotResolved
[Route("api/v{v:apiVersion}/[controller]")]
public class ProjectsController : ControllerBase
{
    private readonly ICustomerService _customerService;

    public ProjectsController(ICustomerService customerService)
    {
        _customerService = customerService;
        memoryList = new List<ProjectViewModel>
        {
            new()
            {
                Name = "PROJECT PFR",
                Description = "Project of PFR CENTER",
                TenantId = _customerService.CustomerId
            },
            new()
            {
                Name = "PROJECT PFR 2",
                Description = "Project of PFR CENTER",
                TenantId = _customerService.CustomerId
            }
        };
    }

    private List<ProjectViewModel> memoryList { get; }

    [HttpGet]
    [ProducesResponseType((int) HttpStatusCode.NotFound)]
    [ProducesResponseType((int) HttpStatusCode.BadRequest)]
    [ProducesResponseType((int) HttpStatusCode.Accepted)]
    [Route("{id:long}")]
    public IActionResult GetById()
    {
        return Ok(memoryList.FirstOrDefault());
    }

    [HttpGet]
    [Route("")]
    [ProducesResponseType((int) HttpStatusCode.NotFound)]
    [ProducesResponseType((int) HttpStatusCode.BadRequest)]
    [ProducesResponseType((int) HttpStatusCode.Accepted)]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(memoryList);
    }

    [HttpPut]
    [Route("id")]
    [ProducesResponseType((int) HttpStatusCode.NotFound)]
    [ProducesResponseType((int) HttpStatusCode.BadRequest)]
    [ProducesResponseType((int) HttpStatusCode.Accepted)]
    public async Task<IActionResult> UpdateAsync()
    {
        return Ok(memoryList.FirstOrDefault());
    }

    [HttpPut]
    [HttpPost]
    [Route("")]
    [ProducesResponseType((int) HttpStatusCode.Created)]
    [ProducesResponseType((int) HttpStatusCode.BadRequest)]
    public async Task<IActionResult> AddAsync()
    {
        return Ok(memoryList.FirstOrDefault());
    }


    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType((int) HttpStatusCode.NoContent)]
    public async Task<IActionResult> RemoveAsync(long id, CancellationToken ct)
    {
        return NoContent();
    }
}