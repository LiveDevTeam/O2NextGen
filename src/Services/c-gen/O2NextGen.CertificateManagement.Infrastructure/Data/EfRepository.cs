using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using O2NextGen.CertificateManagement.Data;
using O2NextGen.CertificateManagement.Domain.Data;

namespace O2NextGen.CertificateManagement.Infrastructure.Data
{

    public class EfRepository<T> : IRepository<T> where T : class
    {
        private readonly CertificateManagementDbContext _dbContext;

        public EfRepository(CertificateManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> AddAsync(T entity, CancellationToken ct)
        {
            await _dbContext.Set<T>().AddAsync(entity, ct);
            await _dbContext.SaveChangesAsync(ct);
            return entity;
        }

        public async Task UpdateAsync(T entity, CancellationToken ct)
        {
            var entry = _dbContext.Entry(entity);
            //if (entity is IVersionedEntity versionedEntity)
            //{
            //    entry.OriginalValues[nameof(IVersionedEntity.RowVersion)] = versionedEntity.RowVersion;
            //}
            entry.State = EntityState.Modified;
            await _dbContext.SaveChangesAsync(ct);
        }

        public async Task DeleteAsync(T entity, CancellationToken ct)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync(ct);
        }
    }

}

