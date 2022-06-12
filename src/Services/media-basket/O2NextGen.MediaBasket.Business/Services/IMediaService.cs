using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using O2NextGen.MediaBasket.Business.Models;

namespace O2NextGen.MediaBasket.Business.Services
{
    public interface IMediaService
    {
        Task<IReadOnlyCollection<Media>> GetAllAsync(CancellationToken ct);

        Task<Media> GetByIdAsync(long id, CancellationToken ct);

        Task<Media> UpdateAsync(Media media, CancellationToken ct);

        Task<Media> AddAsync(Media media, IFormFile formFile, CancellationToken ct);
        
        Task RemoveAsync(long id, CancellationToken ct);
    }
}