
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace MailSender
{
    public static class MailService
    {
        //static Logger.Info infoLogger = new Logger.Info();
       // static Logger.Error errorLogger = new Logger.Error();
        public static async Task<bool> SendAsync(MailModel model, SendGridClient client)
        {
            try
            {
                var message = new SendGridMessage();
                message.SetFrom(new EmailAddress(model.MailFrom));

                var recipients = new List<EmailAddress>();
                foreach (var item in model.MailTo)
                {
                    recipients.Add(new EmailAddress(item));
                }
                message.AddTos(recipients);
                message.SetSubject(model.Title);
                message.AddContent(MimeType.Text, model.Body);

                var response = await client.SendEmailAsync(message);
                return true;
            }
            catch (SmtpException smtpEx)
            {
                //errorLogger.Log($"Smtp Error: {smtpEx.Message}");
                throw;
            }
            catch (Exception ex)
            {
                //errorLogger.Log(ex.Message);
                throw;
            }
        }
    }
}
