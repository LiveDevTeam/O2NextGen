using Microsoft.EntityFrameworkCore;
using O2NextGen.SmartSubscriber.Domain.Data;

namespace O2NextGen.SmartSubscriber.Infrastructure.Data;

public class EfRepository<T> : IRepository<T> where T : class
{
    private readonly ApplicationDbContext _dbContext;

    public EfRepository(ApplicationDbContext dbContext)
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