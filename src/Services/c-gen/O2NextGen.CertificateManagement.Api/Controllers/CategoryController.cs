using Microsoft.AspNetCore.Mvc;
using O2NextGen.CertificateManagement.Api.Mappings;
using O2NextGen.CertificateManagement.Api.Setup;
using O2NextGen.CertificateManagement.Api.ViewModels;
using O2NextGen.CertificateManagement.Business.Services;
using System.Threading;
using System.Threading.Tasks;

namespace O2NextGen.CertificateManagement.Api.Controllers
{
    [Route("category")]
    public class CategoryController : ControllerBase
    {
        #region Fields

        private readonly ICategoryService _categoryService;
        private readonly UrlsConfig _config;

        #endregion


        #region Ctors

        public CategoryController(ICategoryService categoryService, UrlsConfig config)
        {
            _categoryService = categoryService;
            _config = config;
        }

        #endregion


        #region Methods

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllAsync()
        {
            var url = _config.Auth;
            var models = await _categoryService.GetAllAsync(CancellationToken.None);
            return Ok(models.ToViewModel());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetByIdAsync(long id, CancellationToken ct)
        {
            var certificate = await _categoryService.GetByIdAsync(id, ct);
            if (certificate == null)
                return NotFound();
            return Ok(certificate.ToViewModel());
        }

        [HttpPut]
        [Route("id")]
        public async Task<IActionResult> UpdateAsync(long id, CategoryViewModel model, CancellationToken ct)
        {
            var certificate = await _categoryService.UpdateAsync(model.ToModel(), ct);
            return Ok(certificate.ToViewModel());
        }

        [HttpPost]
        [HttpPut]
        [Route("")]
        public async Task<IActionResult> AddAsync(CategoryViewModel model, CancellationToken ct)
        {
            var certificate = await _categoryService.AddAsync(model.ToModel(), ct);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = certificate.Id }, certificate);
        }

        [HttpDelete]
        [Route("id")]
        public async Task<IActionResult> RemoveAsync(long id, CancellationToken ct)
        {
            await _categoryService.RemoveAsync(id, ct);
            return NoContent();
        }

        #endregion
    }
}