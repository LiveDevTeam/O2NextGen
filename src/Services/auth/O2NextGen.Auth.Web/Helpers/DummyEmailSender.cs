using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Logging;
using O2NextGen.Auth.Web.Services;

namespace O2NextGen.Auth.Web.Helpers
{
    internal class DummyEmailSender : IEmailSender
    {
        private readonly ILogger<DummyEmailSender> _logger;
        private readonly IESenderService _service;

        public DummyEmailSender(ILogger<DummyEmailSender> logger, IESenderService service)
        {
            _logger = logger;
            _service = service;
        }
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            _logger.LogWarning("EmailSender implementation is being used!!!!");
            _logger.LogWarning($"htmlMessage = { HttpUtility.HtmlDecode(htmlMessage)}");
            _service.Send(email,subject,htmlMessage);
            return Task.CompletedTask;
        }
    }
}