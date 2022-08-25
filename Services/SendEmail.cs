using MimeKit;
using System.IO;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using simo2api.Helpers;

namespace simo2api.Services
{
    public class MailService : IMailService
    {
        public void SendEmailAsync(MailRequest mailRequest)
        {
            MailSettings mailSettings = new ConfigConnection().getConfigureEmail();
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(mailSettings.Mail);
            foreach (var item in mailRequest.ToEmail)
            {
                email.To.Add(MailboxAddress.Parse(item.To)); // Add to
            }

            if(mailRequest.CCEmail != null)
            {
                foreach (var item in mailRequest.CCEmail)
                {
                    email.Cc.Add(MailboxAddress.Parse(item.Cc)); // Add Cc
                }
            }

            if (mailRequest.BccEmail != null)
            {

                foreach (var item in mailRequest.BccEmail)
                {
                    email.Bcc.Add(MailboxAddress.Parse(item.Bcc)); // Add Bcc
                }
            }
            email.Subject = mailRequest.Subject;
            var builder = new BodyBuilder();
            if (mailRequest.Attachments != null)
            {
                byte[] fileBytes;
                foreach (var file in mailRequest.Attachments)
                {
                    if (file.Length > 0)
                    {
                        using (var ms = new MemoryStream())
                        {
                            file.CopyTo(ms);
                            fileBytes = ms.ToArray();
                        }
                        builder.Attachments.Add(file.FileName, fileBytes, ContentType.Parse(file.ContentType));
                    }
                }
            }
            builder.HtmlBody = mailRequest.Body;
            email.Body = builder.ToMessageBody();

            using (SmtpClient smtp = new SmtpClient())
            {
                smtp.Connect(mailSettings.Host, mailSettings.Port, SecureSocketOptions.StartTls);
                smtp.Authenticate(mailSettings.Mail, mailSettings.Password);
                smtp.Send(email);
            }
        }
    }
}