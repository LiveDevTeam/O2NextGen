using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using O2NextGen.CertificateManagement.Application.Controllers;
using O2NextGen.CertificateManagement.Domain.UseCases.ForCategory.CreateCategory;
using O2NextGen.CertificateManagement.Domain.UseCases.ForCategory.GetCategories;
using O2NextGen.CertificateManagement.Domain.UseCases.ForCategory.GetCategory;

namespace O2NextGen.CertificateManagement.Application.Features.Categories
{
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        #region Fields

        private readonly IMediator _mediator;
        private readonly ILogger<CertificatesController> _logger;

        private static readonly string GetByIdActionName
            = nameof(GetByIdAsync).Replace("Async", string.Empty);
        #endregion


        #region Ctors

        public CategoriesController(IMediator mediator, ILogger<CertificatesController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        #endregion


        #region Methods

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetByIdAsync(long id, CancellationToken ct)
        {
            var result = await _mediator.Send(new GetCategoryQuery(id));

            if (result is null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _mediator.Send(new GetCategoriesQuery());
            return Ok(result.Categories);
        }

        [HttpPut]
        [HttpPost]
        [Route("")]
        public async Task<ActionResult<CreateCategoryCommandResult>> AddAsync(
            CreateCategoryDetailsCommandModel model,
            CancellationToken ct)
        {
            var result = await _mediator.Send(
                new CreateCategoryCommand());
            return CreatedAtAction(GetByIdActionName,
                new { id = result.Id }, result);
        }

        #endregion
    }
}

