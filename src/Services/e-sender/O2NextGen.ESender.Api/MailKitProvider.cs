using System.ComponentModel;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using O2NextGen.ESender.Data.Entities;

namespace O2NextGen.ESender.Api
{ 
    // public static class ServiceCollectionExtensions
    // {
    //     public static Container RegisterEmailProviderService(this Container container, IConfiguration configuration)
    //     {
    //         container.Register<IEmailManager, EmailManager>();
    //         container.Register<IMailKitProvider, MailKitProvider>();
    //         container.RegisterInstance<ISmtpSetting>(configuration.GetSection("AppSettings:SmtpSetting").Get<SmtpSetting>());
    //
    //         return container;
    //     }
    // }
    // public interface IMailKitProvider
    // {
    //     Task Send(MimeMessage message);
    // }
    // public class MailKitProvider : IMailKitProvider
    // {
    //     private readonly ISmtpSetting smtpSetting;
    //
    //     public MailKitProvider(ISmtpSetting smtpSetting)
    //     {
    //         this.smtpSetting = smtpSetting;
    //     }
    //
    //     public async Task Send(MimeMessage message)
    //     {
    //         if (message.From.Count == 0)
    //             message.From.Add(new MailboxAddress(string.Empty, smtpSetting.Email));
    //
    //         using (var emailClient = new SmtpClient())
    //         {
    //             if (smtpSetting.UseSSL)
    //                 emailClient.Connect(smtpSetting.Server, smtpSetting.Port, false);
    //             else
    //                 emailClient.Connect(smtpSetting.Server, smtpSetting.Port, MailKit.Security.SecureSocketOptions.StartTls);
    //
    //             emailClient.Capabilities &= ~(SmtpCapabilities.Chunking | SmtpCapabilities.BinaryMime | SmtpCapabilities.Size);
    //             emailClient.AuthenticationMechanisms.Remove("XOAUTH2");
    //
    //             emailClient.Authenticate(smtpSetting.Email, smtpSetting.Password);
    //             await emailClient.SendAsync(message);
    //
    //             emailClient.Disconnect(true);
    //         }
    //     }
    // }
    }