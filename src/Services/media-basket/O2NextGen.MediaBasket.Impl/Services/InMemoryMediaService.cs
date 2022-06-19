using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using O2NextGen.MediaBasket.Business.Models;
using O2NextGen.MediaBasket.Business.Services;

namespace O2NextGen.MediaBasket.Impl.Services
{
    public class InMemoryMediaService : IMediaService
    {
        #region Fields
        private readonly ICloudStorageManager _cloudStorage;

        private static readonly List<Media> Certificates = new List<Media>()
        {
            new Media()
            {
                Id = 1, Name = "First"
            }
        };
        private long _currentId;

        #endregion

        #region Ctors

        public InMemoryMediaService(ICloudStorageManager cloudStorage)
        {
            _cloudStorage = cloudStorage;
            _currentId = Certificates.Count();
        }
        #endregion

        #region Methods
        public async Task<IReadOnlyCollection<Media>> GetAllAsync(CancellationToken ct)
        {
            await Task.Delay(3000, ct);
            return await Task.FromResult<IReadOnlyCollection<Media>>(Certificates.AsReadOnly());
        }

        public async Task<Media> GetByIdAsync(long id, CancellationToken ct)
        {
            await Task.Delay(3000, ct);
            return await Task.FromResult(Certificates.SingleOrDefault(g => g.Id == id));
        }

        public async Task<Media> UpdateAsync(Media media, CancellationToken ct)
        {
            await Task.Delay(5000, ct);
            var toUpdate = Certificates.SingleOrDefault(g => g.Id == media.Id);
            if (toUpdate == null)
                return null;

            toUpdate.Name = media.Name;

            return await Task.FromResult(toUpdate);
        }

        public async Task<Media> AddAsync(Media media, IFormFile formFile, CancellationToken ct)
        {
            await Task.Delay(3000, ct);
            media.Id = ++_currentId;
            await _cloudStorage.UploadFileAsync(media, formFile, ct);
            Certificates.Add(media);
            return await Task.FromResult(media);
        }


        public Task RemoveAsync(long id, CancellationToken ct)
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}