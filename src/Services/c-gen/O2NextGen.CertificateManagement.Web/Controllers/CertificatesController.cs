using Microsoft.AspNetCore.Mvc;
using O2NextGen.CertificateManagement.Business.Services;
using  O2NextGen.CertificateManagement.Web.Mappings;
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
        public IActionResult Index()
        {
            var models = _certificatesService.GetAll();
            if (models == null)
                return NotFound();
            return View(models.ToViewModel());
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Detail(long id)
        {
            var certificate = _certificatesService.GetById(id);
            if (certificate == null)
                return NotFound();
            return View(certificate.ToViewModel());
        }

        [HttpPost]
        [Route("id")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(long id, CertificateViewModel model)
        {
            var certificate = _certificatesService.Update(model.ToModel());
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
        public IActionResult CreateReally(CertificateViewModel model)
        {
            _certificatesService.Add(model.ToModel());
            return RedirectToAction("Index");
        }

        #endregion
    }
}