using System.Collections.Generic;
using System.Linq;
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
        public IReadOnlyCollection<Certificate> GetAll()
        {
            return Certificates.AsReadOnly();
        }

        public Certificate GetById(long id)
        {
            return Certificates.SingleOrDefault(g => g.Id == id);
        }

        public Certificate Update(Certificate certificate)
        {
            var toUpdate = Certificates.SingleOrDefault(g => g.Id == certificate.Id);
            if (toUpdate == null)
                return null;

            toUpdate.Name = certificate.Name;

            return toUpdate;
        }

        public Certificate Add(Certificate certificate)
        {
            certificate.Id = ++_currentId;
            Certificates.Add(certificate);
            return certificate;
        }
        #endregion
    }
}