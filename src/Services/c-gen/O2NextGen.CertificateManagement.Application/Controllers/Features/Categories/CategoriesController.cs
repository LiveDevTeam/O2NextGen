using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using O2NextGen.CertificateManagement.Application.Controllers.ViewModels;
using O2NextGen.CertificateManagement.Application.Services.Interfaces;
using O2NextGen.CertificateManagement.Domain.UseCases.ForCategory.CreateCategory;
using O2NextGen.CertificateManagement.Domain.UseCases.ForCategory.DeleteCategory;
using O2NextGen.CertificateManagement.Domain.UseCases.ForCategory.GetCategories;
using O2NextGen.CertificateManagement.Domain.UseCases.ForCategory.GetCategory;
using O2NextGen.CertificateManagement.Domain.UseCases.ForCategory.UpdateCategory;

namespace O2NextGen.CertificateManagement.Application.Controllers.Features.Categories;

[Authorize]
[ApiController]
[ApiVersion("1.0")]
// [ApiVersion("1.1")]
// ReSharper disable once RouteTemplates.RouteParameterConstraintNotResolved
[Route("api/v{v:apiVersion}/[controller]")]
public class CategoriesController : ControllerBase
{
    #region Ctors

    public CategoriesController(IMediator mediator, ILogger<CategoriesController> logger, ISubscribeService subscribeService)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _subscribeService = subscribeService ?? throw new ArgumentNullException(nameof(subscribeService));;
    }

    #endregion

    
    #region Fields

    private readonly IMediator _mediator;
    private readonly ILogger<CategoriesController> _logger;
    private readonly ISubscribeService _subscribeService;

    private static readonly string GetByIdActionName
        = nameof(GetByIdAsync).Replace("Async", string.Empty);

    #endregion


    #region Methods

    [MapToApiVersion("1.0")]
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
    
    [MapToApiVersion("1.0")]
    [HttpGet]
    [Route("")]
    public async Task<IActionResult> GetAllAsync()
    {
        var result = await _mediator.Send(new GetCategoriesQuery());
        return Ok(result.Categories);
    }

    [MapToApiVersion("1.0")]
    [HttpPut]
    [HttpPost]
    [Route("")]
    public async Task<ActionResult<CreateCategoryCommandResult>> AddAsync(
        [FromBody] CategoryViewModel viewModel,
        CancellationToken ct)
    {
        var productId = _subscribeService.GetProductId();
        var tenantId = _subscribeService.GetTenantInfo();
        var result = await _mediator.Send(
            new CreateCategoryCommand(
                viewModel.CategoryName,
                viewModel.QuantityCertificates,
                viewModel.CategoryDescription,
                viewModel.CategorySeries),
            ct);
        return CreatedAtAction(GetByIdActionName,
            new {id = result.Id}, result);
    }

    [MapToApiVersion("1.0")]
    [HttpPut]
    [Route("{id}")]
    public async Task<ActionResult<UpdateCategoryDetailsCommandResult>> UpdateAsync(
        long id, [FromBody] CategoryViewModel viewModel, CancellationToken ct)
    {
        var result = await _mediator.Send(
            new UpdateCategoryDetailsCommand(
                viewModel.Id,
                viewModel.CategoryName,
                viewModel.CategoryDescription,
                viewModel.CategorySeries,
                viewModel.CustomerId,
                viewModel.QuantityCertificates,
                viewModel.QuantityPublishCode), ct);

        if (result is null) return NotFound();

        return result;
    }
    
    [MapToApiVersion("1.0")]
    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> RemoveAsync(long id, CancellationToken ct)
    {
        await _mediator.Send(new DeleteCategoryCommand(id), ct);
        return NoContent();
    }

    #endregion
}