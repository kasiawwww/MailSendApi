using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MailSenderApi.Models
{
    public class Mail
    {
        public int Id { get; set; }
        [Required]
        public string To { get; set; }
        [Required]
        public string From { get; set; }
        [MaxLength(100)]
        public string Title { get; set; }
        [MaxLength(1000)]
        public string Body { get; set; }
    }
}
