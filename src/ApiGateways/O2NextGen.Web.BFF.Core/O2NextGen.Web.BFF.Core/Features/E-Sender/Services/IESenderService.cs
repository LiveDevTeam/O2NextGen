using System.Threading;
using System.Threading.Tasks;
using O2NextGen.Web.BFF.Core.Features.E_Sender.Models;

namespace O2NextGen.Web.BFF.Core.Features.E_Sender.Services
{
    public interface IESenderService
    {
        Task<MailRequestViewModel> AddAsync(MailRequestViewModel model, CancellationToken ct);
        Task<MailRequestViewModel> GetAsync(long id, CancellationToken ct);
    }
}