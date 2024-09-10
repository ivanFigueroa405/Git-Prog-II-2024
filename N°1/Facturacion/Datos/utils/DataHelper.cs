using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Facturacion.Datos.utils
{
    public class DataHelper
    {
        private static DataHelper _instance;
        private SqlConnection _connection;

        private DataHelper()
        {
            _connection = new SqlConnection(Properties.Resources.strConnection);
        }

        public static DataHelper GetInstance()
        {
            if (_instance == null)
            {
                _instance = new DataHelper();
            }
            return _instance;
        }
        public DataTable ExecuteSPQuery(string sp)///PARA DEVOLVER LISTAS
        {
            DataTable dt = new DataTable();

            try
            {
                _connection.Open();
                var cmd = new SqlCommand(sp, _connection);
                cmd.CommandType = CommandType.StoredProcedure;
                dt.Load(cmd.ExecuteReader());//ES READER PORQUE ES UNA QUERY TIPO CONSULTA
                _connection.Close();
            }
            catch (SqlException)
            {
                //GESTIONAR EL ERROR....
                dt = null;

            }

            return dt;
        }

        public DataTable ExecuteSP(string SP,List<Parameters> lParameter)
        {
            DataTable dt = new DataTable();
            try
            {
                _connection.Open();//abrimos conexion
                var cmd = new SqlCommand(SP,_connection);//creamos un comando con parametros de query y conexion
                cmd.CommandType = CommandType.StoredProcedure;//asignamos tipo de query
                if(lParameter!=null)
                {
                    foreach (var p in lParameter)
                    {
                        cmd.Parameters.AddWithValue(p.Name, p.Value);
                    }
                    dt.Load(cmd.ExecuteReader());
                    _connection.Close();
                }
            }
            catch (SqlException)
            {
                dt = null;
            }
            return dt;
        }
        public int ExecuteSPDML(string SP,List<Parameters> lParameter)
        {
            int rows = 0;
            try
            {
                _connection.Open();
                var cmd = new SqlCommand(SP,_connection);
                cmd.CommandType = CommandType.StoredProcedure;
                if(lParameter !=null)
                {
                    foreach(var p in lParameter)
                    {
                        cmd.Parameters.AddWithValue(p.Name,p.Value);
                    }
                }
                rows=cmd.ExecuteNonQuery();
                _connection.Close();

            }
            catch (SqlException)
            {
                rows = 0;
            }
            return rows;
        }
        public int ExecuteSPDMLTransac(string sp, List<Parameters>? parametros, SqlTransaction transaction)
        {
            //grabar con tranacciion



            return 0;
        }
        public SqlConnection GetConnection()
        {
            return _connection;
        }

    }
}
