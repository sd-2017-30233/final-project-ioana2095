using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Facturii.Decorator
{
    abstract class Form
    {
        private String nume;
        private String firma;
        private String text;
        public String Nume
        {
            get { return nume; }
            set { nume = value; }
        }
        public String Firma
        {
            get { return firma; }
            set { firma = value; }
        }
        public String Text
        {
            get { return text; }
            set { text = value; }
        }
        public abstract string Display();
    }
}