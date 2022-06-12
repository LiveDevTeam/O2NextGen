using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using O2NextGen.MediaBasket.Api.Helpers;
using O2NextGen.MediaBasket.Business.Models;
using O2NextGen.MediaBasket.Business.Services;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats;

namespace O2NextGen.MediaBasket.Api.Services
{
    public class CloudinaryStorageService : ICloudStorageManager
    {
        private readonly IOptions<CloudinarySettings> _cloudinaryConfig;
        private readonly ILogger<CloudinaryStorageService> _logger;
        private readonly Cloudinary _cloudinary;

        public CloudinaryStorageService(IOptions<CloudinarySettings> cloudinaryConfig, ILogger<CloudinaryStorageService> logger)
        {
            _cloudinaryConfig = cloudinaryConfig ?? throw new ArgumentException(nameof(cloudinaryConfig));
            _logger = logger;
            Account acc = new Account(
                _cloudinaryConfig.Value.CloudName,
                _cloudinaryConfig.Value.ApiKey,
                _cloudinaryConfig.Value.ApiSecret
            );
            _cloudinary = new Cloudinary(acc);
        }

        public async Task<Media> UploadFileAsync(Media media, IFormFile formFile, CancellationToken ct)
        {
            if (formFile == null) throw new ArgumentException(nameof(formFile));

            media.OriginalName = formFile.FileName;

            var filename = media.AccountId + "-" + DateTime.UtcNow.ToString("hh/mm/ss/dd/MM/yyyy").Replace('/', '-') +
                           media.OriginalName.GetFileExtension();

            var contentType = MimeTypes.GetMimeType(filename.GetFileExtension().ToLower());

            if (formFile.Length > 0)
            {
                var filePath = Path.GetTempFileName();
                _logger.LogInformation($"string filePath={filePath}");
                using (var stream = formFile.OpenReadStream())
                {
                    using (Image image = Image.Load(stream, out IImageFormat format))
                    {
                        using (var stream2 = formFile.OpenReadStream())
                        {
                            // await formFile.CopyToAsync(stream, ct);
                            var uploadParams = new ImageUploadParams()
                            {
                                Folder = "Media-Basket/Dev",
                                File = new FileDescription(media.OriginalName, stream2),
                            };
                            
                            var uploadResult = _cloudinary.Upload(uploadParams);
                            media.Name = filename;
                            media.PublicId = uploadResult.PublicId;
                            media.Width = image.Width;
                            media.Height = image.Height;
                            media.ExtType = filename.GetFileExtension();
                            media.Url = uploadResult.Uri.ToString();
                            media.MediaType = "image";
                            media.ContentType = contentType;
                        }
                    }
                }
            }

            return await Task.FromResult(media);
        }
    }
}