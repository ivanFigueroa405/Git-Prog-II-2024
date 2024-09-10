using Facturacion.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturacion.Datos.Interface
{
    public interface IPayment_Methods
    {
        List<Payment_Methods> GetAll();
    }
}
