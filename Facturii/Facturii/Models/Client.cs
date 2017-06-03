using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Facturii.Models
{
    public class Client
    {
        public int IdConsumer { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string Telefon { get; set; }
        public string Adresa { get; set; }
        public List<CompanyInfo> Companie { get; set; }
    }
    public class CompanyInfo
    {
        public string Nume { get; set; }
        public bool isCheck { get; set; }

    }
    public class InfoClient
    {
        public int IdConsumer { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string Telefon { get; set; }
        public string Adresa { get; set; }
        public bool isCheck { get; set; }
    }
}