using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MailSender
{
    public class MailModel
    {
        public MailModel()
        {
            MailTo = new List<string>();
        }
        public MailModel(List<string> mailTo, string mailFrom, string title = "", string body = "")
        {
            MailTo = mailTo;
            MailFrom = mailFrom;
            Title = title;
            Body = body;
        }
        public string SetMailTo(string emails)
        {
            var temp = emails.Split(';');
            var validator = new MailValidator("Adresaci są błędni");
            if (!validator.IsValid(temp))
            {
                return validator.ErrorMesage;
            }
            MailTo.AddRange(temp);
            MailTo.Remove(string.Empty);
            return string.Empty;
        }
        public List<string> MailTo { get; set; }
        public string MailFrom { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }
}
