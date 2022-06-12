using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using O2NextGen.MediaBasket.Business.Models;
using O2NextGen.MediaBasket.Business.Services;
using O2NextGen.MediaBasket.Data;
using O2NextGen.MediaBasket.Impl.Mappings;

namespace O2NextGen.MediaBasket.Impl.Services
{
    public class MediaService : IMediaService
    {
        #region Fields

        private readonly MadiaManagementDbContext _context;

        #endregion


        #region Ctors

        public MediaService(MadiaManagementDbContext context)
        {
            _context = context;
        }

        #endregion

        public async Task<IReadOnlyCollection<Media>> GetAllAsync(CancellationToken ct)
        {
            var certificates = await _context.Certificates.AsNoTracking().OrderBy(_=>_.Id).ToListAsync();
            return certificates.ToService();
        }

        public async Task<Media> GetByIdAsync(long id, CancellationToken ct)
        {
            var certificates = await _context.Certificates.AsNoTracking().SingleAsync(x => x.Id == id, ct);
            return certificates.ToService();
        }

        public async Task<Media> UpdateAsync(Media media, CancellationToken ct)
        {
            var updatedCertificateEntity = _context.Certificates.Update(media.ToEntity());
            await _context.SaveChangesAsync(ct);
            return updatedCertificateEntity.Entity.ToService();
        }
        
        public async Task<Media> AddAsync(Media media, CancellationToken ct)
        {
            var addedCertificateEntity = await _context.Certificates.AddAsync(media.ToEntity(), ct);
            await _context.SaveChangesAsync(ct);
            return addedCertificateEntity.Entity.ToService();
        }

        public async Task RemoveAsync(long id, CancellationToken ct)
        {
            var entityToRemove = await _context.Certificates.SingleOrDefaultAsync(_ => _.Id == id, ct);
            _context.Certificates.Remove(entityToRemove);
            await _context.SaveChangesAsync(ct);
        }
    }
}