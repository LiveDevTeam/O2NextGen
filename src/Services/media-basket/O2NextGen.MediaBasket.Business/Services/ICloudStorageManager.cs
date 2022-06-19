using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using O2NextGen.MediaBasket.Business.Models;

namespace O2NextGen.MediaBasket.Business.Services
{
    public interface ICloudStorageManager
    {
        Task<Media> UploadFileAsync(Media media, IFormFile formFile, CancellationToken ct);
    }
}