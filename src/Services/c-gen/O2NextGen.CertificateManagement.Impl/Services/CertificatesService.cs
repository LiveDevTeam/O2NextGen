using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using O2NextGen.CertificateManagement.Business.Models;
using O2NextGen.CertificateManagement.Business.Services;
using O2NextGen.CertificateManagement.Data;
using O2NextGen.CertificateManagement.Impl.Mappings;

namespace O2NextGen.CertificateManagement.Impl.Services
{
    public class CertificatesService : ICertificatesService
    {
        #region Fields

        private readonly CertificateManagementDbContext _context;

        #endregion


        #region Ctors

        public CertificatesService(CertificateManagementDbContext context)
        {
            _context = context;
        }

        #endregion

        public async Task<IReadOnlyCollection<Certificate>> GetAllAsync(CancellationToken cancellationToken)
        {
            var certificates = await _context.Certificates.AsNoTracking().OrderBy(_=>_.Id).ToListAsync();
            return certificates.ToService();
        }

        public async Task<Certificate> GetByIdAsync(long id, CancellationToken cancellationToken)
        {
            var certificates = await _context.Certificates.AsNoTracking().SingleAsync(x => x.Id == id, cancellationToken);
            return certificates.ToService();
        }

        public async Task<Certificate> UpdateAsync(Certificate certificate, CancellationToken cancellationToken)
        {
            var updatedCertificateEntity = _context.Certificates.Update(certificate.ToEntity());
            await _context.SaveChangesAsync(cancellationToken);
            return updatedCertificateEntity.Entity.ToService();
        }
        
        public async Task<Certificate> AddAsync(Certificate certificate, CancellationToken cancellationToken)
        {
            var addedCertificateEntity = await _context.Certificates.AddAsync(certificate.ToEntity(), cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return addedCertificateEntity.Entity.ToService();
        }
    }
}