using MediatR;
using Microsoft.AspNetCore.Mvc;
using O2NextGen.CertificateManagement.Domain.UseCases.ForCategory.CreateCategory;
using O2NextGen.CertificateManagement.Domain.UseCases.ForCategory.DeleteCategory;
using O2NextGen.CertificateManagement.Domain.UseCases.ForCategory.GetCategories;
using O2NextGen.CertificateManagement.Domain.UseCases.ForCategory.GetCategory;
using O2NextGen.CertificateManagement.Domain.UseCases.ForCategory.UpdateCategory;

namespace O2NextGen.CertificateManagement.Application.Features.Categories
{
    [Route("api/[controller]")]
    //[ApiVersion("1.0")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        #region Fields

        private readonly IMediator _mediator;
        private readonly ILogger<CategoriesController> _logger;

        private static readonly string GetByIdActionName
            = nameof(GetByIdAsync).Replace("Async", string.Empty);

        #endregion


        #region Ctors

        public CategoriesController(IMediator mediator, ILogger<CategoriesController> logger)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        #endregion


        #region Methods

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetByIdAsync(long id, CancellationToken ct)
        {
            _logger.LogInformation("Call API method {ByIdAsyncName}: id = {Id}", nameof(GetByIdAsync), id);
            
            var result = await _mediator.Send(new GetCategoryQuery(id), ct);

            if (result is null)
            {
                _logger.LogError("GetByIdAsync: not found  id = {Id}", id);
                return NotFound();
            }

            _logger.LogInformation("GetByIdAsync: OK");
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
            [FromBody] CreateCategoryModel model,
            CancellationToken ct)
        {
            var result = await _mediator.Send(
                new CreateCategoryCommand(
                    model.CategoryName,
                    model.QuantityCertificates,
                    model.CategoryDescription,
                    model.CategorySeries),
                ct);
            return CreatedAtAction(GetByIdActionName,
                new {id = result.Id}, result);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<UpdateCategoryDetailsCommandResult>> UpdateAsync(
            long id, [FromBody] UpdateCategoryModel model, CancellationToken ct)
        {
            var result = await _mediator.Send(
                new UpdateCategoryDetailsCommand(
                    model.Id,
                    model.CategoryName,    
                    model.CategoryDescription,
                    model.CategorySeries,
                    model.CustomerId,  
                    model.QuantityCertificates,
                    model.QuantityPublishCode), ct);

            if (result is null)
            {
                return NotFound();
            }

            return result;
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> RemoveAsync(long id, CancellationToken ct)
        {
            await _mediator.Send(new DeleteCategoryCommand(id), ct);
            return NoContent();
        }
        #endregion
    }
}