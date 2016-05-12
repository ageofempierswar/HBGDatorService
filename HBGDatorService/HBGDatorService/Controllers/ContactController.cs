using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using HBGDatorServiceDAL;
using HBGDatorServiceDAL.Models;
using System.Net;

namespace HBGDatorService.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<ActionResult> Contact(ContactModel model)
        {
            if (ModelState.IsValid)
            {
                var email = "linusekdahl@gmail.com";

                var body = "<p>Email From: {0} (Subject: {1})</p><p>Message:</p><p>{2}</p>";
                var message = new MailMessage();
                message.To.Add(new MailAddress(email));
                message.Subject = model.Subject;
                message.From = new MailAddress(model.EmailAdress);
                message.Body = string.Format(body, model.EmailAdress, model.Subject, model.Message);
                message.IsBodyHtml = true;

                using (var client = new SmtpClient())
                {
                    client.Host = "smtp.gmail.com";
                    client.Port = 587;
                    client.EnableSsl = true;
                    client.Credentials = new NetworkCredential("linusekdahl@gmail.com", "Monaghan5");


                    await client.SendMailAsync(message);
                    return RedirectToAction("Index");
                }

            }
            return View("Index");


        }

        public ActionResult Sent()
        {
            return View();
        }


    }
}