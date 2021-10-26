using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Antiforgery.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using O2NextGen.CertificateManagement.Web.Models;

namespace O2NextGen.CertificateManagement.Web.Controllers
{
    [Route("certificates")]
    public class CertificatesController : Controller
    {
        private static long _currentCertificateId = 1;

        private static List<CertificateViewModel> _certificates = new List<CertificateViewModel>()
        {
            new CertificateViewModel() {Id = 1, Name = "First"},
            new CertificateViewModel() {Id = 2, Name = "Second "}
        };

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View(_certificates);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Detail(long id)
        {
            var certificate = _certificates.SingleOrDefault(_ => _.Id == id);
            if (certificate == null)
                return NotFound();
            return View(certificate);
        }

        [HttpPost]
        [Route("id")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(long id, CertificateViewModel model)
        {
            var certificate = _certificates.SingleOrDefault(_ => _.Id == id);
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
            model.Id = _currentCertificateId++;
            _certificates.Add(model);
            return RedirectToAction("Index");
        }
    }
}