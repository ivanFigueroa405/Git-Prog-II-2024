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
   public class PaymentMethods_Service
    {
        private IPayment_Methods _repository;
        public PaymentMethods_Service()
        {
            _repository = new PaymentMethods_Repository();
        }

        public List<Payment_Methods> GetAllMethods()
        {
            return _repository.GetAll();
        }

    }
}
