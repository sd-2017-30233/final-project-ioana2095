using Facturii.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Facturii.DAO
{
    public interface IConsumerRepository: IDisposable
    {
        string idRole();
        bool IsConsumer(String Id);
        Client extrageInfo(string Id);
        IEnumerable<Client> extrageClient(string Nume);
        bool insert(string nume, string prenume, string adresa, string telefon, List<CompanyInfo> comp, string id);
        List<InfoClient> print(string Id);
        IEnumerable<Client> print();
    }
}