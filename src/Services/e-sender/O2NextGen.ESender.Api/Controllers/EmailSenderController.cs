using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using O2NextGen.ESender.Api.Models;

namespace O2NextGen.ESender.Api.Controllers
{
    [Route("emailsender")]
    public class EmailSenderController : Controller
    {   
        private static long _currentCertificateId = 1;

        private static List<MailViewModel> _mailLetters = new List<MailViewModel>()
         {
             new MailViewModel() {Id = 1, From ="from@eexample.com",To = "example@eexample.com", Subject="theme", Body="<h1>last</h1>"},
             new MailViewModel() {Id = 2, From ="from@eexample.com",To = "example@eexample.com", Subject="theme", Body="<h1>last</h1>"},
         };

        [HttpGet]
        [Route("")]
        public IActionResult Index() => View(_mailLetters);

        [HttpGet]
        [Route("{id}")]
        public IActionResult Detail(long id)
        {
            var certificate = _mailLetters.SingleOrDefault(_ => _.Id == id);
            if (certificate == null)
                return NotFound();
            return View(certificate);
        }

        [HttpPost]
        [Route("id")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(long id, MailViewModel model)
        {
            var certificate = _mailLetters.SingleOrDefault(_ => _.Id == id);
            if (certificate == null)
                return NotFound();
            certificate.From = model.From;
            certificate.To = model.To;
            certificate.Subject = model.Subject;
            certificate.Body = model.Body;

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
        public IActionResult CreateReally(MailViewModel model)
        {
            model.Id = _currentCertificateId++;
            _mailLetters.Add(model);
            return RedirectToAction("Index");
        }
    }
}

