using Microsoft.Extensions.Configuration.UserSecrets;
using System.Data.SqlClient;
using System.Data;
using FacturacionApi.Data;
using FacturacionApi.Entity;
using FacturacionApi.Interface;

namespace FacturacionApi.Repository
{
    public class ArticleRepository : IAplicacioncs

    {
        private SqlConnection _connection;

        public ArticleRepository()
        {
            _connection = new SqlConnection(Properties.Resources.cnnString);
        }

        public bool DeleteArticle(int id)
        {
            bool result = false;
            SqlTransaction t = null; ;

            try
            {
                _connection.Open();
                t = _connection.BeginTransaction();
                var cmd = new SqlCommand("SP_ELIMINAR_ARTICULO", _connection, t);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", id);
                result = cmd.ExecuteNonQuery() == 1;
                t.Commit();
            }
            catch (Exception ex)
            {
                t.Rollback();
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                if (_connection != null && _connection.State == ConnectionState.Open)
                    _connection.Close();
            }
            return result;
        }

        public List<Article> GetArticles()
        {
            List<Article> lArticle = new List<Article>();
            var helper = Helper.GetInstance();
            var t = helper.ExecuteSP("SP_CONSULTAR_ARTICULOS");
            foreach (DataRow row in t.Rows)
            {
                int id = Convert.ToInt32(row["id_articulo"]);
                string name = row["nombre"].ToString();
                decimal price = Convert.ToDecimal(row[2]);
                bool active = Convert.ToBoolean(row[3]);

                Article oArticle = new Article()
                {
                    Id = id,
                    Name = name,
                    Price = price,
                    Active = active,
                };
                lArticle.Add(oArticle);
            }

            return lArticle;
        }

        public bool PostArticle(Article oArticle)
        {
            bool result = true;
            string query = "SP_ALTA_ARTICULO";
            try
            {
                if (oArticle != null)
                {
                    _connection.Open();
                    var cmd = new SqlCommand(query, _connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@nombre", oArticle.Name);
                    cmd.Parameters.AddWithValue("@precio_unitario", oArticle.Price);
                    cmd.Parameters.AddWithValue("@activo", oArticle.Active);

                    result = cmd.ExecuteNonQuery() == 1;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex);
                result = false;
            }
            finally
            {
                if (_connection != null && _connection.State == ConnectionState.Open)
                {
                    _connection.Close();
                }
            }
            return result;
        }

        public bool PutArticle(Article oArticle)
        {
            bool result = true;
            string query = "SP_EDITAR_ARTICULO";
            try
            {
                if (oArticle != null)
                {
                    _connection.Open();
                    var cmd = new SqlCommand(query, _connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", oArticle.Id);
                    cmd.Parameters.AddWithValue("@nombre", oArticle.Name);
                    cmd.Parameters.AddWithValue("@precio_unitario", oArticle.Price);
                    cmd.Parameters.AddWithValue("@activo", oArticle.Active);
                    result = cmd.ExecuteNonQuery() == 1;

                }
            }
            catch (SqlException ex)
            {
                result = false;

            }


            return result;
        }
    }
}
