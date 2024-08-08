using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class Conexion
    {
        //singleton
        public static Conexion _conexion;
        public static SqlConnection sqlConnection;


        private Conexion() //Obtiene la cadena del web.config y la abre
        {
           
        }

        public static Conexion GetInstancia()
        {
            if (_conexion == null)
            {
                _conexion = new Conexion();
            }

            return _conexion;
        }


        public static string GetConnectionString()
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings["ProyectoAbril2024GitHub"].ToString();
        }


        public SqlConnection GetConnection()
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ProyectoAbril2024GitHub"].ToString(); ;
            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            return sqlConnection;
        }

        public void CloseConnection()
        {
            if (sqlConnection != null && sqlConnection.State == System.Data.ConnectionState.Open)
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
        }


    }
}
