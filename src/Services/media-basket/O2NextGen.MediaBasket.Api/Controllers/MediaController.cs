using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using O2NextGen.MediaBasket.Api.Mappings;
using O2NextGen.MediaBasket.Api.Setup;
using O2NextGen.MediaBasket.Business.Services;
using O2NextGen.Sdk.NetCore.Models.media_basket;

namespace O2NextGen.MediaBasket.Api.Controllers
{
    [Route("media")]
    public class MediaController : ControllerBase
    {
        #region Fields

        private readonly IMediaService _mediaService;
        private readonly UrlsConfig _config;
        private readonly ILogger<MediaController> _logger;

        #endregion


        #region Ctors

        public MediaController(IMediaService mediaService, UrlsConfig config,ILogger<MediaController> logger)
        {
            _mediaService = mediaService ?? throw new ArgumentException(nameof(mediaService));
            _config = config ?? throw new ArgumentException(nameof(config));
            _logger = logger;
        }

        #endregion


        #region Methods

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllAsync()
        {
            _logger.LogInformation($"Execute method - {nameof(GetAllAsync)}");
            var url = _config.Auth;
            var models = await _mediaService.GetAllAsync(CancellationToken.None);
            return Ok(models.ToViewModel());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetByIdAsync(long id, CancellationToken ct)
        {
            _logger.LogInformation($"Execute method - {nameof(GetByIdAsync)}");
            var media = await _mediaService.GetByIdAsync(id, ct);
            if (media == null)
                return NotFound();
            return Ok(media.ToViewModel());
        }

        [HttpPut]
        [Route("id")]
        public async Task<IActionResult> UpdateAsync(long id, MediaViewModel model, CancellationToken ct)
        {
            _logger.LogInformation($"Execute method - {nameof(UpdateAsync)}");
            var media = await _mediaService.UpdateAsync(model.ToModel(), ct);
            return Ok(media.ToViewModel());
        }

        [HttpPost]
        [HttpPut]
        [Route("")]
        public async Task<IActionResult> AddAsync([FromForm]MediaViewModel model, CancellationToken ct)
        {
            _logger.LogInformation($"Execute method - {nameof(AddAsync)}");
            var media = await _mediaService.AddAsync(model.ToModel(), model.File, ct);
            return CreatedAtAction(nameof(GetByIdAsync), new {id = media.Id}, media);
        }

        #endregion

        [HttpDelete]
        [Route("id")]
        public async Task<IActionResult> RemoveAsync(long id,CancellationToken ct)
        {
            _logger.LogInformation($"Execute method - {nameof(RemoveAsync)}");
            await _mediaService.RemoveAsync(id, ct);
            return NoContent();
        }
    }
}