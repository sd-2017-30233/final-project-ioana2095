using Facturii.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Facturii.Decorator
{
    class BillForm : Form
    {
        private int Consum;
        private float Total;
        public BillForm(string nume, string firma, string text, int Consum, float Total)
        {
            this.Nume = nume;
            this.Text = text;
            this.Firma = firma;
            this.Consum = Consum;
            this.Total = Total;
        }
        public override string Display()
        {
            return "Bill";
        }
    }
}