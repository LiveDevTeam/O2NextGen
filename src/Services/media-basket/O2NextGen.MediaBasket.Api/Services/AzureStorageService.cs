using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using O2NextGen.MediaBasket.Business.Models;
using O2NextGen.MediaBasket.Business.Services;

namespace O2NextGen.MediaBasket.Api.Services
{
    public class AzureStorageService : ICloudStorageManager
    {

        public Task<Media> UploadFileAsync(Media media, IFormFile formFile, CancellationToken ct)
        {
            throw new NotImplementedException();
        }
    }
}