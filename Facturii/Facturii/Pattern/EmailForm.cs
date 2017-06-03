using Facturii.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Facturii.Decorator
{
    class EmailForm : Form
    {
        private string subiect;
        public EmailForm(string nume,string firma,string text,string subiect)
        {
            this.Nume = nume;
            this.Text = text;
            this.Firma = firma;
            this.subiect = subiect;
        }
        public String Subiect
        {
            get { return subiect; }
            set { subiect = value; }
        }
        public override string Display()
        {
            return "Email";
        }
    }
}