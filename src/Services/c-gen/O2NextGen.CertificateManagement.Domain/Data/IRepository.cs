namespace O2NextGen.CertificateManagement.Domain.Data;

public interface IRepository<T>
{
    Task<T> AddAsync(T entity, CancellationToken ct);
    Task UpdateAsync(T entity, CancellationToken ct);
    Task DeleteAsync(T entity, CancellationToken ct);
}