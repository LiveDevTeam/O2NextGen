using MediatR;

namespace O2NextGen.CertificateManagement.Domain.UseCases.ForCertificate.NewCertificate;

public class NewCertificateCommand : IRequest<NewCertificateCommandResult>
{
    public NewCertificateCommand(string userId, long categoryId, int languageId, string customerId)
    {
        UserId = userId;
        CategoryId = categoryId;
        LanguageId = languageId;
        CustomerId = customerId;
    }

    public string UserId { get; }
    public long CategoryId { get; }
    public int LanguageId { get; }
    public string CustomerId { get; }
}