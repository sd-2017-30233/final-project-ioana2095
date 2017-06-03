using Facturii.Models;
using Facturii.Operatii;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Facturii.DAO;

namespace Facturii.Controllers
{
    [Authorize]
    public class CompanyController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        // GET: Company
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Company model,string Id)
        {
            if (ModelState.IsValid)
            {
                bool company = unitOfWork.Company.insertCompany(model.Nume,model.Telefon,model.NrCont,model.Adresa,model.Info,Id,model.Bank);
                if (company != false)
                {
                    return RedirectToAction("CompanyPage", "Company",new { Id = Id });
                }
            }
            return View(model);
        }
        [Authorize(Roles ="company")]
        public ActionResult CompanyPage(string Id)
        {
            Company comp = new Company();
            comp = unitOfWork.Company.extrageInfoCompany(Id);
            if(comp==null)
            {
                return View(new Company());
            }
            return View(comp);
        }
        public ActionResult CreareFacturi(int? page,string Id)
        {
            ICollection<InfoClient> client = unitOfWork.Consumer.print(Id);
            if(client==null)
            {
                return View(new List<InfoClient>());
            }
            int pageSize = 7;
            int pageNumber = (page ?? 1);
            return View(client.ToPagedList(pageNumber, pageSize));
        }
        [HttpPost]
        public ActionResult CreareFacturi(IEnumerable<InfoClient> model,string Id)
        {
            
            if (ModelState.IsValid)
            {
                bool company = unitOfWork.Factura.createBills(model,Id);
                if (company != false)
                {
                    return RedirectToAction("CompanyPage", "Company", new { Id = Id });
                }
            }
            return View(model);
        }
    }
}