using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using O2NextGen.ESender.Business.Models;

namespace O2NextGen.ESender.Business.Services
{
    public interface IEmailSenderService
    {
        Task<IReadOnlyCollection<EmailRequestModel>> GetAllAsync(CancellationToken ct);

        Task<EmailRequestModel> GetByIdAsync(long id, CancellationToken ct);

        Task<EmailRequestModel> UpdateAsync(EmailRequestModel emailRequestModel, CancellationToken ct);

        Task<EmailRequestModel> AddAsync(EmailRequestModel emailRequestModel, CancellationToken ct);
        
        Task RemoveAsync(long id, CancellationToken ct);
    }
}