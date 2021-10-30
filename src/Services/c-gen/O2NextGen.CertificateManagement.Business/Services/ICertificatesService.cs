using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using O2NextGen.CertificateManagement.Business.Models;

namespace O2NextGen.CertificateManagement.Business.Services
{
    public interface ICertificatesService
    {
        Task<IReadOnlyCollection<Certificate>> GetAllAsync(CancellationToken cancellationToken);

        Task<Certificate> GetByIdAsync(long id, CancellationToken cancellationToken);

        Task<Certificate> UpdateAsync(Certificate certificate, CancellationToken cancellationToken);

        Task<Certificate> AddAsync(Certificate certificate, CancellationToken cancellationToken);
    }
}