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
    public class ArticleRepository : IArticle
    {
        private SqlConnection _connection;

        public ArticleRepository()
        {
            _connection = new SqlConnection(Properties.Resources.strConnection);
        }
        public List<Article> GetArticle()
        {
          List<Article> lArticle= new List<Article>();
            var helper = DataHelper.GetInstance();
            var t = helper.ExecuteSPQuery("SP_CONSULTAR_ARTICULOS");
            foreach(DataRow row in t.Rows)
            {
                int id = Convert.ToInt32(row["id_articulo"]);
                string name = row["nombre"].ToString() ;
                double price = Convert.ToDouble(row[2]);

                Article oArticle = new Article()
                {
                    Id_Article = id,
                     Name = name,
                    Price_Unitary = price
                };
                lArticle.Add(oArticle);
            }

            return lArticle;
        }

        public bool Save(Article oArticle)
        {
            bool result = true;
            string query = "SP_ALTA_ARTICULO";
            try 
            {
                if (oArticle != null)
                {
                    _connection.Open();
                    var cmd = new SqlCommand(query, _connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@nombre", oArticle.Name);
                    cmd.Parameters.AddWithValue("@precio_unitario", oArticle.Price_Unitary);

                    result = cmd.ExecuteNonQuery() == 1;
                }
            }
            catch(SqlException ex)
            {
                Console.WriteLine(ex);
                result = false;
            }
            finally
            {
                if(_connection!=null && _connection.State==System.Data.ConnectionState.Open)
                {
                    _connection.Close();
                }
            }
            return result;
        }
    }
}
