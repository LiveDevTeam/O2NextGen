using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using O2NextGen.CertificateManagement.Business.Models;
using O2NextGen.CertificateManagement.Business.Services;

namespace O2NextGen.CertificateManagement.Impl.Services
{
    public class InMemoryCategoriesService : ICategoryService
    {
        #region Fields

        private static readonly List<Category> Categorys = new List<Category>()
        {
            new Category()
            {
                Id = 1, Name = "First"
            }
        };
        private long _currentId;

        #endregion

        #region Ctors

        public InMemoryCategoriesService()
        {
            _currentId = Categorys.Count();
        }
        #endregion

        #region Methods
        public async Task<IReadOnlyCollection<Category>> GetAllAsync(CancellationToken ct)
        {
            await Task.Delay(3000, ct);
            return await Task.FromResult<IReadOnlyCollection<Category>>(Categorys.AsReadOnly());
        }

        public async Task<Category> GetByIdAsync(long id, CancellationToken ct)
        {
            await Task.Delay(3000, ct);
            return await Task.FromResult(Categorys.SingleOrDefault(g => g.Id == id));
        }

        public async Task<Category> UpdateAsync(Category Category, CancellationToken ct)
        {
            await Task.Delay(5000, ct);
            var toUpdate = Categorys.SingleOrDefault(g => g.Id == Category.Id);
            if (toUpdate == null)
                return null;

            toUpdate.Name = Category.Name;

            return await Task.FromResult(toUpdate);
        }

        public async Task<Category> AddAsync(Category Category, CancellationToken ct)
        {
            await Task.Delay(3000, ct);
            Category.Id = ++_currentId;
            Categorys.Add(Category);
            return await Task.FromResult(Category);
        }

        public Task RemoveAsync(long id, CancellationToken ct)
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}