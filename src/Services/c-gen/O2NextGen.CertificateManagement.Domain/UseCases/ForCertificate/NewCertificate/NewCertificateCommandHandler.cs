using MediatR;
using O2NextGen.CertificateManagement.Domain.Data;
using O2NextGen.CertificateManagement.Domain.Data.Queries;
using O2NextGen.CertificateManagement.Domain.Entities;
using O2NextGen.Sdk.NetCore.Extensions;

namespace O2NextGen.CertificateManagement.Domain.UseCases.ForCertificate.NewCertificate
{
    public class NewCertificateCommandHandler :
        IRequestHandler<NewCertificateCommand, NewCertificateCommandResult>
    {
        private readonly IQueryHandler<CategoryQuery, Category> _queryCategoryHandler;

        public NewCertificateCommandHandler(IQueryHandler<CategoryQuery, Category> queryCategoryHandler)
        {
            this._queryCategoryHandler = queryCategoryHandler;
        }

        public async Task<NewCertificateCommandResult> Handle(NewCertificateCommand request, CancellationToken cancellationToken)
        {
            var category = await _queryCategoryHandler.HandleAsync(new CategoryQuery(request.CategoryId), cancellationToken);

            if (category == null)
                throw new ArgumentException($"CategoryModel {nameof(category)} not found");

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

            return new NewCertificateCommandResult(
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
                CategoryId: request.CategoryId,
                Category: category,
                LanguageInfos: languageInfos
            );
        }
    }
}

