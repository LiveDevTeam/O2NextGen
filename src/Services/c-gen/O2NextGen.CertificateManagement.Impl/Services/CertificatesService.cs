using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using O2NextGen.CertificateManagement.Business.Models;
using O2NextGen.CertificateManagement.Business.Services;

namespace O2NextGen.CertificateManagement.Impl.Services
{
    public class CertificatesService:ICertificatesService
    {
        public Task<IReadOnlyCollection<Certificate>> GetAllAsync(CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<Certificate> GetByIdAsync(long id, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<Certificate> UpdateAsync(Certificate certificate, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<Certificate> AddAsync(Certificate certificate, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}