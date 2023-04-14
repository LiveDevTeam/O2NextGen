using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using O2NextGen.ESender.Api.Setup;

namespace O2NextGen.ESender.Api.Helpers
{
    public class EmailSender : IEmailSender
    {
        private readonly ILogger<EmailSender> _logger;

        public EmailSender(SenderConfig senderConfig,ILogger<EmailSender> logger)
        {
            _logger = logger;
            SmtpServerHost = "localhost";
            SmtpServerPort = 25;
            From= "no-reply@o2nextgen.com";
        }

        public string From { get; set; }

        public int SmtpServerPort { get; set; }

        public string SmtpServerHost { get; set; }

        public async Task Send(string to, string subject, string bodyHtml)
        {
            using (var client = new SmtpClient())
            {
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Host = SmtpServerHost;
                client.Port = SmtpServerPort;
                client.Credentials = new System.Net.NetworkCredential("no-reply@o2nextgen.com", "#89_DangerSnake?");
                _logger.LogInformation($">> Settings for email server  host={client.Host} port={client.Port}");
                using (var message = new MailMessage(From, to))
                {
                    message.Subject = subject;
                    message.IsBodyHtml = true;
                    message.Body = bodyHtml;
                    _logger.LogInformation($">> Send email to={to} subject={subject} message={message}");
                    await client.SendMailAsync(message).ConfigureAwait(false);
                }
            }
        }
    }
    public interface IEmailSender
    {
        Task Send(string to, string subject, string bodyHtml);
    }
}