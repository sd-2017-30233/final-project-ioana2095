using Facturii.DAO;
using Facturii.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Facturii.Controllers
{
    [Authorize]
    public class ConsumerController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        // GET: Consumer
        public ActionResult Index()
        {
            List<CompanyInfo> comp = new List<CompanyInfo>();
            Client c = new Client();
            c.Companie = new List<CompanyInfo>();
            c.Companie.Add(new CompanyInfo {  Nume = "Apa Nov" , isCheck = false });
            c.Companie.Add(new CompanyInfo {  Nume = "Congaz Constanța", isCheck = false });
            c.Companie.Add(new CompanyInfo {  Nume = "Distrigaz Sud", isCheck = false });
            c.Companie.Add(new CompanyInfo {  Nume = "Electrica", isCheck = false });
            c.Companie.Add(new CompanyInfo {  Nume = "E.ON Gaz România", isCheck = false });
            c.Companie.Add(new CompanyInfo {  Nume = "Wiee România", isCheck = false });
            c.Companie.Add(new CompanyInfo {  Nume = "RDS", isCheck = false });
            c.Companie.Add(new CompanyInfo {  Nume = "Orange", isCheck = false });
            c.Companie.Add(new CompanyInfo {  Nume = "Telecom", isCheck = false });
           
            return View(c);
        }
        [HttpPost]
        public ActionResult Index(Client model,string Id)
        {
            if (ModelState.IsValid)
            {
                bool consumer = unitOfWork.Consumer.insert(model.Nume,model.Prenume,model.Adresa,model.Telefon,model.Companie,Id);
                if (consumer != false)
                {
                    return RedirectToAction("ConsumerPage", "Consumer");
                }
            }
            return View(model);
        }
        public ActionResult ConsumerPage(string Id)
        {
            var client = unitOfWork.Consumer.extrageInfo(Id);
            if (client == null)
            {
                return RedirectToAction("Index", "Consumer",new { Id = Id });
            }
            return View(client);
        }
       
    }
}