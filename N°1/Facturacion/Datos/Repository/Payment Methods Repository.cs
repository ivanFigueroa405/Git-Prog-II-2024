using Facturacion.Datos.Interface;
using Facturacion.Datos.utils;
using Facturacion.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturacion.Datos.Repository
{
    public class PaymentMethods_Repository : IPayment_Methods
    {
        private SqlConnection _connection;

        public PaymentMethods_Repository()
        {
            _connection = new SqlConnection(Properties.Resources.strConnection);
        }

        public List<Payment_Methods> GetAll()
        {
           List<Payment_Methods> lMethods= new List<Payment_Methods>();
           
            var t = DataHelper.GetInstance().ExecuteSPQuery("SP_OBTENER_FORMAPAGO");
            foreach(DataRow row in t.Rows)
            {
                Payment_Methods oPayment = new Payment_Methods();
               oPayment.Id_Methods = Convert.ToInt32(row["id_forma_pago"]);
                oPayment.Name= row["nombre"].ToString();


                lMethods.Add(oPayment);
            }
            return lMethods;
        }
    }
}
