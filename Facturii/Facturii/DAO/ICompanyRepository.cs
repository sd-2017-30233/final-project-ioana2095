using Facturii.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Facturii.DAO
{
    public interface ICompanyRepository : IDisposable
    {
         bool insertCompany(string nume, string telefon, string nrCont, string adresa, string info, string Id, string Bank);
         Company extrageInfoCompany(string Id);
         IEnumerable<Company> print();
        IEnumerable<Company> extrageCompany(string Nume);
    }
}