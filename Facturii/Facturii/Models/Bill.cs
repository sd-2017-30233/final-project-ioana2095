using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Facturii.Models
{
    public class Bill
    {
        public string NrIdentificare { get; set; }
        public string Nume  { get; set; }
        public string Prenume { get; set; }
        public string DataEmiteri { get; set; }
        public string DataScadenta { get; set; }
        public float Consum { get; set; }
        public float Total { get; set; }
        public bool isChecked { get; set; }

    }
    public class Bills
    {
        public List<Bill> Factura { get; set; }
        
    }
}