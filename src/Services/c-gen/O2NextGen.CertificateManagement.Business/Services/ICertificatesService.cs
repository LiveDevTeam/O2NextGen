using System.Collections.Generic;
using O2NextGen.CertificateManagement.Business.Models;

namespace O2NextGen.CertificateManagement.Business.Services
{
    public interface ICertificatesService
    {
        IReadOnlyCollection<Certificate> GetAll();

        Certificate GetById(long id);

        Certificate Update(Certificate certificate);

        Certificate Add(Certificate certificate);
    }
}