using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace FacturacionApi.Data
{
    public class Helper
    {
        private SqlConnection Connection;
        private static Helper Instance;

        public Helper()
        {
            Connection = new SqlConnection(Properties.Resources.cnnString);
        }

        public static Helper GetInstance()
        {
            if (Instance == null)
            {
                Instance = new Helper();
            }
            return Instance;
        }
        public DataTable ExecuteSP(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                Connection.Open();
                var cmd = new SqlCommand(sql, Connection);
                cmd.CommandType = CommandType.StoredProcedure;
                dt.Load(cmd.ExecuteReader());
                Connection.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                dt = null;
            }
            return dt;
        }
        public DataTable ExecuteSql(string sql, List<Parameters> lParameter)
        {
            DataTable dt = new DataTable();
            try
            {
                Connection.Open();//abrimos conexion
                var cmd = new SqlCommand(sql, Connection);//creamos un comando con parametros de query y conexion
                cmd.CommandType = CommandType.StoredProcedure;//asignamos tipo de query
                if (lParameter != null)
                {
                    foreach (var p in lParameter)
                    {
                        cmd.Parameters.AddWithValue(p.Name, p.Value);
                    }
                    dt.Load(cmd.ExecuteReader());
                    Connection.Close();
                }
            }
            catch (SqlException)
            {
                dt = null;
            }
            return dt;
        }
        public int ExecuteSPDML(string SP, List<Parameters> lParameter)
        {
            int rows = 0;
            try
            {
                Connection.Open();
                var cmd = new SqlCommand(SP, Connection);
                cmd.CommandType = CommandType.StoredProcedure;
                if (lParameter != null)
                {
                    foreach (var p in lParameter)
                    {
                        cmd.Parameters.AddWithValue(p.Name, p.Value);
                    }
                }
                rows = cmd.ExecuteNonQuery();
                Connection.Close();

            }
            catch (SqlException)
            {
                rows = 0;
            }
            return rows;
        }

    }
}
