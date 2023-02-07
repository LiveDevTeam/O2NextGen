using MediatR;
using Microsoft.AspNetCore.Mvc;
using O2NextGen.SmartSubscriber.Domain.UseCases.ForCertificate.CreateCertificate;
using O2NextGen.SmartSubscriber.Domain.UseCases.ForCertificate.DeleteCertificate;
using O2NextGen.SmartSubscriber.Domain.UseCases.ForCertificate.GetCertificate;
using O2NextGen.SmartSubscriber.Domain.UseCases.ForCertificate.GetCertificates;
using O2NextGen.SmartSubscriber.Domain.UseCases.ForCertificate.UpdateCertificate;

namespace O2NextGen.SmartSubscriber.Application.Features.Subcriptions;

[Route("api/[controller]")]
[ApiController]
public partial class SubscriptionsController : ControllerBase
{
    #region Fields

    private readonly IMediator _mediator;
    private readonly ILogger<SubscriptionsController> _logger;

    private static readonly string GetByIdActionName
        = nameof(GetByIdAsync).Replace("Async", string.Empty);
    #endregion


    #region Ctors

    public SubscriptionsController(IMediator mediator, ILogger<SubscriptionsController> logger)
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
        var result = await _mediator.Send(new GetSubscriptionQuery(id), ct);

        if (result is null)
            return NotFound();

        return Ok(result);
    }

    [HttpGet]
    [Route("")]
    public async Task<IActionResult> GetAllAsync()
    {
        var result = await _mediator.Send(new GetSubscriptionsQuery());
        return Ok(result.Subscriptions);
    }

    [HttpPut]
    [Route("id")]
    public async Task<ActionResult<UpdateSubscriptionDetailsCommandResult>> UpdateAsync(
        long id, [FromBody] UpdateSubscriptionDetailsCommandModel model, CancellationToken ct)
    {
        var result = await _mediator.Send(
            new UpdateSubscriptionDetailsCommand(
                id,
                model.ExternalId,
                model.ModifiedDate,
                model.AddedDate,
                model.DeletedDate,
                model.IsDeleted,
                model.OwnerAccountId,
                model.CustomerId,
                model.ExpiredDate,
                model.PublishDate,
                model.CreatorId,
                model.PublishCode,
                model.IsVisible,
                model.ProductId,
                model.Product,
                model.Lock,
                model.LockedDate,
                model.LockInfo,
                model.LanguageInfos), ct);

        if (result is null)
        {
            return NotFound();
        }

        return result;
    }

    [HttpPut]
    [HttpPost]
    [Route("")]
    public async Task<ActionResult<CreateSubscriptionCommandResult>> AddAsync(
        [FromBody] CreateSubscriptionDetailsCommandModel model,
        CancellationToken ct)
    {
        var result = await _mediator.Send(
            new CreateSubscriptionCommand(
                model.ExternalId,
                model.IsDeleted,
                model.OwnerAccountId,
                model.CustomerId,
                model.ExpiredDate,
                model.PublishDate,
                model.CreatorId,
                model.PublishCode,
                model.IsVisible,
                model.ProductId,
                model.Product,
                model.Lock,
                model.LockedDate,
                model.LockInfo,
                model.LanguageInfos
            ));
        return CreatedAtAction(GetByIdActionName,
            new { id = result.Id }, result);
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> RemoveAsync(long id, CancellationToken ct)
    {
        await _mediator.Send(new DeleteSubscriptionCommand(id), ct);
        return NoContent();
    }

    #endregion
}