using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using O2NextGen.CertificateManagement.Business.Models;
using O2NextGen.CertificateManagement.Business.Services;

namespace O2NextGen.CertificateManagement.Impl.Services
{
    public class InMemoryCertificatesService : ICertificatesService
    {
        #region Fields

        private static readonly List<Certificate> Certificates = new List<Certificate>()
        {
            new Certificate()
            {
                Id = 1, Name = "First"
            }
        };
        private long _currentId;

        #endregion

        #region Ctors

        public InMemoryCertificatesService()
        {
            _currentId = Certificates.Count();
        }
        #endregion

        #region Methods
        public async Task<IReadOnlyCollection<Certificate>> GetAllAsync(CancellationToken ct)
        {
            await Task.Delay(3000, ct);
            return await Task.FromResult<IReadOnlyCollection<Certificate>>(Certificates.AsReadOnly());
        }

        public async Task<Certificate> GetByIdAsync(long id, CancellationToken ct)
        {
            await Task.Delay(3000, ct);
            return await Task.FromResult(Certificates.SingleOrDefault(g => g.Id == id));
        }

        public async Task<Certificate> UpdateAsync(Certificate certificate, CancellationToken ct)
        {
            await Task.Delay(5000, ct);
            var toUpdate = Certificates.SingleOrDefault(g => g.Id == certificate.Id);
            if (toUpdate == null)
                return null;

            toUpdate.Name = certificate.Name;

            return await Task.FromResult(toUpdate);
        }

        public async Task<Certificate> AddAsync(Certificate certificate, CancellationToken ct)
        {
            await Task.Delay(3000, ct);
            certificate.Id = ++_currentId;
            Certificates.Add(certificate);
            return await Task.FromResult(certificate);
        }
        #endregion
    }
}