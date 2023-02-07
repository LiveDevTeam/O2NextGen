using MediatR;
using O2NextGen.Sdk.NetCore.Extensions;
using O2NextGen.SmartSubscriber.Domain.Data;
using O2NextGen.SmartSubscriber.Domain.Data.Queries;
using O2NextGen.SmartSubscriber.Domain.Entities;

namespace O2NextGen.SmartSubscriber.Domain.UseCases.ForCertificate.NewCertificate;

public class NewSubscriptionCommandHandler :
    IRequestHandler<NewSubscriptionCommand, NewSubscriptionCommandResult>
{
    private readonly IQueryHandler<ProductQuery, Product> _queryProductHandler;

    public NewSubscriptionCommandHandler(IQueryHandler<ProductQuery, Product> queryProductHandler)
    {
        this._queryProductHandler = queryProductHandler;
    }

    public async Task<NewSubscriptionCommandResult> Handle(NewSubscriptionCommand request, CancellationToken cancellationToken)
    {
        var category = await _queryProductHandler.HandleAsync(new ProductQuery(request.ProductId), cancellationToken);

        if (category == null)
            throw new ArgumentException($"ProductModel {nameof(category)} not found");

        LanguageInfo language;

        switch (request.LanguageId)
        {
            case 1:
            {
                language = new LanguageInfo
                {
                    LanguageId = request.LanguageId,
                    Firstname = string.Empty,
                    Lastname = string.Empty,
                    Middlename = string.Empty
                };
                break;
            }
            case 2:
            {
                language = new LanguageInfo
                {
                    LanguageId = request.LanguageId,
                    Firstname = string.Empty,
                    Lastname = string.Empty,
                    Middlename = string.Empty
                };
                break;
            }
            case 3:
            {
                language = new LanguageInfo
                {
                    LanguageId = request.LanguageId,
                    Firstname = string.Empty,
                    Lastname = string.Empty,
                    Middlename = string.Empty
                };
                break;
            }
            case 4:
            {
                language = new LanguageInfo
                {
                    LanguageId = request.LanguageId,
                    Firstname = string.Empty,
                    Lastname = string.Empty,
                    Middlename = string.Empty
                };
                break;
            }

            default:
            {
                throw new ArgumentException("languageId is not found");
            }
        }

        return new NewSubscriptionCommandResult(
            addedDate: DateTime.Now.ConvertToUnixTime(),
            modifiedDate: DateTime.Now.ConvertToUnixTime(),
            publishCode: "",
            lockInfo: string.Empty,
            lockedDate: 0,
            expiredDate: DateTime.Now.AddDays(1).ConvertToUnixTime(),
            publishDate: DateTime.Now.ConvertToUnixTime(),
            creatorId: request.UserId,
            customerId: request.CustomerId,
            ownerAccountId: Guid.Empty.ToString(),
            deletedDate: default(long),
            productId: request.ProductId,
            product: category
        );
    }
}