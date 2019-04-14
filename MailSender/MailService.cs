using MailService;
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
        public static bool Send(MailModel model)
        {
            try
            {
                //infoLogger.Log("Próba wysłania maila");
                var message = new MailMessage();
                message.From = new MailAddress(model.MailFrom, model.MailFrom);
                model.MailTo.ForEach(m => message.To.Add(new MailAddress(m)));
                message.Subject = model.Title;
                message.Body = model.Body;
                var smtp = new SmtpClient(AppSettings.Get<string>("smtp"))
                {
                    UseDefaultCredentials = AppSettings.Get<bool>("UseDefaultCredentials"), //To do App.config
                    Credentials = new NetworkCredential(AppSettings.Get<string>("Credentials"), AppSettings.Get<string>("Password")), //To do App.config
                    EnableSsl = AppSettings.Get<bool>("EnableSsl"), //To do App.config
                    Port = AppSettings.Get<int>("Port") //To do App.config
                }; //To do App.config
                smtp.Send(message);
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
