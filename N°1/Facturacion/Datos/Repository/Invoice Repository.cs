using Facturacion.Datos.Interface;
using Facturacion.Datos.utils;
using Facturacion.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Facturacion.Datos.Repository
{
    public class InvoiceRepository  :IInvoice
    {
        public List<Invoice> GetInvoice()
        {
            var lInvoince = new List<Invoice>();
             DataTable dt= DataHelper.GetInstance().ExecuteSPQuery("SP_OBTENER_FACTURA");
            if(dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    var invoice = new Invoice
                    {
                        Nro_Invoice = Convert.ToInt32(row["FACTURA"]),
                        Date = Convert.ToDateTime(row["FECHA"]),
                        Payment = new Payment_Methods
                        {
                            Name = Convert.ToString(row["FORMA_PAGO"]),
                        },
                        Client = new Client
                        {
                            Name = Convert.ToString(row["CLIENTE"]),
                        },

                    };
                    lInvoince.Add(invoice);
                }
            }
            return lInvoince;
        }

        public Invoice GetId(int id)
        {
            throw new NotImplementedException();
        }

        public bool Save(Invoice oInvoice)
        {
            bool result = true;
            SqlConnection? cnn = null;
            SqlTransaction? t = null;
            try
            {
                
                    cnn = DataHelper.GetInstance().GetConnection();
                    cnn.Open();
                t = cnn.BeginTransaction();
            
                    var cmd = new SqlCommand("SP_INSERTAR_MAESTRO", cnn,t);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@forma_pago", oInvoice.Payment.Id_Methods);
                    cmd.Parameters.AddWithValue("@cliente", oInvoice.Client.Id_Client);

                    SqlParameter parameter = new SqlParameter("@nro_factura", SqlDbType.Int);
                    parameter.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(parameter);

                    cmd.ExecuteNonQuery();

                    int budgetId = (int)parameter.Value;//castea mi valor a int
                    int detailId = 1;
                    foreach (var detail in oInvoice.Details)//el .Details usa la lista de la clase de domain
                    {
                        var cmdDetail = new SqlCommand("SP_INSERTAR_DETALLES", cnn, t);
                        cmdDetail.CommandType = CommandType.StoredProcedure;
                        cmdDetail.Parameters.AddWithValue("@id_detalle", detailId);
                        cmdDetail.Parameters.AddWithValue("@id", budgetId);
                        cmdDetail.Parameters.AddWithValue("@articulo", detail.Article.Id_Article);
                        cmdDetail.Parameters.AddWithValue("@cantidad", detail.Quantity);
                        cmdDetail.ExecuteNonQuery();
                        detailId++;
                    }
          
                t.Commit();//confirma todo lo que pretendi en el metodo

            }
            catch (SqlException ex)
            {
                if (t != null)
                    t.Rollback();
                Console.WriteLine(ex);
                result = false;
            }
            finally
            {
                if (cnn != null && cnn.State == System.Data.ConnectionState.Open)
                {
                    cnn.Close();
                }
            }

            return result;
        }

        public List<Details_Invoice> GetDetails()
        {
            var lDetail= new List<Details_Invoice>();
            DataTable dt = DataHelper.GetInstance().ExecuteSPQuery("SP_OBTENER_DETALLE");
            if (dt != null)
            {
                foreach(DataRow row in dt.Rows)
                {

                    var Detail = new Details_Invoice
                    {
                        Id_detail = Convert.ToInt32(row["DETALLE"]),
                        Nbr_Inovice = new Invoice
                        {
                            Nro_Invoice = Convert.ToInt32(row["IDFD"]),
                        },
                        Article=new Article
                        {
                            Name = Convert.ToString(row["ARTICULO"]),
                        },
                    };
                    lDetail.Add(Detail);

                }
            }
            return lDetail;
        }
    }
}
