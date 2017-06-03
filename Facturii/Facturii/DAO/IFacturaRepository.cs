using Facturii.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Facturii.DAO
{
    public interface IFacturaRepository:IDisposable
    {
        List<Bill> afisareFacturi(String Id);
        bool createBills(IEnumerable<InfoClient> client, string Id);
        IEnumerable<Bill> print();
        IEnumerable<Bill> extrageBill(string Nume);
    }
}