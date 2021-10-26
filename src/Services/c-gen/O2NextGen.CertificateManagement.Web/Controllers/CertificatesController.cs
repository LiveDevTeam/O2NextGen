using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using O2NextGen.CertificateManagement.Web.Demo;
using O2NextGen.CertificateManagement.Web.Models;

namespace O2NextGen.CertificateManagement.Web.Controllers
{
    [Route("certificates")]
    public class CertificatesController : Controller
    {
        #region Fields

        private readonly ICertificateIdGenerator _generator;
   
        private static readonly List<CertificateViewModel> Certificates = new List<CertificateViewModel>()
        {
            new CertificateViewModel() {Id = 1, Name = "First"}
        };
        
        #endregion
        
        
        #region Ctors
        
        public CertificatesController( ICertificateIdGenerator generator)
        {
            _generator = generator;
        }
        
        #endregion

        
        #region Methods

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View(Certificates);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Detail(long id)
        {
            var certificate = Certificates.SingleOrDefault(_ => _.Id == id);
            if (certificate == null)
                return NotFound();
            return View(certificate);
        }

        [HttpPost]
        [Route("id")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(long id, CertificateViewModel model)
        {
            var certificate = Certificates.SingleOrDefault(_ => _.Id == id);
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
            model.Id = _generator.Next();
            Certificates.Add(model);
            return RedirectToAction("Index");
        }

        #endregion
    }
}