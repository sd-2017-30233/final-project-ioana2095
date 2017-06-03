using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Facturii.Decorator
{
    abstract class Decorator1:Form
    {
        protected Form form;
        public Decorator1(Form form)
        {
            this.form = form;
        }
        public override  string Display()
        {
            return form.Display();
        }
    }
}