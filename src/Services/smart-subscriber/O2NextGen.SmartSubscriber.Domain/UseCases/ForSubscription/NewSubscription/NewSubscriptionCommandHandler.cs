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

        var languageInfos = new List<LanguageInfo> { language };

        return new NewSubscriptionCommandResult(
            AddedDate: DateTime.Now.ConvertToUnixTime(),
            ModifiedDate: DateTime.Now.ConvertToUnixTime(),
            PublishCode: "",
            LockInfo: string.Empty,
            LockedDate: 0,
            ExpiredDate: DateTime.Now.AddDays(category.TimeLifeInDays).ConvertToUnixTime(),
            PublishDate: DateTime.Now.ConvertToUnixTime(),
            CreatorId: request.UserId,
            CustomerId: request.CustomerId,
            OwnerAccountId: Guid.Empty.ToString(),
            DeletedDate: default(long),
            CategoryId: request.ProductId,
            product: category,
            LanguageInfos: languageInfos
        );
    }
}