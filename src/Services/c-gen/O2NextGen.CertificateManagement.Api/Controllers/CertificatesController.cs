using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using O2NextGen.CertificateManagement.Business.Services;
using O2NextGen.CertificateManagement.Web.Mappings;
using O2NextGen.CertificateManagement.Web.Models;

namespace O2NextGen.CertificateManagement.Web.Controllers
{
    [Route("certificates")]
    public class CertificatesController : ControllerBase
    {
        #region Fields

        private readonly ICertificatesService _certificatesService;

        #endregion


        #region Ctors

        public CertificatesController(ICertificatesService certificatesService)
        {
            _certificatesService = certificatesService;
        }

        #endregion


        #region Methods

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllAsync()
        {
            var models = await _certificatesService.GetAllAsync(CancellationToken.None);
            return Ok(models.ToViewModel());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetByIdAsync(long id, CancellationToken ct)
        {
            var certificate = await _certificatesService.GetByIdAsync(id, ct);
            if (certificate == null)
                return NotFound();
            return Ok(certificate.ToViewModel());
        }

        [HttpPut]
        [Route("id")]
        public async Task<IActionResult> UpdateAsync(long id, CertificateViewModel model, CancellationToken ct)
        {
            var certificate = await _certificatesService.UpdateAsync(model.ToModel(), ct);
            return Ok(certificate.ToViewModel());
        }

        [HttpPost]
        [HttpPut]
        [Route("")]
        public async Task<IActionResult> AddAsync(CertificateViewModel model, CancellationToken ct)
        {
            var certificate = await _certificatesService.AddAsync(model.ToModel(), ct);
            return CreatedAtAction(nameof(GetByIdAsync), new {id = certificate.Id}, certificate);
        }

        #endregion

        [HttpDelete]
        [Route("id")]
        public async Task<IActionResult> RemoveAsync(long id,CancellationToken ct)
        {
            await _certificatesService.RemoveAsync(id, ct);
            return NoContent();
        }
    }
}