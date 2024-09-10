using Facturacion.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturacion.Datos.Interface
{
    public interface IInvoice
    {
        List<Invoice> GetInvoice();
        List<Details_Invoice> GetDetails();
        Invoice GetId(int id);
        bool Save(Invoice oInvoice);

    }
}
