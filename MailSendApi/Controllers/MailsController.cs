using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MailSenderApi.Models;
using MailSender;
using System.Net.Mail;

namespace MailSendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailsController : ControllerBase
    {
        private readonly MailContext db;

        public MailsController(MailContext db)
        {
            this.db = db;
        }
        // GET api/values
        [HttpGet]
        public IActionResult GetMails()
        {
            try
            {
                return Ok(db.Mails.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult GetMails(int id)
        {
            try
            {
                var mail = db.Mails.SingleOrDefault(a => a.Id == id);
                if (mail == null)
                {
                    return NotFound("Nie znaleziono.");
                }
                return Ok(mail);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }

        // POST api/values
        [HttpPost]
        public IActionResult AddMails(Mail mail)
        {
            string message = string.Empty;
            try
            {
                if (ModelState.IsValid)
                {
                    MailModel model = new MailModel();
                    model.MailFrom = mail.From; 
                    message = model.SetMailTo(mail.To);
                    if (message != string.Empty)
                    {
                        return BadRequest(message);
                    }
                    model.Title = mail.Title;
                    model.Body = mail.Body;

                    MailService.Send(model);
                    db.Mails.Add(mail);
                    db.SaveChanges();
                    return CreatedAtAction(nameof(GetMails), new { id = mail.Id }, mail);
                }
                return BadRequest("Błedne dane wejsciowe");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}