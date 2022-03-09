using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using O2NextGen.ESender.Api.Helpers;
using O2NextGen.ESender.Api.Mappings;
using O2NextGen.ESender.Api.Models;
using O2NextGen.ESender.Business.Services;

namespace O2NextGen.ESender.Api.Controllers
{
    [AllowAnonymous]
    [Route("board")]
    public class BoardController : Controller
    {
        private readonly IEmailSender _emailSender;
        private readonly IEmailSenderService _emailSenderService;

        public BoardController(IEmailSender emailSender, IEmailSenderService emailSenderService)
        {
            _emailSender = emailSender;
            _emailSenderService = emailSenderService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Index()
        {
            var models = await _emailSenderService.GetAllAsync(CancellationToken.None);
            return View(models.ToViewModel());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Detail(long id)
        {
            var emailRequest = await _emailSenderService.GetByIdAsync(id, CancellationToken.None);
            if (emailRequest == null)
                return NotFound();
            return View(emailRequest.ToViewModel());
        }

        [HttpPost]
        [Route("id")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, EmailRequestViewModel model)
        {
            var certificate = await _emailSenderService.GetByIdAsync(id, CancellationToken.None);
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
        public async Task<IActionResult> CreateReally(EmailRequestViewModel model)
        {
            var emailRequest = await _emailSenderService.AddAsync(model.ToModel(), CancellationToken.None);
            await _emailSender.Send(model.To, model.Subject, model.Body);
            return RedirectToAction("Index");
        }
    }
}