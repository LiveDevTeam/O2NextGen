using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using O2NextGen.CertificateManagement.Business.Services;
using O2NextGen.CertificateManagement.Web.Mappings;
using O2NextGen.CertificateManagement.Web.Models;

namespace O2NextGen.CertificateManagement.Web.Controllers
{
    [Route("certificates")]
    public class CertificatesController : Controller
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
        public async Task<IActionResult> Index()
        {
            var models = await _certificatesService.GetAllAsync(CancellationToken.None);
            if (models == null)
                return NotFound();
            return View(models.ToViewModel());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Detail(long id, CancellationToken ct)
        {
            var certificate = await _certificatesService.GetByIdAsync(id, ct);
            if (certificate == null)
                return NotFound();
            return View(certificate.ToViewModel());
        }

        [HttpPost]
        [Route("id")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, CertificateViewModel model, CancellationToken ct)
        {
            var certificate = await _certificatesService.UpdateAsync(model.ToModel(), ct);
            if (certificate == null)
                return NotFound();
            certificate.Name = model.Name;

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> CreateReally(CertificateViewModel model, CancellationToken ct)
        {
            await _certificatesService.AddAsync(model.ToModel(), ct);
            return RedirectToAction("Index");
        }

        #endregion
    }
}