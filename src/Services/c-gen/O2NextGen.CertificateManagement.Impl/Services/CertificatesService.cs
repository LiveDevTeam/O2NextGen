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
            return await SimplestUpdateAsync(certificate, cancellationToken);
            // var existingCertificate = await _context.Certificates.AsNoTracking().SingleAsync(x => x.Id == certificate.Id, cancellationToken);
            // existingCertificate.Name = certificate.Name;
            // await Task.Delay(TimeSpan.FromSeconds(10));
            // await _context.SaveChangesAsync(cancellationToken);
            // return existingCertificate.ToService();
        }

        private async Task<Certificate> SimplestUpdateAsync(Certificate certificate, CancellationToken cancellationToken)
        {
            var updatedCertificateEntity = _context.Certificates.Update(certificate.ToEntity());
            await _context.SaveChangesAsync(cancellationToken);
            return updatedCertificateEntity.Entity.ToService();
        }

        #region Simples for Update Entity

        // private async Task<Certificate> UpdateSampleAsync(Certificate certificate,
        //     CancellationToken cancellationToken)
        // {
        //     var localCertificate = 
        //         _context.Certificates.Local.SingleOrDefault(_ => _.Id == certificate.Id);
        //     if (localCertificate != null)
        //     {
        //         _context.Entry(localCertificate).State = EntityState.Detached;
        //     }
        //     var updatedCertificateEntity = _context.Certificates.Update(certificate.ToEntity());
        //     await _context.SaveChangesAsync(cancellationToken);
        //     return updatedCertificateEntity.Entity.ToService();
        // }
        // private async Task<Certificate> SimplestWithFetchUpdateAsync(Certificate certificate, CancellationToken cancellationToken)
        // {
        //     var existingCertificate = await _context.Certificates.SingleOrDefaultAsync(_ => _.Id == certificate.Id,cancellationToken);
        //     existingCertificate.Name = certificate.Name;
        //     
        //     await _context.SaveChangesAsync(cancellationToken);
        //     return existingCertificate.ToService();
        // }
        //
        // private async Task<Certificate> SimplestWithFetch2UpdateAsync(Certificate certificate, CancellationToken cancellationToken)
        // {
        //     var existingCertificate = await _context.Certificates.SingleOrDefaultAsync(_ => _.Id == certificate.Id,cancellationToken);
        //     _context.Entry(existingCertificate).CurrentValues.SetValues(certificate.ToEntity());
        //     
        //     await _context.SaveChangesAsync(cancellationToken);
        //     return existingCertificate.ToService();
        // }

        #endregion
        public async Task<Certificate> AddAsync(Certificate certificate, CancellationToken cancellationToken)
        {
            var addedCertificateEntity = await _context.Certificates.AddAsync(certificate.ToEntity(), cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return addedCertificateEntity.Entity.ToService();
        }
    }
}