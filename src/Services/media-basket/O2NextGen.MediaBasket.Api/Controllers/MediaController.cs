using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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

        #endregion


        #region Ctors

        public MediaController(IMediaService mediaService, UrlsConfig config)
        {
            _mediaService = mediaService;
            _config = config;
        }

        #endregion


        #region Methods

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllAsync()
        {
            var url = _config.Auth;
            var models = await _mediaService.GetAllAsync(CancellationToken.None);
            return Ok(models.ToViewModel());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetByIdAsync(long id, CancellationToken ct)
        {
            var certificate = await _mediaService.GetByIdAsync(id, ct);
            if (certificate == null)
                return NotFound();
            return Ok(certificate.ToViewModel());
        }

        [HttpPut]
        [Route("id")]
        public async Task<IActionResult> UpdateAsync(long id, MediaViewModel model, CancellationToken ct)
        {
            var certificate = await _mediaService.UpdateAsync(model.ToModel(), ct);
            return Ok(certificate.ToViewModel());
        }

        [HttpPost]
        [HttpPut]
        [Route("")]
        public async Task<IActionResult> AddAsync(MediaViewModel model, CancellationToken ct)
        {
            var certificate = await _mediaService.AddAsync(model.ToModel(), ct);
            return CreatedAtAction(nameof(GetByIdAsync), new {id = certificate.Id}, certificate);
        }

        #endregion

        [HttpDelete]
        [Route("id")]
        public async Task<IActionResult> RemoveAsync(long id,CancellationToken ct)
        {
            await _mediaService.RemoveAsync(id, ct);
            return NoContent();
        }
    }
}