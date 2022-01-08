using System.Net.Mail;
using System.Threading.Tasks;

namespace O2NextGen.ESender.Api.Helpers
{
    public class EmailSender
    {
        public EmailSender()
        {
            SmtpServerHost = "localhost";
            SmtpServerPort = 25;
            From="example@example.com";
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
                using (var message = new MailMessage(From, to))
                {
                    message.Subject = subject;
                    message.IsBodyHtml = true;
                    message.Body = bodyHtml;
                    await client.SendMailAsync(message).ConfigureAwait(false);
                }
            }
        }
    }
}