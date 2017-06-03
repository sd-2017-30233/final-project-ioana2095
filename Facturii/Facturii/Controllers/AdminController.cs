using Facturii.Operatii;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Facturii.Models;
using Facturii.DAO;

namespace Facturii.Controllers
{
    public class AdminController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        // GET: Admin
        public ActionResult AdminPage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminPage(string Id)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("AdminPage", "Admin");
            }
            return View();
        }
        public ActionResult AfisareClient(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;
            IEnumerable<Client> clients = unitOfWork.Consumer.print();
            if (!String.IsNullOrEmpty(searchString))
            {
                clients = unitOfWork.Consumer.extrageClient(searchString);
            }
            switch (sortOrder)
            {
                case "name_desc":
                    clients = clients.OrderByDescending(s=>s.Nume);
                    break;
                default:  // Name ascending 
                    clients = clients.OrderBy(s => s.Nume);
                    break;
            }

            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(clients.ToPagedList(pageNumber, pageSize));
        }


        public ActionResult AfisareCompany(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;
            IEnumerable<Company> companies = unitOfWork.Company.print();
            if (!String.IsNullOrEmpty(searchString))
            {
                companies = unitOfWork.Company.extrageCompany(searchString);
            }
            switch (sortOrder)
            {
                case "name_desc":
                    companies = companies.OrderByDescending(s => s.Nume);
                    break;
                default:  // Name ascending 
                    companies = companies.OrderBy(s => s.Nume);
                    break;
            }

            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(companies.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult AfisareBill(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;
            IEnumerable<Bill> bills = unitOfWork.Factura.print();
            if (!String.IsNullOrEmpty(searchString))
            {
                bills = unitOfWork.Factura.extrageBill(searchString);
            }
            switch (sortOrder)
            {
                case "name_desc":
                    bills = bills.OrderByDescending(s => s.Nume);
                    break;
                default:  // Name ascending 
                    bills = bills.OrderBy(s => s.Nume);
                    break;
            }

            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(bills.ToPagedList(pageNumber, pageSize));
        }
    }
}