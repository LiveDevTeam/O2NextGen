using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using O2NextGen.ESender.Business.Models;
using O2NextGen.ESender.Business.Services;
using O2NextGen.ESender.Data;
using O2NextGen.ESender.Impl.Mappings;

namespace O2NextGen.ESender.Impl.Services
{
    public class EmailSenderService : IEmailSenderService
    {
        #region Fields

        private readonly ESenderDbContext _context;

        #endregion
        
        
        #region Ctors

        public EmailSenderService(ESenderDbContext context)
        {
            _context = context;
        }

        #endregion
        
        
        public async Task<IReadOnlyCollection<EmailRequestModel>> GetAllAsync(CancellationToken ct)
        {
            var mailRequestEntities = await _context.MailRequests.AsNoTracking().OrderBy(_=>_.Id).ToListAsync();
            return mailRequestEntities.ToModel();
        }

        public async Task<EmailRequestModel> GetByIdAsync(long id, CancellationToken ct)
        {
            var entity = await _context.MailRequests.AsNoTracking().SingleAsync(x => x.Id == id, ct);
            return entity.ToModel();
        }

        public async Task<EmailRequestModel> UpdateAsync(EmailRequestModel certificate, CancellationToken ct)
        {
            var entityEntry = _context.MailRequests.Update(certificate.ToEntity());
            await _context.SaveChangesAsync(ct);
            return entityEntry.Entity.ToModel();
        }
        
        public async Task<EmailRequestModel> AddAsync(EmailRequestModel certificate, CancellationToken ct)
        {
            var entityEntry = await _context.MailRequests.AddAsync(certificate.ToEntity(), ct);
            await _context.SaveChangesAsync(ct);
            return entityEntry.Entity.ToModel();
        }

        public async Task RemoveAsync(long id, CancellationToken ct)
        {
            var entityToRemove = await _context.MailRequests.SingleOrDefaultAsync(_ => _.Id == id, ct);
            _context.MailRequests.Remove(entityToRemove);
            await _context.SaveChangesAsync(ct);
        }
        
    }
}