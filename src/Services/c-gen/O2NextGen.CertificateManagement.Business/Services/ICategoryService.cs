using O2NextGen.CertificateManagement.Business.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace O2NextGen.CertificateManagement.Business.Services
{
    public interface ICategoryService
    {
        Task<IReadOnlyCollection<Category>> GetAllAsync(CancellationToken ct);

        Task<Category> GetByIdAsync(long id, CancellationToken ct);

        Task<Category> UpdateAsync(Category category, CancellationToken ct);

        Task<Category> AddAsync(Category category, CancellationToken ct);

        Task RemoveAsync(long id, CancellationToken ct);
    }
}