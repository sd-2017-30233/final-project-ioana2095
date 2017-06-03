using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Facturii.DAO
{
    public class UnitOfWork : IDisposable
    {
        static string cale = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
        CompanyRepository company;
        ConsumerRepository consumer;
        FacturaRepository factura;
        public void Dispose()
        {
            throw new NotImplementedException();
        }
        public  CompanyRepository Company
        {
            get
            {

                if (this.company == null)
                {
                    this.company = new CompanyRepository(cale);
                }
                return company;
            }
        }
        public ConsumerRepository Consumer
        {
            get
            {

                if (this.consumer == null)
                {
                    this.consumer = new ConsumerRepository(cale);
                }
                return consumer;
            }
        }
        public FacturaRepository Factura
        {
            get
            {

                if (this.factura == null)
                {
                    this.factura = new FacturaRepository(cale);
                }
                return factura;
            }
        }
    }
}