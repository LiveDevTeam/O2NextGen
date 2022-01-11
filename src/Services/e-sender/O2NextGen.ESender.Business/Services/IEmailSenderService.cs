using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using O2NextGen.ESender.Business.Models;

namespace O2NextGen.ESender.Business.Services
{
    public interface IEmailSenderService
    {
        Task<IReadOnlyCollection<EmailRequest>> GetAllAsync(CancellationToken ct);

        Task<EmailRequest> GetByIdAsync(long id, CancellationToken ct);

        Task<EmailRequest> UpdateAsync(EmailRequest emailRequest, CancellationToken ct);

        Task<EmailRequest> AddAsync(EmailRequest emailRequest, CancellationToken ct);
        
        Task RemoveAsync(long id, CancellationToken ct);
    }
}