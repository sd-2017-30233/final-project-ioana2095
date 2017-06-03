using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Facturii.Decorator;

namespace Facturii.Models
{
     class EmailFormModel : Decorator1
    {

        public EmailFormModel(Form form) : base(form){
        }
        public override string Display()
        {
            
            return base.Display();
        }
    }
    class BillFormModel : Decorator1
    {
        public BillFormModel(Form form) : base(form)
        {

        }
        public override string Display()
        {

            return base.Display();
        }

    }
    public class Formular
    {
        public string Nume { get; set; }
        public  string firma { get; set; }
        public string text { get; set; }
        public string subiect { get; set; }
        public int consum { get; set; }
        public float total { get; set; }
    }

}