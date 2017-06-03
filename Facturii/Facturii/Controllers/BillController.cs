using Facturii.DAO;
using Facturii.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;


namespace Facturii.Controllers
{
    public class BillController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        // GET: Bill
        public ActionResult Index(int? page,string Id)
        {
            ICollection<Bill> model = unitOfWork.Factura.afisareFacturi(Id);
            if (model == null)
            {
                return View(new List<Bill>());
            }
            int pageSize = 7;
            int pageNumber = (page ?? 1);
            return View(model.ToPagedList(pageNumber, pageSize));
        }
        [HttpPost]
        public ActionResult Index(List<Bill> model,string Id)
        {
            Inregistrare inreg = new Inregistrare();
            if (ModelState.IsValid)
            {
                var val=inreg.inregistrare(model, Id);
                if(val!=false)
                {
                    return RedirectToAction("ConsumerPage", "Consumer", new { Id = Id });
                }
               
            }
            return View(model);
        }
        

    }
}