using Facturacion.Datos.Interface;
using Facturacion.Datos.Repository;
using Facturacion.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturacion.Servicios
{
    public class InvoiceService
    {
        private IInvoice _repository;

        public InvoiceService()
        {
            _repository = new InvoiceRepository();
        }
        public bool Save(Invoice oInvoice)
        {
            return _repository.Save(oInvoice);
        }
        public List<Invoice> GetAll()
        {
            return _repository.GetInvoice();
        }
        public List<Details_Invoice> Get()
        {
            return _repository.GetDetails();
        }
    }
}
