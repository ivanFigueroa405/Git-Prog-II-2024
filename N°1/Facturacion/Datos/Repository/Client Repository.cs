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
    public class Client_Repository : IClient
    {
        private SqlConnection _connection;

        public Client_Repository()
        {
            _connection = new SqlConnection(Properties.Resources.strConnection);
        }

        public bool Delete(int id)
        {
            var parameters = new List<Parameters>();
            parameters.Add(new Parameters("@ID", id));
            int rows = DataHelper.GetInstance().ExecuteSPDML("SP_BAJA_CLIENTE", parameters);
            return rows == 1;
        }

        public List<Client> GetAll()
        {
            List<Client> lClients = new List<Client>();
            var helper = DataHelper.GetInstance();
            var t = helper.ExecuteSPQuery("SP_CONSULTAR_CLIENTES");
            foreach (DataRow row in t.Rows)
            {
                int id = Convert.ToInt32(row["id_cliente"]);
                string name = Convert.ToString(row["nombre"]);
                string surname= Convert.ToString(row["apellido"]);
                string shet_up = Convert.ToString(row["calle"]);
                string height = Convert.ToString(row["altura"]);


                Client oClient = new Client()
                {
                    Id_Client = id,
                    Name = name,
                    Surname = surname,
                    Shet_up = shet_up,
                    Height = height

                };
                lClients.Add(oClient);
            }
            return lClients;

        }

        public Client GetById(int id)
        {
            var parameters = new List<Parameters>();
            parameters.Add(new Parameters("id_cliente", id));
            DataTable t = DataHelper.GetInstance().ExecuteSP("SP_CONSULTAR_POR_CLIENTE", parameters);

            if (t != null && t.Rows.Count == 1)
            {
                DataRow row = t.Rows[0];
                int id_client = Convert.ToInt32(row["id_cliente"]);
                string name = Convert.ToString(row["nombre"]);
                string surname = Convert.ToString(row["apellido"]);
                string shet_up = Convert.ToString(row["calle"]);
                string height= Convert.ToString(row["altura"]);


                Client oClient = new Client();
                {
                    oClient.Id_Client = id;
                    oClient.Name = name;
                    oClient.Surname = surname;
                    oClient.Shet_up = shet_up;
                    oClient.Height = height;
                }
                return oClient;
            }
            return null;
        }

        public bool Save(Client Client)
        {
            bool result = true;
            string query = "SP_CREAR_CLIENTE";
            try
            {
                if (Client != null)
                {
                    _connection.Open();
                    var cmd = new SqlCommand(query, _connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NOMBRE", Client.Name);
                    cmd.Parameters.AddWithValue("@APELLIDO", Client.Surname);
                    cmd.Parameters.AddWithValue("@CALLE", Client.Shet_up);
                    cmd.Parameters.AddWithValue("@ALTURA", Client.Height);
                    result = cmd.ExecuteNonQuery() == 1;
                }
            }
            catch (SqlException)
            {
                result = false;
            }
            if (_connection != null && _connection.State == ConnectionState.Open)
            {
                _connection.Close();
            }
            return result;
        }
    }
}
