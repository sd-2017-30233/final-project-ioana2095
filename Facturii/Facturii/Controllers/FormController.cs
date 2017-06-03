using Facturii.DAO;
using Facturii.Decorator;
using Facturii.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace Facturii.Controllers
{
    public class FormController : Controller 
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        public ActionResult Email(string Id)
        {
            
            if (!unitOfWork.Consumer.IsConsumer(Id))
            {
                return View();
            }
           return RedirectToAction("Index", "Home", new { Id = Id });
        }
        [HttpPost]
        public ActionResult Email(string Id,Formular f)
        {
            using (MailMessage mm = new MailMessage(f.Nume,f.firma))
            {
                mm.Subject = f.subiect;
                mm.Body = f.text;
                mm.IsBodyHtml = false;
                using (SmtpClient smtp = new SmtpClient())
                {
                    smtp.Host = "smtp.gmail.com";
                    smtp.EnableSsl = true;
                    NetworkCredential NetworkCred = new NetworkCredential(f.Nume,"123");
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = NetworkCred;
                    smtp.Port = 587;
                    smtp.Send(mm);
                    ViewBag.Message = "Email sent.";
                }
            }
            return View();
        }
        public ActionResult Bill(string Id)
        {
           
            if (unitOfWork.Consumer.IsConsumer(Id))
            {
                return View();
            }
            return RedirectToAction("Index", "Home", new { Id = Id });
        }
    }
}