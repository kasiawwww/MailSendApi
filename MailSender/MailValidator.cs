using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MailSender
{
    public class MailValidator
    {
        private readonly string errorMessage;
        EmailAddressAttribute emailAddressAttribute = new EmailAddressAttribute();
        List<string> emails = new List<string>();
        public string ErrorMesage
        {
            get
            {
                if (emails.Count == 0)
                    return string.Empty;
                return $"{errorMessage}{Environment.NewLine}{string.Join($";{Environment.NewLine}", emails)}";
            }
        }
        public MailValidator(string errorMessage) => this.errorMessage = errorMessage;

        public bool IsValid(object value)
        {
            if (value is string)
            {
                if (!emailAddressAttribute.IsValid(value))
                    emails.Add(value.ToString());
                return false;
            }
            if (value is string[])
            {
                foreach (var v in value as string[])
                {
                    if (!emailAddressAttribute.IsValid(v) && v.Length > 0)
                        emails.Add(v);
                }
                return (emails.Count == 0);
            }
            return false;
        }
    }
}
