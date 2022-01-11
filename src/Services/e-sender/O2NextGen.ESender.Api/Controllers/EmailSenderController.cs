using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using O2NextGen.ESender.Api.Helpers;
using O2NextGen.ESender.Api.Mappings;
using O2NextGen.ESender.Api.Models;
using O2NextGen.ESender.Business.Services;

namespace O2NextGen.ESender.Api.Controllers
{
    [Route("api/[controller]")]
    public class EmailSenderController : ControllerBase
    {
        #region Fields

        private readonly IEmailSender _emailSender;
        private readonly IEmailSenderService _emailSenderService;
        
        #endregion

        #region Ctors
        public EmailSenderController(IEmailSender emailSender, IEmailSenderService emailSenderService)
        {
            _emailSender = emailSender;
            _emailSenderService = emailSenderService;
        }
        #endregion
        
        #region Methods

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllAsync()
        {
            var models = await _emailSenderService.GetAllAsync(CancellationToken.None);
            return Ok(models.ToViewModel());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetByIdAsync(long id, CancellationToken ct)
        {
            var certificate = await _emailSenderService.GetByIdAsync(id, ct);
            if (certificate == null)
                return NotFound();
            return Ok(certificate.ToViewModel());
        }

        [HttpPut]
        [Route("id")]
        public async Task<IActionResult> UpdateAsync(long id, MailRequestViewModel model, CancellationToken ct)
        {
            var certificate = await _emailSenderService.UpdateAsync(model.ToModel(), ct);
            return Ok(certificate.ToViewModel());
        }

        [HttpPost]
        [HttpPut]
        [Route("")]
        public async Task<IActionResult> AddAsync(MailRequestViewModel model, CancellationToken ct)
        {
            var certificate = await _emailSenderService.AddAsync(model.ToModel(), ct);
            return CreatedAtAction(nameof(GetByIdAsync), new {id = certificate.Id}, certificate);
        }

        #endregion

        [HttpDelete]
        [Route("id")]
        public async Task<IActionResult> RemoveAsync(long id,CancellationToken ct)
        {
            await _emailSenderService.RemoveAsync(id, ct);
            return NoContent();
        }
    }
}

